using AspNetCoreRateLimit;
using Autofac.Core;
using Microsoft.OpenApi.Models;
using Prj.BAL.AutoMapper;
using Prj.COMMON.Configuration;
using Prj.COMMON.Extensions;
using Prj.COMMON.Models.ServiceResponce.Interfaces;
using Prj.COMMON.Models.ServiceResponce;
using Prj.Service;
using Prj.Service.Filters;
using Prj.BAL.BaseManager.MinIo.Interfaces;
using Prj.BAL.BaseManager.MinIo;
using Prj.BAL.Managers.Helper.Interfaces;
using Prj.BAL.Managers.Helper;
using Prj.BAL.Managers.Deneme.Interfaces;
using Prj.BAL.Managers.Deneme;
using Prj.BAL.Managers.Uygulama.Interfaces;
using Prj.BAL.Managers.Common.Kod;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();
builder.Services.AddMemoryCache();

builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<ClientRateLimitOptions>(builder.Configuration.GetSection("ClientRateLimiting"));
builder.Services.Configure<ClientRateLimitPolicies>(builder.Configuration.GetSection("ClientRateLimitPolicies"));

builder.Services.AddInMemoryRateLimiting();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IClientPolicyStore, MemoryCacheClientPolicyStore>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        );
});

builder.Services.AddCors();
builder.Services.AddHttpContextAccessor();

// tüm json nesennelerinde uygulanýr gelen ve giden
builder.Services.AddControllers().
    AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.IgnoreNullValues = true; // null datalarý dönmez ve almaz
        options.JsonSerializerOptions.IgnoreReadOnlyFields = true;
        options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
    });
builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddAutoMapper(typeof(MappingProfile));


//ayrı conf u eşlemek için
ConfigurationManager cm = new ConfigurationManager();
cm.AddJsonFile("CoreConfig.json");
var sectionCoreConfig = cm.GetSection(nameof(CoreConfig));
sectionCoreConfig.Get<CoreConfig>(); // modele direk atama yapar //Prj.COMMON.Configuration.CoreConfig.TokenKeyName = cm.GetSection("CoreConfig:TokenKeyName").Value; tek tek eklemeye gerek kalmaz

cm.AddJsonFile("MyAppConfig.json");
var sectionOdemeConfig = cm.GetSection(nameof(MyAppConfig));
sectionOdemeConfig.Get<MyAppConfig>(); // modele direk atama yapar //Prj.COMMON.Configuration.CoreConfig.TokenKeyName = cm.GetSection("CoreConfig:TokenKeyName").Value; tek tek eklemeye gerek kalmaz


//builder.Services.AddControllers(options => options.Filters.Add(new SecurityFilter())); // bunu eklemeye gerek varmı bakacağız!!!??
builder.Services.AddScoped<SecurityFilter>();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TemhaLoreBorsaV3.Api", Version = "v1" });
    c.AddSecurityDefinition("appToken", new OpenApiSecurityScheme
    {
        Description = "Token problemi oluştu: \"{token}\"",
        In = ParameterLocation.Header,
        Name = CoreConfig.TokenKeyName,
        Type = SecuritySchemeType.ApiKey
    });

});

builder.Services.AddTransient(
               typeof(Lazy<>),
               typeof(LazilyResolved<>));



#region uygulamamızda yazılan bussines servislerin managerlerin vs eklendiği bölüm
builder.Services.AddTransient(typeof(IServiceResponse<>), typeof(ServiceResponse<>));
builder.Services.AddTransient<IMinioManager, MinioManager>();
builder.Services.AddTransient<IHelperManager, HelperManager>();
builder.Services.AddTransient<IDenemeManager, DenemeManager>();
builder.Services.AddTransient<IKodManager, KodManager>();
//builder.Services.AddTransient<IOdemeManager, OdemeManager>();
//builder.Services.AddTransient<IUygulamaManager, UygulamaManager>();
//builder.Services.AddTransient<IOdemeKisiBilgiManager, OdemeKisiBilgiManager>();
#endregion uygulamamızda yazılan bussines servislerin managerlerin vs eklendiği bölüm
builder.Services.AddControllers(options => options.Filters.Add(new SecurityFilter()));

var app = builder.Build();

var forwardingOptions = new ForwardedHeadersOptions()
{
    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
};
forwardingOptions.KnownNetworks.Clear();
forwardingOptions.KnownProxies.Clear();

app.UseForwardedHeaders(forwardingOptions);


// http requestleri
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TemhaLoreBorsaV3.Api v1");
        c.RoutePrefix = "";

    });
    // app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}
else
{
    app.UseHsts();
}

app.Services.GetService<IHttpContextAccessor>();

app.ConfigureCustomMiddleware(); // bunmlar bizim middlewarelerimiz


app.UseDefaultFiles(new DefaultFilesOptions
{
    DefaultFileNames = new
              List<string> { "index.html" }
});
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();


/*
 ConfigrationManager:dotnet6 da gelen yeni bir türdür.Daha önceki sürümlerdeki sorunu çözmeye yarar.Bu sorun sadece appsetting i okurdu bunun dışındaki myappsetting i okumak için zibille işlem yapılıyordu bunun için artık bu sınıf oluşturulmuş vaziyettedir.
öncden Configrationbuilder nesnesi oluşturupo buna addjsonfile ile myappsettings.json eklenmeli ve onun üsütnden build yapılıp yapıldıktan sonra buradan configrationroot nesnesinden key olarak [key] okunmalaı ve her seferinde buid etmek gerekiyordu sonrada startupta bunu eklemek gerekti vs vs
bunun yerine direk ConfigrationManager türü geldi
buil edildikten sonra app kısmında configrationmanager nesnesi oluşturup apopsetings.json dışında bir json muz varsa bunu çağırıp sonrada cm[a] şeklinde kullanabiliriz

ConfigurationManager cm = new ConfigurationManager();
cm.AddJsonFile("myconfjsondosyam.json");
var conkDegerim = cm["json dosya icindeki conf key im"];

not:
//builder.Configuration["Conf:A"]; // direk vaue döner : appsettingsteki conf altında a değerini al gibi birşey bu şekilde tekil kullanımda yapılabilir


 */

/*
 * middleware yapılanmasındaki yenilikler
 * normalde development ortamında default gelir eskiden gelmezdi kendimiz eklerdir
 * endpoint oluşturma;
 * bunun için app.MapGet("/"()=>"selamlar direk domaine geldiniz bubir servis projesidir"); direk domaine gelen isteklerde yazılacak metin
 * 
 *genel iskelet
 *1-hostFilteringMiddleware -- ilk defaılt kuısım
 *2-developmentExceptionPageMiddleware -- develop ortamındaki midlewareler burada direk ekli gelir ama canlıda değil dikkat
 *3-RouitingMiddleware
 *4-wepaplication.aplicationbuilder -- kendimizin eklediğimiz yada yazıpta eklediğimiz middleware ler bu katmanın içine gelir bunu unutma
 *5-ebndpoindmidleware -- bu app.mapget kullanıldığı anda eklenmiş olur en sona
 * 
 * notnormalde app.UseRouting() middleware si yukarıdaki sırlamadaki gibi default yazılmasada vardır ancak örneğin cors politikaları yada statik dosya işlemleri önce yapılsın app.UseRouting() sonra yapılsın isteniyorsa bunun için app.UseRouting() bu tanımı yazmalıyız bunu yazdığımızda app.UseRouting() artık 4 numaradaki webapplication lar arasına girer ve kodta anhgi sırada ise o sırada işleme girer
 * useendpoind i kendimiz kullanacaksak userouting i de kendimiz endpointten önce yazmak zorundayız yoksa hata alırız
 * 
 * app.UseEndpoints(e=> e.MapGet("/gelinenUrleki",()=>"fonksiyonun cevabı yada işlemi neyse artık ")); //aşağıda nalatımı var ama userouting gibi şuan burada elle ekleyerek bunu midlewarelerimizin en sonuna yazdık yoksa normalde defaultta sırası başka lakin yukarıda ayrıca getmap kullanılmışsa endpoint olur bu arada useendpoind i kendimiz kullanacaksak userouting i de kendimiz endpointten önce yazmak zorundayız yoksa hata alırız
 * 
 * 
 */


/*
 
 using AspNetCoreRateLimit;
using Autofac.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Prj.BAL.AutoMapper;
using Prj.COMMON.Configuration;
using Prj.COMMON.Extensions;
using Prj.Service;
using Prj.Service.Filters;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

//bunun 5 teki karşılığı ıhostbuilder dır host yerine webaplication yapısı geldi.
//uygulama burada inşaa edilecek servisler buradan tanımlanmalı buid ten önce
//bu bir örnek
//builder.Services.AddRazorPages();

//servisler buildeten önce eklencek kendimizin yazdığı yada diğer dış servisler buradan eklenir

builder.Services.AddOptions();
builder.Services.AddMemoryCache();

builder.Services.Configure<IpRateLimitOptions>(options =>
{
    builder.Configuration.GetConnectionString("IpRateLimiting");
});

//builder.Services.Configure<IpRateLimitOptions>("IpRateLimiting");


builder.Services.AddCors();
builder.Services.AddHttpContextAccessor();
//builder.Configuration["Conf:A"]; // direk vaue döner : appsettingsteki conf altında a değerini al gibi birşey bu şekilde tekil kullanımda yapılabilir

// tüm json nesennelerinde uygulanýr gelen ve giden
builder.Services.AddControllers().
    AddJsonOptions(options =>
    {
        //options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        //options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.IgnoreNullValues = true; // null datalarý dönmez ve almaz                  
    });

builder.Services.AddAutoMapper(typeof(MappingProfile));

ConfigurationManager cm = new ConfigurationManager();
cm.AddJsonFile("CoreCongif.json");
var conkDegerim = cm[""];




builder.Services.AddControllers(options => options.Filters.Add(new SecurityFilter()));
builder.Services.AddScoped<SecurityFilter>();


//builder.Services.Configure<CoreConfig>(Configuration.GetSection("CoreCongif")); // coreConfig.json u buradan alııp eşleyeceğiz

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SanalPOS.Api", Version = "v1" });
    c.AddSecurityDefinition("appToken", new OpenApiSecurityScheme
    {
        Description = "Token problemi oluştu: \"{token}\"",
        In = ParameterLocation.Header,
        Name = CoreConfig.TokenKeyName,
        Type = SecuritySchemeType.ApiKey
    });

    //c.OperationFilter<SecurityRequirementsOperationFilter>();
});



builder.Services.AddTransient(
               typeof(Lazy<>),
               typeof(LazilyResolved<>));


// uygulama inşaa edilir yani build edilir ve bir web aplivationumuz elimizde olur geri kalan şeyler buradan sonra eklenecek
var app = builder.Build();


var forwardingOptions = new ForwardedHeadersOptions()
{
    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
};
forwardingOptions.KnownNetworks.Clear();
forwardingOptions.KnownProxies.Clear();

app.UseForwardedHeaders(forwardingOptions);


// http requestleri
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SanalPOS.Api v1"));
    // app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}
else
{
    app.UseHsts();
}

//
// app.Services 
// bu konteynırımızdır build ten önce ne eklediysek buradan bize IservicesProvider veriyor buradanda bunları tanımlıyoruz.
// medleweare ler inşaa edilmiş bir uygulamaya eklendiğine göre app kısmında çağrılır.
//

// 
// bunu örneğin buildeten önce ekledik ve artık bunu uygulamamızda kullanacağımızı belirtiyoruz ve bu şekilde tanımlayıp sonrada dependcy işnject olarak istediğimiz controllerda kullanabileceğiz
// 
app.Services.GetService<IHttpContextAccessor>();


//çağrılan aşağıdaki middleware lerin çağırım ve işleme giriş sıraları kodta yazıldığı gibidir.Dikkat
app.ConfigureCustomMiddleware();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles(new DefaultFilesOptions
{
    DefaultFileNames = new
              List<string> { "index.html" }
});

app.UseMiddleware<IpRateLimitMiddleware>();


app.UseRouting(); //aşğıda tanımı var kısaca burada özel olarak bu middleware yi yazmamız demek onu webaplication middleware ler arasındaki istediğimiz sıraya almaktır

//Common.Middleware deki custom middlewareleri eklemek için

app.UseAuthorization();


app.MapRazorPages();

app.Run();


*/
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using Prj.COMMON.Aspects.Interceptors;
using Prj.COMMON.Aspects.Logging.Serilog;
using Prj.COMMON.Aspects.Logging.Serilog.Logger;
using Prj.COMMON.Helpers;

namespace Prj.COMMON.Aspects
{
    public class PermissionAspect : MethodInterception
    {

        private readonly LoggerServiceBase _loggerServiceBase;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PermissionAspect()
        {
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(typeof(PerformanceLogger));
            _httpContextAccessor = ServiceProviderHelper.ServiceProvider.GetService<IHttpContextAccessor>();
        }


        protected override void OnBefore(IInvocation invocation)
        {
            string methodName = invocation.Method.DeclaringType.Name + "." + invocation.Method.Name;
            
        }

    }
}

using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Prj.COMMON.Aspects.Interceptors;

namespace Prj.BAL.DependencyResolvers
{
    public class BusinessModule : Module
    {
        /// <summary>
        /// for Autofac.
        /// </summary>
        public BusinessModule()
        {

        }

        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()//Tüm methodlarda bulunan aspectlerin olduğu class
                })
                .SingleInstance()
                .InstancePerDependency();
        }
    }
}

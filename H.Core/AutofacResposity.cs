using Autofac;
using System.Linq;
using System.Reflection;

namespace H.Core
{
    public class AutofacResposity
    {
        public static void AutofacInitByForm()
        {
            var builder = new ContainerBuilder();
            Assembly[] asms = new Assembly[] { Assembly.LoadFrom("H.Service.dll") };
            builder.RegisterAssemblyTypes(asms).Where(t => !t.IsAbstract).PropertiesAutowired().AsImplementedInterfaces();
            IContainer container = builder.Build();
            ServiceResposity.SetInstance(container);
        }

        public static void AutofacInitByWeb()
        {
            var builder = new ContainerBuilder();
            Assembly[] asms = new Assembly[] { Assembly.Load("H.Service") };
            builder.RegisterAssemblyTypes(asms).Where(t => !t.IsAbstract).PropertiesAutowired().AsImplementedInterfaces();
            IContainer container = builder.Build();
            ServiceResposity.SetService(container);
        }
    }
}

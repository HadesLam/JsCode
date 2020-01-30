using Autofac;
using System.Linq;
using System.Reflection;

namespace Core
{
    public class AutofacResposity
    {
        public static void AutofacInitByForm()
        {
            var builder = new ContainerBuilder();
            Assembly[] asms = new Assembly[] { Assembly.LoadFrom("Services.dll") };
            builder.RegisterAssemblyTypes(asms).Where(t => !t.IsAbstract).PropertiesAutowired().AsImplementedInterfaces();
            IContainer container = builder.Build();
            ServiceResposity.SetInstance(container);
        }

        public static void AutofacInitByWeb()
        {
            var builder = new ContainerBuilder();
            Assembly[] asms = new Assembly[] { Assembly.Load("Services") };
            builder.RegisterAssemblyTypes(asms).Where(t => !t.IsAbstract).PropertiesAutowired().AsImplementedInterfaces();
            IContainer container = builder.Build();
            ServiceResposity.SetService(container);
        }
    }
}

using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.Mvc;
using CommonServiceLocator;
using System.Web.Mvc;

namespace Core
{
    public class ServiceResposity
    {
        public static void SetInstance(IContainer container)
        {
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
        }

        public static T GetInstance<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }

        public static void SetService(IContainer container)
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static T GetService<T>()
        {
            return DependencyResolver.Current.GetService<T>();
        }
    }
}

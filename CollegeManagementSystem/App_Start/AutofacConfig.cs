using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;

namespace CollegeManagementSystem
{
    class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}

using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Web.Mvc;
using CMS.DataModel.Repositories;
using System.Reflection;
using CMS.DataModel;
using System.Data.Entity;
using System.Web.Http;
using CollegeManagementSystem.App_Start;
using CMS.Business.Contracts;
using CMS.Business;

namespace CollegeManagementSystem
{
    class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterGeneric(typeof(Reposotory<>)).As(typeof(IRepository<>));
            builder.RegisterType<AutoMap>().As<IAutoMap>().SingleInstance();
            builder.RegisterType<CMSDbContext>().AsSelf().InstancePerLifetimeScope();

            RegisterServices(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<CourseBusiness>().As<ICourseBusiness>();
        }

    }
}

using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CMS.Business;
using CMS.Business.Contracts;
using CMS.DataModel;
using CMS.DataModel.Repositories;
using CMS.Host.App_Start;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace CMS.Host
{
    class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<AutoMap>().As<IAutoMap>().SingleInstance();
            builder.RegisterType<CMSDbContext>().AsSelf().InstancePerLifetimeScope();

            RegisterRepositories(builder);
            RegisterServices(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }


        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Reposotory<>)).As(typeof(IRepository<>));
            builder.RegisterType<CourseRepo>().As<ICourseRepo>();
            builder.RegisterType<AdmissionRepo>().As<IAdmissionRepo>();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<CourseBiz>().As<ICourseBiz>();
            builder.RegisterType<SubjectBiz>().As<ISubjectBiz>();
            builder.RegisterType<AdmissionBiz>().As<IAdmissionBiz>();
            builder.RegisterType<TeacherBiz>().As<ITeacherBiz>();
        }

    }
}

using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using JobAdder.Web.Configurations;
using JobAdder.Web.Helper;
using JobAdder.Web.Manager;
using JobAdder.Web.Services;

namespace JobAdder.Web
{
    public class AutofacConfig
    {
        public static IContainer Configure()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            var builder = new ContainerBuilder();

            RegisterApplicationServiceTypes(builder);
            builder.RegisterAssemblyTypes(executingAssembly)
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterControllers(executingAssembly).PropertiesAutowired();

         

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }

        private static void RegisterApplicationServiceTypes(ContainerBuilder builder)
        {
            builder.RegisterType<SearchService>().As<ISearchService>().InstancePerRequest();
            builder.RegisterType<SearchManager>().As<ISearchManager>().InstancePerRequest();
            builder.Register(context => new HttpClient()).Named<HttpClient>("JobAdderApi").SingleInstance();
            builder.Register(context => new EndPointResolver("Api.JobAdder")).As<IEndPointResolver>().InstancePerRequest();
            builder.Register(context => new ApiHelper(
                context.ResolveNamed<HttpClient>("JobAdderApi"))).As<IApiHelper>().InstancePerRequest();
        }
    }
}
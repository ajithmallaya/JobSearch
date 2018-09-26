using System.Web.Mvc;
using System.Web.Routing;

namespace JobAdder.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "JobSearch",
                "Jobs/{roles}/{searchKey}",
                new { controller = "Home", action = "GetJobsAndCandidates", roles = UrlParameter.Optional, searchKey = UrlParameter.Optional }

            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

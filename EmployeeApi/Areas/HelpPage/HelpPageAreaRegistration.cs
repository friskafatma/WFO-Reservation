using System.Web.Http;
using System.Web.Mvc;

namespace EmployeeApi.Areas.HelpPage
{
    public class HelpPageAreaRegistration2 : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HelpPage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HelpPage_1",
                "Help/v1/{action}/{id}",
                new { controller = "Help", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "HelpPage_2",
                "Help/v2/{action}/{id}",
                new { controller = "Help", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
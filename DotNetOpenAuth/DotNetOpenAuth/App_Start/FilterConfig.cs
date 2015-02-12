using System.Web;
using System.Web.Mvc;

namespace Tavisca.Vexiere.DotNetOpenAuth.VexiereClient
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
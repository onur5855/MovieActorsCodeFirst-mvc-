using System.Web;
using System.Web.Mvc;

namespace MovieActorsCodeFirst_24042022_5432
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

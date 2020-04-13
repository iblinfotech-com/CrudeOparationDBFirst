using System.Web;
using System.Web.Mvc;

namespace Crud_With_DbFirst_StoreProcedure
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

using System.Web;
using System.Web.Mvc;

namespace tranhuuhuy_2011061565
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

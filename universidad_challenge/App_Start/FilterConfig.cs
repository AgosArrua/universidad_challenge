using System.Web;
using System.Web.Mvc;

namespace universidad_challenge
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filters.VerificaInicioSesion());
        }
    }
}

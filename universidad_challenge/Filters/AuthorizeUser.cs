using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using universidad_challenge.Models;

namespace universidad_challenge.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private users oUsuario;
        //private universityEntities db = new universityEntities();
        private readonly int id_rol;

        public AuthorizeUser(int id_rol = 0)
        {
            this.id_rol = id_rol;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                oUsuario = (users)HttpContext.Current.Session["User"];
                if (oUsuario.id_rol != id_rol)
                {
                    filterContext.Result = new RedirectResult("~/Error/Unauthorized");
                }
                
                                
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Error/Unauthorized");
            }
        }
    }
}
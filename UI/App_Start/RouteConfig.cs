using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JobsNet_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               "consulta_cep",
               "consulta-cep",
               new { controller = "Cadastro", action = "Index" }
           );
            /*routes.MapRoute(
                "api_consulta_cep",
                "api/consulta_cep/{cep}",
                new { controller = "Cadastro", action = "Consulta", cep = "" }
            );*/
            routes.MapRoute(
                "cadastro",
                "cadastro",
                new { controller = "Cadastro", action = "Index" }
            );
            routes.MapRoute(
                "cadastro_criar",
                "cadastro/criar",
                new { controller = "Cadastro", action = "Criar" }
            );
            routes.MapRoute(
                "cadastro/finalizacao",
                "cadastro_finalizacao",
                new { controller = "Cadastro", action = "Finalizacao" }
            );
            routes.MapRoute(
                "visualizar",
                "visualizar",
                new { controller = "Visualizar", action = "Index" }
            );
            routes.MapRoute(
                "visualizar_consultar",
                "visualizar/consultar",
                new { controller = "Visualizar", action = "Consultar" }
            );
            /*routes.MapRoute(
                "cadastar",
                "cadastar",
                new { controller = "Cadastro", action = "Cadastrar" }
            );*/
            /*routes.MapRoute(
                "api_consulta_cep",
                "api/consulta_cep/{cep}",
                new { controller = "Home", action = "Consulta", cep = "" }
            );*/
        }
    }
}

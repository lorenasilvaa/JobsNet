﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace JobsNet_MVC.Controllers
{
    public class CepController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Cep = Business.Cep.Busca("31810440");
            return View();
        }

        //public string Consulta( string cep)
        //{
            //var cepObj = Business.Cep.Busca(cep);

            //return new JavaScriptSerializer().Serialize(cepObj);
       // }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
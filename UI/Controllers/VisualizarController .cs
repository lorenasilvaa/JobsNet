using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using System.Configuration;
using System.Data;
using System.Runtime.Remoting.Contexts;

namespace JobsNet_MVC.Controllers
{
    public class VisualizarController : Controller
    {

        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public void Consultar()
        {

            Candidato candidato = new Candidato();
            ICandidato candidatoDAO = new CandidatoDAO();
            IEndereco enderecoDAO = new EnderecoDAO();
            IProfissao profissaoDAO = new ProfissaoDAO();
            DataTable dtCandidato, dt1, dtProfissao, dtEndereco;
            List<string> lista = new List<string>();

            candidato.CodCand = Convert.ToInt32(Request["tInsc"]);
            candidato.Cpf = Request["tCPF"];

            dtCandidato = candidatoDAO.RetrieveByPk(candidato.CodCand);
            dt1 = candidatoDAO.RetrieveByCpf(candidato.Cpf);

            if (dtCandidato != null && dt1 != null)
            {
                if (dtCandidato.Rows.Count > 0 && dt1.Rows.Count > 0)
                {
                   
                    dtProfissao = profissaoDAO.RetrieveByPk(Convert.ToInt32(dtCandidato.Rows[0].ItemArray[1]));

                    dtEndereco = enderecoDAO.RetrieveByPk(Convert.ToInt32(dtCandidato.Rows[0].ItemArray[0]));

                    for (int i = 2; i < 8; i++)
                    {
                        lista.Add(dtCandidato.Rows[0].ItemArray[i].ToString());
                    }


                    lista.Add("Logradouro: " + dtEndereco.Rows[0].ItemArray[2].ToString() + ", Número: " + dtEndereco.Rows[0].ItemArray[3].ToString() + ", Bairro: " + dtEndereco.Rows[0].ItemArray[4].ToString() + " - CEP: " + dtEndereco.Rows[0].ItemArray[1].ToString() + ", " + dtEndereco.Rows[0].ItemArray[5].ToString() + " - " + dtEndereco.Rows[0].ItemArray[6].ToString());
                    lista.Add(dtProfissao.Rows[0].ItemArray[1].ToString());

                    TempData["lista"] = lista;
                    
                }
                else
                {
                    TempData["erros"] = "Cadastro não encontrado!";
                    
                }
            }

            Response.Redirect("/Visualizar");

        }
        
    }
}
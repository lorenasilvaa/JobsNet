using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using System.Configuration;
using System.Data;

namespace JobsNet_MVC.Controllers
{
    public class CadastroController : Controller
    {

        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult ConsultaCep()
        {
            return View();
        }
        public ActionResult Finalizacao()
        {
            return View();
        }
        [HttpPost]
        public void Criar()
        {
            //Coletando as informações
            Endereco endereco = new Endereco();
            IEndereco enderecoDAO = new EnderecoDAO();
            endereco.Cep = Request["tCep"];
            endereco.Logradouro = Request["tLogradouro"];
            endereco.Numero = Int32.Parse(Request["tNumero"]);
            endereco.Bairro = Request["tBairro"];
            endereco.Cidade = Request["tCidade"];
            endereco.Estado = Request["tEstado"];


            //Verificando se o cep já existe. Em caso negativo é cadastrado.

            DataTable dt1 = enderecoDAO.RetrieveByCEP(endereco.Cep);
            if (dt1 != null)
            {
              if (dt1.Rows.Count > 0)
              {
                    endereco.CodEndereco = Convert.ToInt32(dt1.Rows[0].ItemArray[0].ToString());

                }
                else {
                    enderecoDAO.Save(endereco);
              }
            }

            // verificando se o cargo já existe. Em caso negativo é cadastrado.


            Profissao profissao = new Profissao();
            IProfissao profissaoDAO = new ProfissaoDAO();
            profissao.DescProfissao = Request["tCargo"];

            
           DataTable dt = profissaoDAO.RetrieveByNome(profissao.DescProfissao);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
               {
                    profissao.CodProfissao = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
                    
               }
                else
                {
                    profissaoDAO.Save(profissao);
                }
            }

            //coletando informações do Candidato

            Candidato candidato = new Candidato();
            ICandidato candidatoDAO = new CandidatoDAO();
            candidato.FkEndereco = endereco.CodEndereco;
            candidato.FkProfissao = profissao.CodProfissao;
            candidato.NomeCand = Request["tNome"];
            candidato.Cpf = Request["tCpf"];
            candidato.DataNasc = Request["tNasc"];
            candidato.Email = Request["tMail"];
            candidato.Telefone = Request["tTelefone"];

            DataTable dt2 = candidatoDAO.RetrieveByCpf(candidato.Cpf);

            if (dt2 != null) {
                if (dt2.Rows.Count > 0)
                {
                    TempData["erro"] = "Usuário já existe na base de dados! " + "Número de Inscrição: " + candidato.CodCand;

                }
                else
                {
                    candidatoDAO.Save(candidato);
                    TempData["sucesso"] = "Usuário " + candidato.NomeCand + " Cadastrado com sucesso! Anote o número " + candidato.CodCand + ", para visualizar sua candidatura juntamente com o CPF informado: " + candidato.Cpf;
                
                }
            }
             Response.Redirect("/cadastro/finalizacao");
        }
        
    }
}
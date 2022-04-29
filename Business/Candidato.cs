using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Candidato
    {
        private int codCand;
        private string nomeCand;
        private string cpf;
        private string dataNasc;
        private string telefone;
        private string email;
        private int fkProfissao;
        private int fkEndereco;
        public Candidato() { }

        public Candidato(int codCand, string cpf, string nomeCand, string dataNasc, string telefone, string email, int fkProfissao, int fkEndereco)
        {
        
            this.codCand = codCand;
            this.nomeCand = nomeCand;
            this.cpf = cpf;
            this.dataNasc = dataNasc;
            this.telefone = telefone;
            this.email = email;
            this.fkProfissao = fkProfissao;
            this.fkEndereco = fkEndereco;
        }
        public int CodCand
        {
            get { return codCand; }
            set { codCand = value; }
        }

        public string NomeCand
        {
            get { return nomeCand; }
            set { nomeCand = value; }
        }
        public string Cpf
        {
            get { return cpf; }
            set{cpf = value;  }
        }
        public string DataNasc
        {
            get { return dataNasc; }
            set { dataNasc = value; }
        }
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public int FkProfissao
        {
            get { return fkProfissao; }
            set { fkProfissao = value; }
        }
        public int FkEndereco
        {
            get { return fkEndereco; }
            set { fkEndereco = value; }
        }

    }
}

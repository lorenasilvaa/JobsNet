using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Endereco
    {
		private int codEndereco;
		private string cep;
		private string logradouro;
		private int numero;
		private string bairro;
		private string cidade;
		private string estado;

		public Endereco() { }

		public Endereco(int codEndereco, string cep, string logradouro, int numero, string bairro, string cidade, string estado) {
			this.codEndereco = codEndereco;
			this.cep = cep;
			this.logradouro = logradouro;
			this.numero = numero;
			this.bairro = bairro;
			this.cidade = cidade;
			this.estado = estado;
		}

		public int CodEndereco
		{
			get { return codEndereco; }
			set { codEndereco = value; }
		}
		public string Cep
		{
			get { return cep; }
			set { cep = value; }
		}
		public string Logradouro
		{
			get { return logradouro; }
			set { logradouro = value; }
		}
		public int Numero
		{
			get { return numero; }
			set { numero = value; }
		}
		public string Bairro
		{
			get { return bairro; }
			set { bairro = value; }
		}
		public string Cidade
		{
			get { return cidade; }
			set { cidade = value; }
		}
		public string Estado
		{
			get { return estado; }
			set { estado = value; }
		}

	}
}

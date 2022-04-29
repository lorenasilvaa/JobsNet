using Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IEndereco
    {
        void Save(Endereco endereco);
		DataTable RetrieveByPk(int primaryKey);
		DataTable RetrieveByCEP(String cep);
		DataTable RetrieveAll();
	}
}

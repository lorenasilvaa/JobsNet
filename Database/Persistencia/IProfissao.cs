using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace Database
{
    public interface IProfissao
    {
        void Save(Profissao profissao);
		DataTable RetrieveByPk(int primaryKey);
		DataTable RetrieveByNome(String nome);
        List<Profissao> RetrieveAll();

    }
}

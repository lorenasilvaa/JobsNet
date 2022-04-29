using Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface ICandidato
    {
        void Save(Candidato candidato);
		DataTable RetrieveByPk(int primaryKey);
		DataTable RetrieveByCpf(String nome);
		DataTable RetrieveAll();
	}
}

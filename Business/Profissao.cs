using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Profissao
    {
        private int codProfissao;
        private string descProfissao;

        public Profissao() { }
        public Profissao(int codProfissao, string descProfissao)
        {
            this.codProfissao = codProfissao;
            this.descProfissao = descProfissao;
        }
        public int CodProfissao
        {
            get { return codProfissao; }
            set { codProfissao = value; }
        }
        public string DescProfissao
        {
            get { return descProfissao; }
            set{descProfissao = value;}

        }
    }
}

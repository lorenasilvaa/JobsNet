using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace Database
{
    
    public class ProfissaoDAO:IProfissao
    {
        public void Save(Profissao profissao) {

            int cod_profissao = 0;
            try
            {
                using (var c = new MySqlConnection(Conn.strConn))
                {
                    c.Open();
                    MySqlCommand command = new MySqlCommand("INSERT INTO profissoes (desc_profissao)" +
                        "VALUES('" + profissao.DescProfissao +  "')", c);

                    //Executa a Query SQL
                    command.ExecuteNonQuery();



                    if (command.LastInsertedId != 0)
                    {
                        command.Parameters.Add(new MySqlParameter("cod_profissao", command.LastInsertedId));
                        // Retorna o id do novo rgistro e convert de Int64 para Int32 (int).
                        cod_profissao = Convert.ToInt32(command.Parameters["@cod_profissao"].Value);
                        profissao.CodProfissao = cod_profissao;
                    }

                    // Fecha a conexão
                    c.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir registro: " + ex);

            }


        }
        public virtual DataTable RetrieveByPk(int primaryKey) {

            DataTable table = null;

            try
            {
                using (var c = new MySqlConnection(Conn.strConn))
                {
                    c.Open();

                    MySqlCommand command = new MySqlCommand("SELECT * FROM profissoes WHERE cod_profissao = " +
                        primaryKey + "'", c);

                    //Executa a Query SQL
                    command.ExecuteNonQuery();

                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    adapter.SelectCommand = command;

                    table = new DataTable();
                    adapter.Fill(table);
                    // Fecha a conexão
                    c.Close();
                }
               
            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro ao procurar registro: " + ex);
            }

            return table;
        }
        public virtual DataTable RetrieveByNome(String nome)
        {
            DataTable table = null;

            try
            {
                using (var c = new MySqlConnection(Conn.strConn))
                {
                    c.Open();

                    MySqlCommand command = new MySqlCommand("SELECT * FROM profissoes WHERE desc_profissao = '" +
                        nome +"'", c);

                    //Executa a Query SQL
                    command.ExecuteNonQuery();

                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    adapter.SelectCommand = command;

                    table = new DataTable();
                    adapter.Fill(table);
                    // Fecha a conexão
                    c.Close();
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro ao procurar registro: " + ex);
            }

            return table;
        }
       
        public virtual List<Profissao> RetrieveAll()
        {
            DataTable table = null;
            Profissao profissao = new Profissao();
            List<Profissao> listaProfissao = new List<Profissao>();

            try
            {
                using (var c = new MySqlConnection(Conn.strConn))
                {
                    c.Open();

                    MySqlCommand command = new MySqlCommand("SELECT * FROM profissoes ", c);

                    //Executa a Query SQL
                    command.ExecuteNonQuery();

                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    adapter.SelectCommand = command;

                    table = new DataTable();
                    adapter.Fill(table);
                    // Fecha a conexão
                    c.Close();

                    int i = -1;
                    int j = 0;

                    foreach (var item in table.Rows)
                    {
                        i++;
                        j = 0;
                        profissao.CodProfissao = Convert.ToInt32(table.Rows[i].ItemArray[j].ToString());
                        profissao.DescProfissao = table.Rows[i].ItemArray[++j].ToString();
                        listaProfissao.Add(profissao);

                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro ao procurar registro: " + ex);
            }

            return listaProfissao;
        }
    }
}

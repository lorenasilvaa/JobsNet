using Business;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    
    public class CandidatoDAO : ICandidato
    {
        public void Save(Candidato candidato) {
            int cod_candidato = 0;
            try
            {
                using (var c = new MySqlConnection(Conn.strConn))
                {
                    c.Open();
                    MySqlCommand command = new MySqlCommand("INSERT INTO candidatos (codEnd, codProf, nome_cand,cpf, data_nasc, telefone, email )" +
                        "VALUES('" + candidato.FkEndereco + "', '" + candidato.FkProfissao + "', '" + candidato.NomeCand+ "', '" + candidato.Cpf + "', '" + candidato.DataNasc + "', '"+ candidato.Telefone + "', '" + candidato.Email
                        + "')", c);

                    //Executa a Query SQL
                    command.ExecuteNonQuery();

                    if (command.LastInsertedId != 0)
                    {
                        command.Parameters.Add(new MySqlParameter("cod_cand", command.LastInsertedId));
                        // Retorna o id do novo rgistro e convert de Int64 para Int32 (int).
                        cod_candidato = Convert.ToInt32(command.Parameters["@cod_cand"].Value);
                        candidato.CodCand = cod_candidato;
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

        public DataTable RetrieveByPk(int primaryKey) {

            DataTable table = null;

            try
            {
                using (var c = new MySqlConnection(Conn.strConn))
                {
                    c.Open();

                    MySqlCommand command = new MySqlCommand("SELECT * FROM candidatos WHERE cod_cand = '" +
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
        public DataTable RetrieveByCpf(String cpf)
        {
            DataTable table = null;

            try
            {
                using (var c = new MySqlConnection(Conn.strConn))
                {
                    c.Open();

                    MySqlCommand command = new MySqlCommand("SELECT * FROM candidatos WHERE cpf = '" +
                        cpf + "'", c);

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
        public DataTable RetrieveAll()
        {
            DataTable table = null;

            try
            {
                using (var c = new MySqlConnection(Conn.strConn))
                {
                    c.Open();

                    MySqlCommand command = new MySqlCommand("SELECT * FROM candidatos ", c);

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
    }
}

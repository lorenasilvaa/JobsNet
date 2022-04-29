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
    
    public class EnderecoDAO : IEndereco
    {
        public void Save(Endereco endereco) {
            int cod_endereco = 0;

            try
            {
                using (var c = new MySqlConnection(Conn.strConn))
                {
                    c.Open();
                    MySqlCommand command = new MySqlCommand("INSERT INTO endereco (cep, logradouro, numero, bairro, cidade, estado )" +
                        "VALUES('" + endereco.Cep + "', '" + endereco.Logradouro + "', '" + endereco.Numero + "', '" + endereco.Bairro + "', '"+ endereco.Cidade + "', '" + endereco.Estado
                        + "')", c);

                    //Executa a Query SQL
                    command.ExecuteNonQuery();



                    if (command.LastInsertedId != 0)
                    {
                        command.Parameters.Add(new MySqlParameter("cod_endereco", command.LastInsertedId));
                        // Retorna o id do novo rgistro e convert de Int64 para Int32 (int).
                        cod_endereco = Convert.ToInt32(command.Parameters["@cod_endereco"].Value);
                        endereco.CodEndereco = cod_endereco;
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

                    MySqlCommand command = new MySqlCommand("SELECT * FROM endereco WHERE cod_endereco = " +
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
        public DataTable RetrieveByCEP(String cep)
        {
            DataTable table = null;

            try
            {
                using (var c = new MySqlConnection(Conn.strConn))
                {
                    c.Open();

                    MySqlCommand command = new MySqlCommand("SELECT * FROM endereco WHERE cep = '" +
                        cep + "'", c);

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

                    MySqlCommand command = new MySqlCommand("SELECT * FROM endereco ", c);

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

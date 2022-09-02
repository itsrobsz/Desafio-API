using APISistemaVeterinario.Interfaces;
using APISistemaVeterinario.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APISistemaVeterinario.Repositories
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        // Cria string de conexão com o banco de dados
        readonly string connectionString = "Data Source=DESKTOP-7OLN6OB\\SQLEXPRESS;Integrated Security=true;Initial Catalog=SistemaVeterinario";

        public bool Delete(int id)
        {
            // Abre uma conexão 
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Insere os dados no banco
                string script = "DELETE FROM Veterinarios WHERE Id=@id";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    cmd.CommandType = CommandType.Text;

                    // Comando para executar um inteiro com o número de linhas afetadas
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    if (linhasAfetadas == 0)
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        public ICollection<Veterinario> GetAll()
        {
            var veterinarios = new List<Veterinario>();

            // Abre uma conexão
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Veterinarios";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    // Lê todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            veterinarios.Add(new Veterinario
                            {
                                Id = (int)reader[0],
                                CRMV = (int)reader[1],
                                Nome = (string)reader[2],
                                Endereco = (string)reader[3],
                                Telefone = (int)reader[4],
                                Especialidade = (string)reader[5],
                                Turno = (string)reader[6],
                            });
                        }
                    }
                }
                return veterinarios;
            }

        }

        public Veterinario GetById(int id)
        {
            var veterinario = new Veterinario();

            // Abre uma conexão
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Veterinarios WHERE Id=@id";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Lê todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            veterinario.Id = (int)reader[0];
                            veterinario.CRMV = (int)reader[1];
                            veterinario.Nome = (string)reader[2];
                            veterinario.Endereco = (string)reader[3];
                            veterinario.Telefone = (int)reader[4];
                            veterinario.Especialidade = (string)reader[5];
                            veterinario.Turno = (string)reader[6];

                        }
                    }
                }
                return veterinario;
            }
        }

        public Veterinario Insert(Veterinario veterinario)
        {
            // Abre uma conexão 
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Insere os dados no banco
                string script = "INSERT INTO Veterinarios(CRMV, Nome, Endereco, Telefone, Especialidade, Turno) VALUES (@CRMV, @Nome, @Endereco, @Telefone, @Especialidade, @Turno)";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@CRMV", SqlDbType.Int).Value = veterinario.CRMV;
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = veterinario.Nome;
                    cmd.Parameters.Add("@Endereco", SqlDbType.NVarChar).Value = veterinario.Endereco;
                    cmd.Parameters.Add("@Telefone", SqlDbType.Int).Value = veterinario.Telefone;
                    cmd.Parameters.Add("@Especialidade", SqlDbType.NVarChar).Value = veterinario.Especialidade;
                    cmd.Parameters.Add("@Turno", SqlDbType.NVarChar).Value = veterinario.Turno;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return veterinario;
        }

        public Veterinario Update(int id, Veterinario veterinario)
        {
            // Abre uma conexão 
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Insere os dados no banco
                string script = "UPDATE Veterinarios SET CRMV=@CRMV, Nome=@Nome, Endereco=@Endereco, Telefone=@Telefone, Especialidade=@Especialidade, Turno=@Turno WHERE Id=@id";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@CRMV", SqlDbType.Int).Value = veterinario.CRMV;
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = veterinario.Nome;
                    cmd.Parameters.Add("@Endereco", SqlDbType.NVarChar).Value = veterinario.Endereco;
                    cmd.Parameters.Add("@Telefone", SqlDbType.Int).Value = veterinario.Telefone;
                    cmd.Parameters.Add("@Especialidade", SqlDbType.NVarChar).Value = veterinario.Especialidade;
                    cmd.Parameters.Add("@Turno", SqlDbType.NVarChar).Value = veterinario.Turno;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    veterinario.Id = id;
                }
            }
            return veterinario;
        }
    }
}

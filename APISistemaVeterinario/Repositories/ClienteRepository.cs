using APISistemaVeterinario.Interfaces;
using APISistemaVeterinario.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APISistemaVeterinario.Repositories
{
    public class ClienteRepository : IClienteRepository
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
                string script = "DELETE FROM Clientes WHERE Id=@id";

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

        public ICollection<Cliente> GetAll()
        {
            var clientes = new List<Cliente>();

            // Abre uma conexão
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Clientes";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    // Lê todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new Cliente
                            {
                                Id = (int)reader[0],
                                Nome = (string)reader[1],
                                Endereco = (string)reader[2],
                                Email = (string)reader[3],
                                Telefone = (int)reader[4],
                                CPF = (string)reader[5],
                                Imagem = (string)reader[6].ToString(),
                            });
                        }
                    }
                }
            }
            return clientes;
        }

        public Cliente GetById(int id)
        {
            var cliente = new Cliente();

            // Abre uma conexão
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Clientes WHERE Id=@id";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Lê todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cliente.Id = (int)reader[0];
                            cliente.Nome = (string)reader[1];
                            cliente.Endereco = (string)reader[2];
                            cliente.Email = (string)reader[3];
                            cliente.Telefone = (int)reader[4];
                            cliente.CPF = (string)reader[5];
                        }
                    }
                }
            }
            return cliente;
        }

        public Cliente Insert(Cliente cliente)
        {
            // Abre uma conexão 
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Insere os dados no banco
                string script = "INSERT INTO Clientes(Nome, Endereco, Email, Telefone, CPF, Imagem) VALUES (@Nome, @Endereco, @Email, @Telefone, @CPF, @Imagem)";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = cliente.Nome;
                    cmd.Parameters.Add("@Endereco", SqlDbType.NVarChar).Value = cliente.Endereco;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = cliente.Email;
                    cmd.Parameters.Add("@Telefone", SqlDbType.Int).Value = cliente.Telefone;
                    cmd.Parameters.Add("@CPF", SqlDbType.NVarChar).Value = cliente.CPF;
                    cmd.Parameters.Add("@Imagem", SqlDbType.NVarChar).Value = cliente.Imagem;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }

            return cliente;
        }

        public Cliente Update(int id, Cliente cliente)
        {
            // Abre uma conexão 
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Insere os dados no banco
                string script = "UPDATE Clientes SET Nome=@Nome, Endereco=@Endereco, Email=@Email, Telefone=@Telefone, CPF=@CPF, Imagem=@Imagem WHERE Id=@id";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = cliente.Nome;
                    cmd.Parameters.Add("@Endereco", SqlDbType.NVarChar).Value = cliente.Endereco;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = cliente.Email;
                    cmd.Parameters.Add("@Telefone", SqlDbType.Int).Value = cliente.Telefone;
                    cmd.Parameters.Add("@CPF", SqlDbType.NVarChar).Value = cliente.CPF;
                    cmd.Parameters.Add("@Imagem", SqlDbType.NVarChar).Value = cliente.Imagem;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cliente.Id = id;
                }
            }
            return cliente;
        }
    }
}

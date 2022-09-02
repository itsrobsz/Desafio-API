using APISistemaVeterinario.Interfaces;
using APISistemaVeterinario.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APISistemaVeterinario.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        // Cria string de conexão com o banco de dados
        readonly string connectionString = "Data Source=DESKTOP-7OLN6OB\\SQLEXPRESS;Integrated Security=true;Initial Catalog=SistemaVeterinario";

        // Instancia o repositório de Cliente 
        ClienteRepository repoCliente = new ClienteRepository();

        public bool Delete(int id)
        {
            // Abre uma conexão 
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Insere os dados no banco
                string script = "DELETE FROM Animais WHERE Id=@id";

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

        public ICollection<Animal> GetAll()
        {
            var animais = new List<Animal>();

            // Abre uma conexão
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Animais LEFT JOIN Clientes ON Animais.ClienteId = Clientes.Id";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    // Lê todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            animais.Add(new Animal
                            {
                                Id = (int)reader[0],
                                Nome = (string)reader[1],
                                Especie = (string)reader[2],
                                Raca = (string)reader[3],
                                Nascimento = (string)reader[4],
                                Altura = (decimal)reader[5],
                                Peso = (decimal)reader[6],
                                Alergia = (string)reader[7],
                                ClienteId = (int)reader[8],

                                // Pega o conteúdo da chave estrangeira por id
                                Cliente = repoCliente.GetById((int)reader["ClienteId"])
                            });
                        }
                    }
                        
                }
            }
            return animais;
        }
        public Animal GetById(int id)
        {
            var animal = new Animal();

            // Abre uma conexão
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Animais WHERE Id=@id";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Lê todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            animal.Id = (int)reader[0];
                            animal.Nome = (string)reader[1];
                            animal.Especie = (string)reader[2];
                            animal.Raca = (string)reader[3];
                            animal.Nascimento = (string)reader[4];
                            animal.Altura = (decimal)reader[5];
                            animal.Peso = (decimal)reader[6];
                            animal.Alergia = (string)reader[7];
                            animal.ClienteId = (int)reader[8];

                        }
                    }

                }
            }
            return animal;
        }

        public Animal Insert(Animal animal)
        {
            // Abre uma conexão 
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Insere os dados no banco
                string script = "INSERT INTO Animais(Nome, Especie, Raca, Nascimento, Altura, Peso, Alergia, ClienteId) VALUES (@Nome, @Especie, @Raca, @Nascimento, @Altura, @Peso, @Alergia, @ClienteId)";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = animal.Nome;
                    cmd.Parameters.Add("@Especie", SqlDbType.NVarChar).Value = animal.Especie;
                    cmd.Parameters.Add("@Raca", SqlDbType.NVarChar).Value = animal.Raca;
                    cmd.Parameters.Add("@Nascimento", SqlDbType.NVarChar).Value = animal.Nascimento;
                    cmd.Parameters.Add("@Altura", SqlDbType.Decimal).Value = animal.Altura;
                    cmd.Parameters.Add("@Peso", SqlDbType.Decimal).Value = animal.Peso;
                    cmd.Parameters.Add("@Alergia", SqlDbType.NVarChar).Value = animal.Alergia;
                    cmd.Parameters.Add("@ClienteId", SqlDbType.Int).Value = animal.ClienteId;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return animal;
        }

        public Animal Update(int id, Animal animal)
        {
            // Abre uma conexão 
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Insere os dados no banco
                string script = "UPDATE Animais SET Nome=@Nome, Especie=@Especie, Raca=@Raca, Nascimento=@Nascimento, Altura=@Altura, Peso=@Peso, Alergia=@Alergia, ClienteId=@ClienteId, WHERE Id=@id";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = animal.Nome;
                    cmd.Parameters.Add("@Especie", SqlDbType.NVarChar).Value = animal.Especie;
                    cmd.Parameters.Add("@Raca", SqlDbType.NVarChar).Value = animal.Raca;
                    cmd.Parameters.Add("@Nascimento", SqlDbType.NVarChar).Value = animal.Nascimento;
                    cmd.Parameters.Add("@Altura", SqlDbType.Decimal).Value = animal.Altura;
                    cmd.Parameters.Add("@Peso", SqlDbType.Decimal).Value = animal.Peso;
                    cmd.Parameters.Add("@Alergia", SqlDbType.NVarChar).Value = animal.Alergia;
                    cmd.Parameters.Add("@ClienteId", SqlDbType.NVarChar).Value = animal.ClienteId;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    animal.Id = id;
                }
            }
            return animal;
        }
    }
}

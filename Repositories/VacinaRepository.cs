using APISistemaVeterinario.Interfaces;
using APISistemaVeterinario.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APISistemaVeterinario.Repositories
{
    public class VacinaRepository : IVacinaRepository
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
                string script = "DELETE FROM Vacinas WHERE Id=@id";

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

        public ICollection<Vacina> GetAll()
        {
            var vacinas = new List<Vacina>();

            // Abre uma conexão
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Vacinas";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    // Lê todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vacinas.Add(new Vacina
                            {
                                Id = (int)reader[0],
                                Nome = (string)reader[1],
                                Aplicacao = (DateTime)reader[2],
                                Dose = (string)reader[3],
                                Retorno = (DateTime)reader[4],
                                AnimalId = (int)reader[5]
                            });
                        }
                    }

                }
            }
            return vacinas;

        }

        public Vacina GetById(int id)
        {
            var vacina = new Vacina();

            // Abre uma conexão
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Vacinas WHERE Id=@id";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Lê todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vacina.Id = (int)reader[0];
                            vacina.Nome = (string)reader[1];
                            vacina.Aplicacao = (DateTime)reader[2];
                            vacina.Dose = (string)reader[3];
                            vacina.Retorno = (DateTime)reader[4];
                            vacina.AnimalId = (int)reader[5];
                        }
                    }

                }
            }
            return vacina;
        }

        public Vacina Insert(Vacina vacina)
        {
            // Abre uma conexão 
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Insere os dados no banco
                string script = "INSERT INTO Vacinas(Nome, Aplicacao, Dose, Retorno, AnimalId) VALUES (@Nome, @Aplicacao, @Dose, @Retorno, @AnimalId)";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = vacina.Nome;
                    cmd.Parameters.Add("@Aplicacao", SqlDbType.DateTime).Value = vacina.Aplicacao;
                    cmd.Parameters.Add("@Dose", SqlDbType.NVarChar).Value = vacina.Dose;
                    cmd.Parameters.Add("@Retorno", SqlDbType.DateTime).Value = vacina.Retorno;
                    cmd.Parameters.Add("@AnimalId", SqlDbType.Int).Value = vacina.AnimalId;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }

            return vacina;
        }

        public Vacina Update(int id, Vacina vacina)
        {
            // Abre uma conexão 
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Insere os dados no banco
                string script = "UPDATE Vacinas SET Nome=@Nome, Aplicacao=@Aplicacao, Dose=@Dose, Retorno=@Retorno, AnimalId=@AnimalId WHERE Id=@id";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = vacina.Nome;
                    cmd.Parameters.Add("@Aplicacao", SqlDbType.DateTime).Value = vacina.Aplicacao;
                    cmd.Parameters.Add("@Dose", SqlDbType.NVarChar).Value = vacina.Dose;
                    cmd.Parameters.Add("AnimalId", SqlDbType.Int).Value = vacina.AnimalId;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    vacina.Id = id;
                }
            }
            return vacina;
        }
    }
}

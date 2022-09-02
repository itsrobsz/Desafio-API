using APISistemaVeterinario.Interfaces;
using APISistemaVeterinario.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APISistemaVeterinario.Repositories
{
    public class ConsultaRepository : IConsultaRepository
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
                string script = "DELETE FROM Consultas WHERE Id=@id";

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

        public ICollection<Consulta> GetAll()
        {
            var consultas = new List<Consulta>();

            // Abre uma conexão
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Consultas";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    // Lê todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            consultas.Add(new Consulta
                            {
                                Id = (int)reader[0],
                                DataHora = (DateTime)reader[1],
                                Valor = (int)reader[2],
                                VeterinarioId = (int)reader[3],
                                AnimalId = (int)reader[4]

                            });
                        }
                    }
                }
            }
            return consultas;
        }

        public Consulta GetById(int id)
        {
            var consulta = new Consulta();

            // Abre uma conexão
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string query = "SELECT * FROM Consultas WHERE Id=@id";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(query, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Lê todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            consulta.Id = (int)reader[0];
                            consulta.DataHora = (DateTime)reader[1];
                            consulta.Valor = (int)reader[2];
                            consulta.VeterinarioId = (int)reader[3];
                            consulta.AnimalId = (int)reader[4];

                        }
                    }
                }
            }
            return consulta;
        }

        public Consulta Insert(Consulta consulta)
        {
            // Abre uma conexão 
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Insere os dados no banco
                string script = "INSERT INTO Consultas(DataHora, Valor, VeterinarioId, AnimalId) VALUES (@DataHora, @Valor, @VeterinarioId, @AnimalId)";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@DataHora", SqlDbType.DateTime).Value = consulta.DataHora;
                    cmd.Parameters.Add("@Valor", SqlDbType.Decimal).Value = consulta.Valor;
                    cmd.Parameters.Add("@VeterinarioId", SqlDbType.Int).Value = consulta.VeterinarioId;
                    cmd.Parameters.Add("@AnimalId", SqlDbType.Int).Value = consulta.AnimalId;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return consulta;
        }
        public Consulta Update(int id, Consulta consulta)
        {
            // Abre uma conexão 
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Insere os dados no banco
                string script = "UPDATE Consultas SET DataHora=@DataHora, Valor=@Valor, VeterinarioId=@VeterinarioId, AnimalId=@AnimalId WHERE Id=@id";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@DataHora", SqlDbType.DateTime).Value = consulta.DataHora;
                    cmd.Parameters.Add("@Valor", SqlDbType.Decimal).Value = consulta.Valor;
                    cmd.Parameters.Add("@VeterinarioId", SqlDbType.Int).Value = consulta.VeterinarioId;
                    cmd.Parameters.Add("@AnimalId", SqlDbType.Int).Value = consulta.AnimalId;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    consulta.Id = id;
                }
            }
            return consulta;
        }
    }
}

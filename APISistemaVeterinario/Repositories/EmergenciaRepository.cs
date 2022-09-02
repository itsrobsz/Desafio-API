using APISistemaVeterinario.Interfaces;
using APISistemaVeterinario.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APISistemaVeterinario.Repositories
{
    public class EmergenciaRepository : IEmergenciaRepository
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
                string script = "DELETE FROM Emergencias WHERE Id=@id";

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

        public ICollection<Emergencia> GetAll()
        {
            var emergencias = new List<Emergencia>();

            // Abre uma conexão
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Emergencias";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    // Lê todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            emergencias.Add(new Emergencia
                            {
                                Id = (int)reader[0],
                                DataHora = (DateTime)reader[1],
                                Tipo = (string)reader[2],
                                Gravidade = (string)reader[3],
                            });
                        }
                    }
                }
            }
            return emergencias;
        }

        public Emergencia GetById(int id)
        {
            var emergencia = new Emergencia();

            // Abre uma conexão
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM Emergencias WHERE Id=@id";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Lê todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            emergencia.Id = (int)reader[0];
                            emergencia.DataHora = (DateTime)reader[1];
                            emergencia.Tipo = (string)reader[2];
                            emergencia.Gravidade = (string)reader[3];

                        }
                    }
                }
            }
            return emergencia;
        }

        public Emergencia Insert(Emergencia emergencia)
        {
            // Abre uma conexão 
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Insere os dados no banco
                string script = "INSERT INTO Emergencias(DataHora, Tipo, Gravidade) VALUES (@DataHora, @Tipo, @Gravidade)";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@DataHora", SqlDbType.DateTime).Value = emergencia.DataHora;
                    cmd.Parameters.Add("@Tipo", SqlDbType.NVarChar).Value = emergencia.Tipo;
                    cmd.Parameters.Add("@Gravidade", SqlDbType.NVarChar).Value = emergencia.Gravidade;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return emergencia;
        }

        public Emergencia Update(int id, Emergencia emergencia)
        {
            // Abre uma conexão 
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Insere os dados no banco
                string script = "UPDATE Emergencias SET DataHora=@DataHora, Tipo=@Tipo, Gravidade=@Gravidade WHERE Id=@id";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@DataHora", SqlDbType.DateTime).Value = emergencia.DataHora;
                    cmd.Parameters.Add("@Tipo", SqlDbType.NVarChar).Value = emergencia.Tipo;
                    cmd.Parameters.Add("@Gravidade", SqlDbType.NVarChar).Value = emergencia.Gravidade;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    emergencia.Id = id;
                }
            }
            return emergencia;
        }
    }
}

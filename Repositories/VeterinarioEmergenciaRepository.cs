using APISistemaVeterinario.Interfaces;
using APISistemaVeterinario.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APISistemaVeterinario.Repositories
{
    public class VeterinarioEmergenciaRepository : IVeterinarioEmergenciaRepository
    {
        // Cria string de conexão com o banco de dados
        readonly string connectionString = "Data Source=DESKTOP-7OLN6OB\\SQLEXPRESS;Integrated Security=true;Initial Catalog=SistemaVeterinario";

        public bool Delete(int id)
        {
            {
                // Abre uma conexão 
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    // Insere os dados no banco
                    string script = "DELETE FROM VeterinarioEmergencia WHERE Id=@id";

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
            }
            return true;
        }

        public ICollection<VeterinarioEmergencia> GetAll()
        {
            var veterinarioEmergencias = new List<VeterinarioEmergencia>();

            // Abre uma conexão
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM VeterinarioEmergencia";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    // Lê todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            veterinarioEmergencias.Add(new VeterinarioEmergencia
                            {

                                Id = (int)reader[0],
                                VeterinarioId = (int)reader[1],
                                EmergenciaId = (int)reader[2],

                            });
                        }
                    }
                }
            }
            return veterinarioEmergencias;

        }

        public VeterinarioEmergencia GetById(int id)
        {
            var veterinarioEmergencia = new VeterinarioEmergencia();

            // Abre uma conexão
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM VeterinarioEmergencia";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Lê todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            veterinarioEmergencia.Id = (int)reader[0];
                            veterinarioEmergencia.VeterinarioId = (int)reader[1];
                            veterinarioEmergencia.EmergenciaId = (int)reader[2];

                        }
                    }
                }
            }
            return veterinarioEmergencia;
        }

        public VeterinarioEmergencia Insert(VeterinarioEmergencia veterinarioEmergencia)
        {
            // Abre uma conexão 
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Insere os dados no banco
                string script = "INSERT INTO VeterinarioEmergencia(VeterinarioId, EmergenciaId) VALUES (@VeterinarioId, @EmergenciaId)";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@VeterinarioId", SqlDbType.Int).Value = veterinarioEmergencia.VeterinarioId;
                    cmd.Parameters.Add("@EmergenciaId", SqlDbType.Int).Value = veterinarioEmergencia.EmergenciaId;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return veterinarioEmergencia;
        }

        public VeterinarioEmergencia Update(int id, VeterinarioEmergencia veterinarioEmergencia)
        {
            // Abre uma conexão 
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Insere os dados no banco
                string script = "UPDATE VeterinarioEmergencia SET VeterinarioId=@VeterinarioId, EmergenciaId=@EmergenciaId WHERE Id=@id";

                // Cria o comando de execução no banco de dados
                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@VeterinarioId", SqlDbType.Int).Value = veterinarioEmergencia.VeterinarioId;
                    cmd.Parameters.Add("@EmergenciaId", SqlDbType.Int).Value = veterinarioEmergencia.EmergenciaId;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    veterinarioEmergencia.Id = id;
                }
            }
            return veterinarioEmergencia;
        }
    }
}

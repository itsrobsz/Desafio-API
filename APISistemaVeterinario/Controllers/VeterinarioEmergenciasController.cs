using APISistemaVeterinario.Models;
using APISistemaVeterinario.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APISistemaVeterinario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarioEmergenciasController : ControllerBase
    {
        // Cria instância do repositório
        private VeterinarioEmergenciaRepository repositorio = new VeterinarioEmergenciaRepository();

        //POST - Cadastrar
        /// <summary>
        /// Cadastra emergência e veterinários associados
        /// </summary>
        /// <param name="veterinarioEmergencia">Dados da associação entre as entidades</param>
        /// <returns>Associação cadastrada</returns>
        [HttpPost]
        public IActionResult Cadastrar(VeterinarioEmergencia veterinarioEmergencia)
        {   
            // Tratamento de exceção
            try
            {
                repositorio.Insert(veterinarioEmergencia);
                return Ok(veterinarioEmergencia);
            }
            catch (System.Exception ex)
            {
                // StatusCode 500 = erro de servidor
                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });
            }
        }

        /// <summary>
        /// Lista as emergências e veterinários associados da aplicação 
        /// </summary>
        /// <returns>Lista de emergencias e respectivos veterinários</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            // TryCatch - Tratamento de exceção
            try
            {
                var veterinarioEmergencias = repositorio.GetAll();
                return Ok(veterinarioEmergencias);

            }
            catch (System.Exception ex)
            {

                // StatusCode 500 = erro de servidor
                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });
            }
        }

        /// <summary>
        /// Altera os dados de uma emergência associada a um veterinário
        /// </summary>
        /// <param name="id">Id da associação</param>
        /// <param name="veterinarioEmergencia">Todas as informações da associação</param>
        /// <returns>Associação alterada</returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, VeterinarioEmergencia veterinarioEmergencia)
        {
            try
            {
                // Verifica por id se existe a Emergência/Veterinário a ser alterado
                var buscarVeterinarioEmergencia = repositorio.GetById(id);

                // Se Emergência/Veterinário não for encontrado
                if (buscarVeterinarioEmergencia == null)
                {
                    return NotFound();
                }

                // Emergência associada à veterinário encontrada e alterada
                var veterinarioEmergenciaAlterado = repositorio.Update(id, veterinarioEmergencia);
                return Ok(veterinarioEmergencia);
            }
            catch (System.Exception ex)
            {

                // StatusCode 500 = erro de servidor
                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });
            }
        }

        /// <summary>
        /// Exclui uma emergência associada a um veterinário da aplicação
        /// </summary>
        /// <param name="id">Id da associação</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            // TryCatch - Tratamento de exceção
            try
            {
                // Verifica se existe a Emergência/Veterinário a ser excluído
                var buscarVeterinarioEmergencia = repositorio.GetById(id);

                // Se Emergência/Veterinário não for encontrado
                if (buscarVeterinarioEmergencia == null)
                {
                    return NotFound();
                }

                // Emergência/Veterinário encontrado e excluído
                repositorio.Delete(id);

                return Ok(new
                {
                    msg = "Emergência de veterinário excluída com sucesso."
                });
            }

            catch (System.Exception ex)
            {

                // StatusCode 500 = erro de servidor
                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });
            }
        }
    }
}

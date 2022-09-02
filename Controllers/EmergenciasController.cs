using APISistemaVeterinario.Models;
using APISistemaVeterinario.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APISistemaVeterinario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergenciasController : ControllerBase
    {
        // Cria instância do repositório
        private EmergenciaRepository repositorio = new EmergenciaRepository();

        //POST - Cadastrar
        /// <summary>
        /// Cadastra emergência na aplicação
        /// </summary>
        /// <param name="emergencia">Dados da emergência</param>
        /// <returns>Dados da emergência cadastrada</returns>
        [HttpPost]
        public IActionResult Cadastrar(Emergencia emergencia)
        {   // Tratamento de exceção
            try
            {
                
                repositorio.Insert(emergencia);
                return Ok(emergencia);

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
        /// Lista as emergências da aplicação 
        /// </summary>
        /// <returns>Lista de emergências</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {

                var emergencias = repositorio.GetAll();
                return Ok(emergencias);
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
        /// Altera os dados de uma emergência
        /// </summary>
        /// <param name="id">Id da emergência</param>
        /// <param name="emergencia">Todas as informações da emergência</param>
        /// <returns>Emergência alterada</returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Emergencia emergencia)
        {
            try
            {

                // Verifica por id se existe a emergência a ser alterada
                var buscarEmergencia = repositorio.GetById(id);

                // Emergência não encontrada
                if (buscarEmergencia == null)
                {
                    return NotFound();
                }

                // Emergência encontrada e alterada
                var clienteAlterado = repositorio.Update(id, emergencia);
                return Ok(emergencia);

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
        /// Exclui uma emergência da aplicação
        /// </summary>
        /// <param name="id">Id da emergência</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {

                // Verifica se existe a emergência a ser excluída
                var buscarEmergencia = repositorio.GetById(id);

                // Emergência não encontrada
                if (buscarEmergencia == null)
                {
                    return NotFound();
                }

                // Emergência encontrada e excluída
                repositorio.Delete(id);

                return Ok(new
                {
                    msg = "Emergência excluída com sucesso."
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

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
    public class ConsultasController : ControllerBase
    {
        private ConsultaRepository repositorio = new ConsultaRepository();

        //POST - Cadastrar
        /// <summary>
        /// Cadastra consulta na aplicação
        /// </summary>
        /// <param name="consulta">Dados da consulta</param>
        /// <returns>Dados da consulta cadastrada</returns>
        [HttpPost]
        public IActionResult Cadastrar(Consulta consulta)
        {   // Tratamento de exceção
            try
            {

                repositorio.Insert(consulta);
                return Ok(consulta);
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
        /// Lista as consultas da aplicação 
        /// </summary>
        /// <returns>Lista de consultas</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {

                var consultas = repositorio.GetAll();
                return Ok(consultas);

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
        /// Altera os dados de uma consulta
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <param name="consulta">Todas as informações da consulta</param>
        /// <returns>Consulta alterada</returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Consulta consulta)
        {
            try
            {
                // Verifica por id se existe a consulta a ser alterada
                var buscarConsulta = repositorio.GetById(id);

                // Se Consulta não for encontrada
                if (buscarConsulta == null)
                {
                    return NotFound();
                }

                // Cliente encontrado e alterado
                var consultaAlterada = repositorio.Update(id, consulta);
                return Ok(consulta);
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
        /// Exclui uma consulta da aplicação
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {

                // Verifica se existe a consulta a ser excluída
                var buscarConsulta = repositorio.GetById(id);

                // Se consulta não for encontrada
                if (buscarConsulta == null)
                {
                    return NotFound();
                }

                // Consulta encontrada e excluída
                repositorio.Delete(id);
                return Ok(new
                {
                    msg = "Consulta excluída com sucesso."
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

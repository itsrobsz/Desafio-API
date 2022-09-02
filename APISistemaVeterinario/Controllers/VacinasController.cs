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
    public class VacinasController : ControllerBase
    {
        // Cria instância do repositório
        private VacinaRepository repositorio = new VacinaRepository();

        //POST - Cadastrar
        /// <summary>
        /// Cadastra vacina na aplicação
        /// </summary>
        /// <param name="vacina">Dados da vacina</param>
        /// <returns>Dados da vacina cadastrada</returns>
        [HttpPost]
        public IActionResult Cadastrar(Vacina vacina)
        {   
            // TryCatch - Tratamento de exceção
            try
            {
                repositorio.Insert(vacina);
                return Ok(vacina);
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
        /// Lista as vacinas da aplicação 
        /// </summary>
        /// <returns>Lista de vacinas</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var vacinas = repositorio.GetAll();
                return Ok(vacinas);
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
        /// Altera os dados de uma vacina
        /// </summary>
        /// <param name="id">Id da emergencia</param>
        /// <param name="vacina">Todas as informações da vacina</param>
        /// <returns>Vacina alterada</returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Vacina vacina)
        {
            // TryCatch - Tratamento de exceção
            try
            {
                // Verifica por id se existe a vacina a ser alterada
                var buscarVacina = repositorio.GetById(id);

                // Se vacina não for encontrada
                if (buscarVacina == null)
                {
                    return NotFound();
                }
                // Cliente encontrado e alterado
                var vacinaAlterada = repositorio.Update(id, vacina);
                return Ok(vacina);
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
        /// Exclui uma vacina da aplicação
        /// </summary>
        /// <param name="id">Id da vacina</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                // Verifica se existe a vacina a ser excluída
                var buscarVacina = repositorio.GetById(id);

                // Vacina não encontrada
                if (buscarVacina == null)
                {
                    return NotFound();
                }

                // Vacina encontrada e excluída
                repositorio.Delete(id);
                return Ok(new
                {
                    msg = "Vacina excluída com sucesso."
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

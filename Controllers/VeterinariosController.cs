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
    public class VeterinariosController : ControllerBase
    {
        private VeterinarioRepository repositorio = new VeterinarioRepository();

        //POST - Cadastrar
        /// <summary>
        /// Cadastra veterinário na aplicação
        /// </summary>
        /// <param name="veterinario">Dados do veterinário</param>
        /// <returns>Dados do veterinário cadastrado</returns>
        [HttpPost]
        public IActionResult Cadastrar(Veterinario veterinario)
        {  
            // TryCatch - Tratamento de exceção
            try
            {

                repositorio.Insert(veterinario);
                return Ok(veterinario);

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
        /// Lista os veterinários da aplicação 
        /// </summary>
        /// <returns>Lista de veterinários</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var veterinarios = repositorio.GetAll();
                return Ok(veterinarios);
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
        /// Altera os dados de um veterinário
        /// </summary>
        /// <param name="id">Id do veterinário</param>
        /// <param name="veterinario">Todas as informações do veterinário</param>
        /// <returns>Veterinário alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Veterinario veterinario)
        {
            try
            {
                // Verifica por id se existe o veterinário a ser alterado
                var buscarVeterinario = repositorio.GetById(id);

                // Se cliente não for encontrado
                if (buscarVeterinario == null)
                {
                    return NotFound();
                }

                // Cliente encontrado e alterado
                var veterinarioAlterado = repositorio.Update(id, veterinario);
                return Ok(veterinario);
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
        /// Exclui um veterinário da aplicação
        /// </summary>
        /// <param name="id">Id do veterinário</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                // Verifica se existe o veterinário a ser excluído
                var buscarVeterinario = repositorio.GetById(id);

                // Veterinário não encontrado
                if (buscarVeterinario == null)
                {
                    return NotFound();
                }

                // Veterinário encontrado e excluído
                repositorio.Delete(id);
                return Ok(new
                {
                    msg = "Veterinário excluído com sucesso."
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

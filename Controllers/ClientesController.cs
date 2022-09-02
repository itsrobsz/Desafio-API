using APISistemaVeterinario.Models;
using APISistemaVeterinario.Repositories;
using APISistemaVeterinario.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APISistemaVeterinario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        // Cria instância do repositório
        private ClienteRepository repositorio = new ClienteRepository();

        //POST - Cadastrar
        /// <summary>
        /// Cadastra cliente na aplicação
        /// </summary>
        /// <param name="cliente">Dados do cliente</param>
        /// <returns>Dados do cliente cadastrado</returns>
        [HttpPost]
        public IActionResult Cadastrar([FromForm] Cliente cliente, IFormFile arquivo)
        {   
            // TryCatch - Tratamento de exceção
            try
            {
                // #region - Separa por bloco de informações
                #region Upload de Imagem
                string[] extensoesPermitidas = { "jpeg", "jpg", "png", "svg" };
                string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas, "Images");

                // Verifica existência do arquivo
                if (uploadResultado == "")
                {
                    return BadRequest("Arquivo não encontrado ou extensão não permitida.");
                }

                // Arquivo encontrado
                cliente.Imagem = uploadResultado;
                #endregion

                repositorio.Insert(cliente);
                return Ok(cliente);
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
        /// Lista os clientes da aplicação 
        /// </summary>
        /// <returns>Lista de clientes</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var clientes = repositorio.GetAll();
                return Ok(clientes);
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
        /// Altera os dados de um cliente
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <param name="cliente">Todas as informações do cliente</param>
        /// <returns>Cliente alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, [FromForm] Cliente cliente, IFormFile arquivo)
        {
            try
            {

                //#region - Separa por bloco de informações
                #region Upload de Imagem
                string[] extensoesPermitidas = { "jpeg", "jpg", "png", "svg" };
                string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas, "Images");

                // Verifica existência do arquivo
                if (uploadResultado == "")
                {
                    return BadRequest("Arquivo não encontrado ou extensão não permitida.");
                }

                // Arquivo encontrado
                cliente.Imagem = uploadResultado;
                #endregion

                // Verifica por id se existe o cliente a ser alterado
                var buscarCliente = repositorio.GetById(id);

                // Se cliente não for encontrado
                if (buscarCliente == null)
                {
                    return NotFound();
                }
                // Cliente encontrado e alterado
                var clienteAlterado = repositorio.Update(id, cliente);
                return Ok(cliente);
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
        /// Exclui um cliente da aplicação
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {   
                // Verifica se existe o cliente a ser excluído
                var buscarCliente = repositorio.GetById(id);

                // Cliente não encontrado
                if (buscarCliente == null)
                {
                    return NotFound();
                }

                // Cliente encontrado e excluído
                repositorio.Delete(id);

                return Ok(new
                {
                    msg = "Cliente excluído com sucesso."
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

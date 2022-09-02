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
    public class AnimaisController : ControllerBase
    {
        private AnimalRepository repositorio = new AnimalRepository();

        //POST - Cadastrar
        /// <summary>
        /// Cadastra animal na aplicação
        /// </summary>
        /// <param name="animal">Dados do animal</param>
        /// <returns>Dados do animal cadastrado</returns>
        [HttpPost]
        public IActionResult Cadastrar(Animal animal)
        {   // Tratamento de exceção
            try
            {

                repositorio.Insert(animal);
                return Ok(animal);
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
        /// Lista os animais da aplicação 
        /// </summary>
        /// <returns>Lista de animais</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {

                var animais = repositorio.GetAll();
                return Ok(animais);

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
        /// Altera os dados de um animal
        /// </summary>
        /// <param name="id">Id do animal</param>
        /// <param name="animal">Todas as informações do animal</param>
        /// <returns>Animal alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Animal animal)
        {
            try
            {

                // Verifica por id se existe o animal a ser alterado
                var buscarAnimal = repositorio.GetById(id);

                // Se o Animal não for encontrado
                if (buscarAnimal == null)
                {
                    return NotFound();
                }

                // Animal encontrado e alterado
                var animalAlterado = repositorio.Update(id, animal);
                return Ok(animal);
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
        /// Exclui um animal da aplicação
        /// </summary>
        /// <param name="id">Id do animal</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                // Verifica se existe o animal a ser excluído
                var buscarAnimal = repositorio.GetById(id);

                // Se Animal não for encontrado
                if (buscarAnimal == null)
                {
                    return NotFound();
                }

                // Animal encontrado e excluído
                repositorio.Delete(id);

                return Ok(new
                {
                    msg = "Animal excluído com sucesso."
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

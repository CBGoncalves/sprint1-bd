using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using Senai.InLock.WebApi.DataBaseFirst.Repositories;

namespace Senai.InLock.WebApi.DataBaseFirst.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos estudios
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _estudioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IEstudioRepository _estudioRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_estudioRepository.Listar());
        }

        /// <summary>
        /// Busca um estúdio através do ID
        /// </summary>
        /// <param name="id">ID do estúdio que será buscado</param>
        /// <returns>Um estúdio buscado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_estudioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Estudios novoEstudio)
        {
            // Faz a chamada para o método
            _estudioRepository.Cadastrar(novoEstudio);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deletar um estúdio
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um status code com uma mensagem de sucesso ou erro</returns>
        [HttpDelete ("{id}")]
        public IActionResult Delete(int id)
        {
            Estudios estudioBuscado = _estudioRepository.BuscarPorId(id);

            // Verifica se o estudio foi encontrado
            if (estudioBuscado != null)
            {
                // Caso seja, faz a chamada para o método .Deletar()
                _estudioRepository.Deletar(id);

                // e retorna um status code 200 - Ok com uma mensagem de sucesso
                return Ok($"O estudio {id} foi deletado com sucesso!");
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum estudio encontrado para o identificador informado");

        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Estudios estudio, int id)
        {
            try
            {
                Estudios JogoBuscado = _estudioRepository.BuscarPorId(id);
                if (JogoBuscado == null)
                    return NotFound();

                estudio.IdEstudio = id;
                _estudioRepository.Atualizar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
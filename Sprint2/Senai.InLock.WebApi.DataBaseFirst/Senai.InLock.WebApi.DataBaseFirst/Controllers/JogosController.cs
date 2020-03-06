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
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _jogoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IJogoRepository _jogoRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos e um status code 200 - Ok</returns>
        /// dominio/api/Jogos
        //[Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Get()
        {
            // Faz a chamada para o método .Listar()
            // Retorna a lista e um status code 200 - Ok
            return Ok(_jogoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(Jogos novoJogo)
        {
            // Faz a chamada para o método .Cadastrar();
            _jogoRepository.Cadastrar(novoJogo);

            // Retorna o status code 201 - Created com a URI e o objeto cadastrado
            return Created("http://localhost:5000/api/Funcionarios", novoJogo);
        }

        /// <summary>
        /// Busca um jogo através do seu ID
        /// </summary>
        /// <param name="id">ID do jogo que será buscado</param>
        /// <returns>Um jogo buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/Jogos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto jogoBuscado que irá receber o jogo buscado no banco de dados
            Jogos jogoBuscado = _jogoRepository.BuscarPorId(id);

            // Verifica se algum jogo foi encontrado
            if (jogoBuscado != null)
            {
                // Caso seja, retorna os dados buscados e um status code 200 - Ok
                return Ok(jogoBuscado);
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum jogo encontrado para o identificador informado");
        }

        /// <summary>
        /// Atualiza um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será atualizado</param>
        /// <param name="jogoAtualizado">Objeto jogoAtualizado que será alterado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Jogos/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, Jogos jogoAtualizado)
        {
            // Cria um objeto jogoBuscado que irá receber o jogo buscado no banco de dados
            Jogos jogoBuscado = _jogoRepository.BuscarPorId(id);

            // Verifica se algum jogo foi encontrado
            if (jogoBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .Atualizar();
                    _jogoRepository.Atualizar(id, jogoAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna BadRequest e o erro
                    return BadRequest(erro);
                }

            }

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para representar que houve erro
            return NotFound
                (
                    new
                    {
                        mensagem = "Jogo não encontrado",
                        erro = true
                    }
                );
        }

        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="id">ID do jogo que será deletado</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Jogos/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Cria um objeto jogoBuscado que irá receber o jogo buscado no banco de dados
            Jogos jogoBuscado = _jogoRepository.BuscarPorId(id);

            // Verifica se o jogo foi encontrado
            if (jogoBuscado != null)
            {
                // Caso seja, faz a chamada para o método .Deletar()
                _jogoRepository.Deletar(id);

                // e retorna um status code 200 - Ok com uma mensagem de sucesso
                return Ok($"O jogo {id} foi deletado com sucesso!");
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum jogo encontrado para o identificador informado");
        }

        /// <summary>
        /// Lista todos os jogos de um determinado estúdio
        /// </summary>
        /// <param name="idEstudio">ID do estúdio do qual os jogos serão listados</param>
        /// <returns>Uma lista de jogos de um determinado estúdio</returns>
        [HttpGet("Estudio/{idEstudio}")]
        public IActionResult GetJogosEstudios(int idEstudio)
        {
            // Faz a chamada para o método .Listar()
            // Retorna a lista e um status code 200 - Ok
            return Ok(_jogoRepository.ListarPorEstudio(idEstudio));
        }
    }
}
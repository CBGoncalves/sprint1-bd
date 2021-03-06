﻿using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório JogoRepository
    /// </summary>
    interface IJogoRepository
    {
        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        List<Jogos> Listar();

        /// <summary>
        /// Busca um jogo através do ID
        /// </summary>
        /// <param name="id">ID do jogo que será buscado</param>
        /// <returns>Um jogo buscado</returns>
        Jogos BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo que será cadastrado</param>
        void Cadastrar(Jogos novoJogo);

        /// <summary>
        /// Atualiza um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será atualizado</param>
        /// <param name="jogoAtualizado">Objeto jogoAtualizado que será alterado</param>
        void Atualizar(int id, Jogos jogoAtualizado);

        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os jogos de um determinado estúdio
        /// </summary>
        /// <param name="id">ID do estúdio do qual serão buscados os jogos</param>
        /// <returns></returns>
        List<Jogos> ListarPorEstudio(int id);
    }
}

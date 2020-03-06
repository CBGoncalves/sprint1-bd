using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class JogoRepository : IJogoRepository
    {

        InLockContext ctx = new InLockContext();

        public void Atualizar(int id, Jogos jogoAtualizado)
        {
            throw new NotImplementedException();
        }

        public Jogos BuscarPorId(int id)
        {
            return ctx.Jogos.FirstOrDefault(e => e.IdJogo == id);
        }

        public void Cadastrar(Jogos novoJogo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Jogos> Listar()
        {
            return ctx.Jogos.ToList();
        }

        public List<Jogos> ListarPorEstudio(int id)
        {
            throw new NotImplementedException();
        }
    }
}

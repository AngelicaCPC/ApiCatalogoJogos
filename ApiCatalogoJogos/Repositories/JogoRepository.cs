using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>();

        public JogoRepository()
        {
            MontarJogos();
        }
        private void MontarJogos()
        {
            int contador = 5;

            var idguid = Guid.NewGuid();
            jogos.Add(idguid, new Jogo(idguid) {Nome = "Fifa 21", Produtora = "EA", Preco = 200});
            var idguid2 = Guid.NewGuid();
            jogos.Add(idguid, new Jogo(idguid2) { Nome = "Fifa 20", Produtora = "EA", Preco = 190 });
            var idguid3 = Guid.NewGuid();
            jogos.Add(idguid, new Jogo(idguid3) { Nome = "Fifa 19", Produtora = "EA", Preco = 180 });
            var idguid4 = Guid.NewGuid();
            jogos.Add(idguid, new Jogo(idguid4) { Nome = "Fifa 18", Produtora = "EA", Preco = 170 });
            var idguid5 = Guid.NewGuid();
            jogos.Add(idguid, new Jogo(idguid5) { Nome = "Street Fighter V", Produtora = "Capcom", Preco = 80 });
            var idguid6 = Guid.NewGuid();
            jogos.Add(idguid, new Jogo(idguid6) { Nome = "Grand Theft Auto V", Produtora = "Rockstar", Preco = 190 });

        }

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();
            foreach (var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }
            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco.
        }

       

        

       

    }
}

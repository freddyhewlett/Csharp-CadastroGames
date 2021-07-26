using System;
using System.Collections.Generic;
using Cadastro.Jogos.Interfaces;

namespace Cadastro.Jogos
{
    public class JogoRepositorio : IRepositorio<Jogo>       //implementação da interface 
    {
        private List<Jogo> listaJogo = new List<Jogo>();
        public void Atualiza(int id, Jogo entidade)
        {
            listaJogo[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaJogo[id].Excluir();
        }

        public void Insere(Jogo entidade)
        {
            listaJogo.Add(entidade);
        }

        public List<Jogo> Lista()
        {
            return listaJogo;
        }

        public int ProximoId()
        {
            return listaJogo.Count;
        }

        public Jogo RetornaPorId(int id)
        {
            return listaJogo[id];
        }
    }
}
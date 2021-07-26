using System;

namespace Cadastro.Jogos
{
    public class Jogo : EntidadeBase    // herda a propriedade ID - 
    {
        // propriedades da classe
        private Genero Genero {get;set;}
        private Genero Genero2 {get;set;}
        private string Titulo {get;set;}
        private string Descricao {get;set;}
        private int Ano {get;set;}
        private bool Excluido {get;set;}


        public Jogo(int id, Genero genero, Genero genero2, string titulo, string descricao, int ano) // construtor da classe - acesso variaveis private
        {
            this.Id = id;
            this.Genero = genero;
            this.Genero2 = genero2;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: " + this.Genero + " com elementos de " + this.Genero2 + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano + Environment.NewLine;
            retorno += "Excluido" + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()       // informa na visualização se o jogo foi excluido
        {
            return this.Excluido;
        }

        public void Excluir()       // controla a exclusão de registros para não repetir o ID
        {
            this.Excluido = true;
        }
    }
}
using System;

namespace Dio.Series
{
    public class Series : EntidadeBase
    {
        private Genero Genero {get; set;}
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private int Ano {get; set;}
        private bool Excluido {get; set;}

        public Series(int Id, Genero genero, string Titulo, string Descricao, int Ano)
        {
            this.Id = Id;
            this.Genero = Genero;
            this.Titulo = Titulo;
            this.Descricao = Descricao;
            this.Ano = Ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string Retorno = "";
            Retorno += "Genero: " + this.Genero + Environment.NewLine;
            Retorno += "Título: " + this.Titulo + Environment.NewLine;
            Retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            Retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            Retorno += "Excluído: " + this.Ano + Environment.NewLine;
            return Retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public bool RetornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir(){
            this.Excluido = true;
        }
    }
}
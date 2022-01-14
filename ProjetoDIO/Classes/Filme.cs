using System;

namespace ProjetoDIO
{
  public class Filme : EntidadeBase
  {
    // Atributos
    private Genero Genero { get; set; }
    private string Titulo { get; set; }
    private string Descricao { get; set; }
    private bool Visto { get; set; }
    private bool Excluido { get; set; }

    // Métodos
    public Filme(int id, Genero genero, string titulo, string descricao)
    {
      this.Id = id;
      this.Genero = genero;
      this.Titulo = titulo;
      this.Descricao = descricao;
      this.Visto = false;
      this.Excluido = false;
    }

    public override string ToString()
    {
      string retorno = "";
      retorno += "Genero: " + this.Genero + Environment.NewLine;
      retorno += "Titulo: " + this.Titulo + Environment.NewLine;
      retorno += "Descrição: " + this.Descricao + Environment.NewLine;
      retorno += "Visto: " + this.Visto + Environment.NewLine;
      retorno += "Excluido: " + this.Excluido;
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
    public bool retornaVisto()
    {
      return this.Visto;
    }
    public void Ver()
    {
      this.Visto = true;
    }
    public bool retornaExcluido()
    {
      return this.Excluido;
    }
    public void Excluir()
    {
      this.Excluido = true;
    }
  }
}
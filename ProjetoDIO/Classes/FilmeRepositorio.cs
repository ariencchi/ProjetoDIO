using System;
using System.Collections.Generic;
using ProjetoDIO.Interfaces;

namespace ProjetoDIO
{
  // Repositório lista
  public class FilmeRepositorio : IRepositorio<Filme>
  {
    private List<Filme> listaFilme = new List<Filme>();

    // OPÇÕES DO MENU
    // ** Lista **
    public Filme RetornaPorId(int id)
    {
      return listaFilme[id];
    }
    public List<Filme> Lista()
    {
      return listaFilme;
    }
    // ** Insere **
    public void Insere(Filme objeto)
    {
      listaFilme.Add(objeto);
    }
    // ** Atualiza **
    public void Atualiza(int id, Filme objeto)
    {
      listaFilme[id] = objeto;
    }
    // ** Exclui **
    public void Exclui(int id)
    {
      listaFilme[id].Excluir();
    }
    // ** Visto **
    public void Visto(int id)
    {
      listaFilme[id].Ver();
    }
    // ** Contador do Id
    public int ProximoId()
    {
      return listaFilme.Count;
    }
  }
}
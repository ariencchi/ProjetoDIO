using System;

namespace ProjetoDIO
{
  class Program
  {
    static FilmeRepositorio repositorio = new FilmeRepositorio();
    static void Main(string[] args)
    {
      // INÍCIO DO PROGRAMA
      // Retorna a opção do usuário e faz algo
      Console.WriteLine();
      Console.WriteLine("Bem vindo! Crie e organize sua lista de filmes!");
      Console.WriteLine();
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarFilmes();
            break;
          case "2":
            InserirFilme();
            break;
          case "3":
            AtualizarFilme();
            break;
          case "4":
            VerFilme();
            break;
          case "5":
            ExcluirFilme();
            break;
          case "6":
            VisualizarFilme();
            break;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }
        opcaoUsuario = ObterOpcaoUsuario();
      }
      // FIM DO PROGRAMA
      Console.WriteLine("Bom filme! :)");
      Console.ReadLine();
    }

    // OPÇÕES DO PROGRAMA
    // ** Listar **
    private static void ListarFilmes()
    {
      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhum filme cadastrado.");
        Console.WriteLine();
        return;
      }

      foreach (var filme in lista)
      {
        var excluido = filme.retornaExcluido();
        var visto = filme.retornaVisto();

        Console.WriteLine("#ID {0}: - {1} {2} {3}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""), (visto ? "*Visto*" : ""));
      }
      Console.WriteLine();
    }
    // ** Inserir **
    private static void InserirFilme()
    {
      Console.WriteLine("Inserir novo filme");

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.WriteLine();
      Console.Write("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o título: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite uma descrição: ");
      string entradaDescricao = Console.ReadLine();

      Filme novoFilme = new Filme(id: repositorio.ProximoId(),
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    descricao: entradaDescricao);

      repositorio.Insere(novoFilme);
      Console.WriteLine();
    }
    // ** Atualizar **
    private static void AtualizarFilme()
    {
      Console.Write("Digite o id do filme: ");
      int indiceFilme = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.WriteLine();
      Console.Write("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título do Filme: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite a Descrição do Filme: ");
      string entradaDescricao = Console.ReadLine();

      Filme atualizaFilme = new Filme(id: indiceFilme,
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    descricao: entradaDescricao);

      repositorio.Atualiza(indiceFilme, atualizaFilme);
      Console.WriteLine();
    }
    // ** Excluir filme **
    private static void ExcluirFilme()
    // ** Marca como "Visto" **
    {
      Console.Write("Digite o id do filme: ");
      int indiceFilme = int.Parse(Console.ReadLine());

      repositorio.Exclui(indiceFilme);
    }
    private static void VerFilme()
    {
      Console.Write("Digite o id do filme: ");
      int indiceFilme = int.Parse(Console.ReadLine());

      repositorio.Visto(indiceFilme);
    }
    // ** Visualizar filme **
    private static void VisualizarFilme()
    {
      Console.Write("Digite o id do filme: ");
      int indiceFilme = int.Parse(Console.ReadLine());

      var filme = repositorio.RetornaPorId(indiceFilme);

      Console.WriteLine(filme);
      Console.ReadLine();
    }

    // ** MENU **
    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar filmes");
      Console.WriteLine("2- Inserir novo filme");
      Console.WriteLine("3- Alterar informação do filme");
      Console.WriteLine("4- Marcar como 'Visto'");
      Console.WriteLine("5- Excluir filme");
      Console.WriteLine("6- Visualizar filme");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
      Console.WriteLine();
    }
  }
}
using System;
using Dio.Series;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        public static SerieRepositorio Repositorio { get => repositorio; set => repositorio = value; }

        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                       VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                OpcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado Por Utilizar Nossos Serviços.");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
            Console.WriteLine("Nenhuma Série Cadastrada!");
            return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine("#ID {0} : - {1} - {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero))) 
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(Id: indiceSerie,
                                              genero: (Genero)entradaGenero,
                                              Titulo: entradaTitulo,
                                              Ano: entradaAno,
                                              Descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Série.");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine(" {0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Series NovaSerie = new Series(Id: repositorio.ProximoId(), genero: (Genero)entradaGenero,
                                                                Titulo: entradaTitulo, Ano: entradaAno, 
                                                                Descricao: entradaDescricao);
          repositorio.Insere(NovaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu Dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Séries:");
            Console.WriteLine("2 - Inserir nova Série:");
            Console.WriteLine("3 - Atualizar Série:");
            Console.WriteLine("4 - Excluir Série:");
            Console.WriteLine("5 - Visualizar Série:");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair"); 
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;

        }
    }
}

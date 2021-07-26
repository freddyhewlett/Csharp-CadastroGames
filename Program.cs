using System;

namespace Cadastro.Jogos
{
    class Program
    {
        static JogoRepositorio repositorio = new JogoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarJogo();
                        break;
                    case "2":
                        InserirJogo();
                        break;
                    case "3":
                        AtualizarJogo();
                        break;
                    case "4":
                        ExcluirJogo();
                        break;
                    case "5":
                        VisualizarJogo();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            Console.WriteLine("Obrigado por Participar!");
            Console.ReadLine();
        }

        private static void VisualizarJogo()
        {
            Console.Write("Digite o ID do jogo: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            var jogo = repositorio.RetornaPorId(indiceJogo);

            Console.WriteLine(jogo);
        }

        private static void ExcluirJogo()
        {
            Console.Write("Digite o ID do jogo: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            Console.Write("Deseja mesmo excluir este jogo? S/N: ");
            string confirmaExclui = Console.ReadLine();

            if (confirmaExclui.ToUpper() == "S")
            {
                repositorio.Exclui(indiceJogo);
            }
        }

        private static void AtualizarJogo()
        {
            Console.Write("Digite o ID do jogo: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
            }
            Console.Write("Digite o codigo do genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o codigo de um genero secundario: ");
            int entradaGenero2 = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo do jogo: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento do jogo: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Faça uma breve descrição do jogo: ");
            string entradaDescricao = Console.ReadLine();

            Jogo atualizarJogo = new Jogo(id: indiceJogo,
                                            genero: (Genero)entradaGenero,
                                            genero2: (Genero)entradaGenero2,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorio.Atualiza(indiceJogo, atualizarJogo);
        }

        private static void ListarJogo()
        {
            Console.WriteLine("Listar jogos");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum jogo cadastrado.");
                return;
            }
            foreach (var jogo in lista)
            {
                var excluido = jogo.retornaExcluido();

                Console.WriteLine($"#ID {jogo.retornaId()}: - {jogo.retornaTitulo()} {(excluido ? "** Cadastro Excluido **" : " ")}");
            }
        }

        private static void InserirJogo()
        {
            Console.WriteLine("Inserir novo jogo");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
            }
            Console.Write("Digite o codigo do genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o codigo de um genero secundario: ");
            int entradaGenero2 = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo do jogo: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento do jogo: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Faça uma breve descrição do jogo: ");
            string entradaDescricao = Console.ReadLine();

            Jogo novoJogo = new Jogo(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    genero2: (Genero)entradaGenero2,
                                    titulo: entradaTitulo,
                                    descricao: entradaDescricao,
                                    ano: entradaAno);
            repositorio.Insere(novoJogo);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine("*** Seu cadastro de jogos personalizado!! ***");
            Console.WriteLine("*********************************************");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar jogos cadastrados");
            Console.WriteLine("2- Cadastrar novo jogo");
            Console.WriteLine("3- Atualizar cadastro do jogo");
            Console.WriteLine("4- Excluir jogo");
            Console.WriteLine("5- Visualizar informações do jogo");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ModificarJogo()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
            }
            Console.Write("Digite o codigo do genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o codigo de um genero secundario: ");
            int entradaGenero2 = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo do jogo: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento do jogo: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Faça uma breve descrição do jogo: ");
            string entradaDescricao = Console.ReadLine();
        }
    }
}

using System;

namespace EstacionamentoDIO
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal precoInicial = 0;
            decimal precoPorHora = 0;

            Console.WriteLine("Seja bem-vindo ao sistema de estacionamento!");
            Console.WriteLine("Digite o preço inicial:");
            precoInicial = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Digite o preço por hora:");
            precoPorHora = Convert.ToDecimal(Console.ReadLine());

            Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

            bool exibirMenu = true;
            while (exibirMenu)
            {
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Encerrar");
                Console.WriteLine("===================================");
                Console.Write("Escolha uma opção: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        estacionamento.AdicionarVeiculo();
                        break;

                    case "2":
                        estacionamento.RemoverVeiculo();
                        break;

                    case "3":
                        estacionamento.ListarVeiculos();
                        break;

                    case "4":
                        exibirMenu = false;
                        Console.WriteLine("Programa encerrado. Obrigado!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (exibirMenu)
                {
                    Console.WriteLine("\nPressione uma tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
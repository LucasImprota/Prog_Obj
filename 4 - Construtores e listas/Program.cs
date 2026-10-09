using System;
using System.Collections.Generic;

namespace Banco
{
    public class ContaCorrente
    {
        // Atributos
        public int Agencia { get; set; }
        public string NumeroConta { get; set; }
        public string NomeTitular { get; set; }

        // Apenas leitura
        public double Saldo { get; private set; }

        // Construtor parametrizado
        public ContaCorrente(int agencia, string numeroConta, string nomeTitular, double saldo)
        {
            Agencia = agencia;
            NumeroConta = numeroConta;
            NomeTitular = nomeTitular;
            Saldo = saldo;
        }

        // Método de saque
        public void Saque(double valor)
        {
            if (valor > Saldo)
            {
                throw new Exception("Saldo insuficiente.");
            }

            Saldo -= valor;
        }

        // Método de depósito
        public void Deposito(double valor)
        {
            Saldo += valor;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<ContaCorrente> contas = new List<ContaCorrente>();

            int opcao = 0;

            while (opcao != 4)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1 - Cadastrar Conta");
                Console.WriteLine("2 - Listar Contas");
                Console.WriteLine("3 - Depositar em Todas as Contas");
                Console.WriteLine("4 - Sair");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:

                        Console.Write("\nDigite a agência: ");
                        int agencia = int.Parse(Console.ReadLine());

                        Console.Write("Digite o número da conta: ");
                        string numeroConta = Console.ReadLine();

                        Console.Write("Digite o nome do titular: ");
                        string nomeTitular = Console.ReadLine();

                        Console.Write("Digite o saldo inicial: ");
                        double saldo = double.Parse(Console.ReadLine());

                        ContaCorrente conta = new ContaCorrente(
                            agencia,
                            numeroConta,
                            nomeTitular,
                            saldo
                        );

                        contas.Add(conta);

                        Console.WriteLine("\nConta cadastrada com sucesso!");
                        break;

                    case 2:

                        Console.WriteLine("\n=== LISTA DE CONTAS ===");

                        foreach (ContaCorrente c in contas)
                        {
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("Agência: " + c.Agencia);
                            Console.WriteLine("Conta: " + c.NumeroConta);
                            Console.WriteLine("Titular: " + c.NomeTitular);
                            Console.WriteLine("Saldo: R$ " + c.Saldo);
                        }

                        break;

                    case 3:

                        Console.Write("\nDigite o valor do depósito: ");
                        double valorDeposito = double.Parse(Console.ReadLine());

                        foreach (ContaCorrente c in contas)
                        {
                            c.Deposito(valorDeposito);
                        }

                        Console.WriteLine("\nDepósito realizado em todas as contas!");
                        break;

                    case 4:

                        Console.WriteLine("\nPrograma encerrado.");
                        break;

                    default:

                        Console.WriteLine("\nOpção inválida.");
                        break;
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
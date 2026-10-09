using System;

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
                throw new Exception("Saldo insuficiente para realizar o saque.");
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
            try
            {
                // Criando a conta
                ContaCorrente conta = new ContaCorrente(
                    1234,
                    "98765-0",
                    "João Silva",
                    1000.00
                );

                Console.WriteLine("=== DADOS DA CONTA ===");
                Console.WriteLine("Agência: " + conta.Agencia);
                Console.WriteLine("Conta: " + conta.NumeroConta);
                Console.WriteLine("Titular: " + conta.NomeTitular);
                Console.WriteLine("Saldo Inicial: R$ " + conta.Saldo);

                // Depósito
                conta.Deposito(500);

                Console.WriteLine("\nApós depósito de R$ 500:");
                Console.WriteLine("Saldo Atual: R$ " + conta.Saldo);

                // Saque
                conta.Saque(300);

                Console.WriteLine("\nApós saque de R$ 300:");
                Console.WriteLine("Saldo Atual: R$ " + conta.Saldo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nErro: " + ex.Message);
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
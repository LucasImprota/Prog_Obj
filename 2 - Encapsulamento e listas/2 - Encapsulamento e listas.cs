using System;
using System.Collections.Generic;

namespace CadastroCarros
{
    public class Carro
    {
        private string placa;
        private int anoFabricacao;
        private string marca;
        private string modelo;

        public string Placa
        {
            get { return placa; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A placa é obrigatória.");
                }

                placa = value;
            }
        }

        public int AnoFabricacao
        {
            get { return anoFabricacao; }
            set
            {
                if (value <= 2000)
                {
                    throw new Exception("O ano de fabricação deve ser maior que 2000.");
                }

                anoFabricacao = value;
            }
        }

        public string Marca
        {
            get { return marca; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A marca é obrigatória.");
                }

                marca = value;
            }
        }

        public string Modelo
        {
            get { return modelo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("O modelo é obrigatório.");
                }

                modelo = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Carro> listaCarros = new List<Carro>();
            string continuar = "S";

            Console.WriteLine("=== CADASTRO DE CARROS ===");

            while (continuar.ToUpper() == "S")
            {
                try
                {
                    Carro carro = new Carro();

                    Console.Write("\nDigite a placa: ");
                    carro.Placa = Console.ReadLine();

                    Console.Write("Digite o ano de fabricação: ");
                    carro.AnoFabricacao = int.Parse(Console.ReadLine());

                    Console.Write("Digite a marca: ");
                    carro.Marca = Console.ReadLine();

                    Console.Write("Digite o modelo: ");
                    carro.Modelo = Console.ReadLine();

                    listaCarros.Add(carro);

                    Console.Write("\nDeseja cadastrar outro carro? (S/N): ");
                    continuar = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nErro: " + ex.Message);
                }
            }

            Console.WriteLine("\n=== CARROS CADASTRADOS ===");

            foreach (Carro carro in listaCarros)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Placa: " + carro.Placa);
                Console.WriteLine("Ano de Fabricação: " + carro.AnoFabricacao);
                Console.WriteLine("Marca: " + carro.Marca);
                Console.WriteLine("Modelo: " + carro.Modelo);
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
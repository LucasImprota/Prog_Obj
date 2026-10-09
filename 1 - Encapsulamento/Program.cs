using System;

namespace CadastroCarro
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
            try
            {
                Carro carro = new Carro();

                Console.WriteLine("=== CADASTRO DE CARRO ===");

                Console.Write("Digite a placa: ");
                carro.Placa = Console.ReadLine();

                Console.Write("Digite o ano de fabricação: ");
                carro.AnoFabricacao = int.Parse(Console.ReadLine());

                Console.Write("Digite a marca: ");
                carro.Marca = Console.ReadLine();

                Console.Write("Digite o modelo: ");
                carro.Modelo = Console.ReadLine();

                Console.WriteLine("\n=== RESUMO DO CADASTRO ===");

                Console.WriteLine("Placa: " + carro.Placa);
                Console.WriteLine("Ano de Fabricação: " + carro.AnoFabricacao);
                Console.WriteLine("Marca: " + carro.Marca);
                Console.WriteLine("Modelo: " + carro.Modelo);
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
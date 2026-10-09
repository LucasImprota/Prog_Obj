using System;
using System.Collections.Generic;

namespace EmpresaFuncionarios
{
    // Classe base
    public class Funcionario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Salario { get; set; }

        public virtual double CalculoSalario()
        {
            return Salario;
        }

        public override string ToString()
        {
            return "Código: " + Codigo +
                   "\nNome: " + Nome +
                   "\nSalário Base: R$ " + Salario +
                   "\nSalário Final: R$ " + CalculoSalario();
        }
    }

    // Funcionário da fábrica
    public class FuncionarioFabrica : Funcionario
    {
        public double HoraExtraEmReais { get; set; }

        public override double CalculoSalario()
        {
            return Salario + HoraExtraEmReais;
        }

        public override string ToString()
        {
            return base.ToString() +
                   "\nHora Extra: R$ " + HoraExtraEmReais;
        }
    }

    // Funcionário gerente
    public class FuncionarioGerente : Funcionario
    {
        public double BonusEmReais { get; set; }
        public string Area { get; set; }

        public override double CalculoSalario()
        {
            return Salario + BonusEmReais;
        }

        public override string ToString()
        {
            return base.ToString() +
                   "\nBônus: R$ " + BonusEmReais +
                   "\nÁrea: " + Area;
        }
    }

    // Funcionário vendedor
    public class FuncionarioVendedor : Funcionario
    {
        public double MetaDeVendaMesEmReais { get; set; }
        public double VendasdoMesEmReais { get; set; }
        public int PorcentagemSobreVendas { get; set; }

        public override double CalculoSalario()
        {
            double salarioFinal = Salario;

            if (VendasdoMesEmReais >= MetaDeVendaMesEmReais)
            {
                salarioFinal +=
                    (VendasdoMesEmReais * PorcentagemSobreVendas) / 100;
            }

            return salarioFinal;
        }

        public override string ToString()
        {
            return base.ToString() +
                   "\nMeta do Mês: R$ " + MetaDeVendaMesEmReais +
                   "\nVendas do Mês: R$ " + VendasdoMesEmReais +
                   "\nPorcentagem Sobre Vendas: " +
                   PorcentagemSobreVendas + "%";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            int opcao = 0;

            while (opcao != 5)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1 - Cadastrar Funcionário Fábrica");
                Console.WriteLine("2 - Cadastrar Funcionário Gerente");
                Console.WriteLine("3 - Cadastrar Funcionário Vendedor");
                Console.WriteLine("4 - Listar Funcionários");
                Console.WriteLine("5 - Sair");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:

                        FuncionarioFabrica fabrica =
                            new FuncionarioFabrica();

                        Console.Write("Código: ");
                        fabrica.Codigo =
                            int.Parse(Console.ReadLine());

                        Console.Write("Nome: ");
                        fabrica.Nome =
                            Console.ReadLine();

                        Console.Write("Salário Base: ");
                        fabrica.Salario =
                            double.Parse(Console.ReadLine());

                        Console.Write("Hora Extra em R$: ");
                        fabrica.HoraExtraEmReais =
                            double.Parse(Console.ReadLine());

                        funcionarios.Add(fabrica);

                        Console.WriteLine("\nFuncionário cadastrado!");
                        break;

                    case 2:

                        FuncionarioGerente gerente =
                            new FuncionarioGerente();

                        Console.Write("Código: ");
                        gerente.Codigo =
                            int.Parse(Console.ReadLine());

                        Console.Write("Nome: ");
                        gerente.Nome =
                            Console.ReadLine();

                        Console.Write("Salário Base: ");
                        gerente.Salario =
                            double.Parse(Console.ReadLine());

                        Console.Write("Bônus em R$: ");
                        gerente.BonusEmReais =
                            double.Parse(Console.ReadLine());

                        Console.Write("Área Gerenciada: ");
                        gerente.Area =
                            Console.ReadLine();

                        funcionarios.Add(gerente);

                        Console.WriteLine("\nGerente cadastrado!");
                        break;

                    case 3:

                        FuncionarioVendedor vendedor =
                            new FuncionarioVendedor();

                        Console.Write("Código: ");
                        vendedor.Codigo =
                            int.Parse(Console.ReadLine());

                        Console.Write("Nome: ");
                        vendedor.Nome =
                            Console.ReadLine();

                        Console.Write("Salário Base: ");
                        vendedor.Salario =
                            double.Parse(Console.ReadLine());

                        Console.Write("Meta de Vendas: ");
                        vendedor.MetaDeVendaMesEmReais =
                            double.Parse(Console.ReadLine());

                        Console.Write("Vendas do Mês: ");
                        vendedor.VendasdoMesEmReais =
                            double.Parse(Console.ReadLine());

                        Console.Write("Porcentagem Sobre Vendas: ");
                        vendedor.PorcentagemSobreVendas =
                            int.Parse(Console.ReadLine());

                        funcionarios.Add(vendedor);

                        Console.WriteLine("\nVendedor cadastrado!");
                        break;

                    case 4:

                        Console.WriteLine("\n=== LISTA DE FUNCIONÁRIOS ===");

                        foreach (Funcionario f in funcionarios)
                        {
                            Console.WriteLine("\n---------------------------");
                            Console.WriteLine(f.ToString());
                        }

                        break;

                    case 5:

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
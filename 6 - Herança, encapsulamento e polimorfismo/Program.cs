using System;
using System.Collections.Generic;

namespace CatalogoCameras
{
    // Classe Base
    public class Camera
    {
        // Campos privados
        private string _marca;
        private string _modelo;

        // Propriedades somente leitura
        public string Marca
        {
            get { return _marca; }
        }

        public string Modelo
        {
            get { return _modelo; }
        }

        // Construtor
        public Camera(string marca, string modelo)
        {
            _marca = marca;
            _modelo = modelo;
        }

        // Método virtual
        public virtual void ExibirDetalhes()
        {
            Console.Write("Câmera: " + Marca + " " + Modelo);
        }
    }

    // Classe derivada CameraDigital
    public class CameraDigital : Camera
    {
        // Campo privado
        private double _resolucaoMegapixels;

        // Propriedade somente leitura
        public double ResolucaoMegapixels
        {
            get { return _resolucaoMegapixels; }
        }

        // Construtor
        public CameraDigital(string marca, string modelo, double resolucaoMegapixels)
            : base(marca, modelo)
        {
            _resolucaoMegapixels = resolucaoMegapixels;
        }

        // Sobrescrita do método
        public override void ExibirDetalhes()
        {
            base.ExibirDetalhes();
            Console.WriteLine(" | Resolução: " + ResolucaoMegapixels + " MP");
        }
    }

    // Classe derivada CameraAnalogica
    public class CameraAnalogica : Camera
    {
        // Campo privado
        private string _tipoFilme;

        // Propriedade somente leitura
        public string TipoFilme
        {
            get { return _tipoFilme; }
        }

        // Construtor
        public CameraAnalogica(string marca, string modelo, string tipoFilme)
            : base(marca, modelo)
        {
            _tipoFilme = tipoFilme;
        }

        // Sobrescrita do método
        public override void ExibirDetalhes()
        {
            base.ExibirDetalhes();
            Console.WriteLine(" | Filme: " + TipoFilme);
        }
    }

    // Classe principal
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciando objetos
            CameraDigital cameraDigital = new CameraDigital(
                "Canon",
                "EOS R5",
                45.0
            );

            CameraAnalogica cameraAnalogica = new CameraAnalogica(
                "Leica",
                "M6",
                "35mm"
            );

            // Lista genérica de câmeras
            List<Camera> catalogo = new List<Camera>();

            // Adicionando objetos na lista
            catalogo.Add(cameraDigital);
            catalogo.Add(cameraAnalogica);

            // Exibindo detalhes
            Console.WriteLine("=== CATÁLOGO DE CÂMERAS ===\n");

            foreach (Camera camera in catalogo)
            {
                camera.ExibirDetalhes();
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
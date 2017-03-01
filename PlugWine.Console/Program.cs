using System;
using PlugWine.Pricer;

namespace PlugWine.Console
{
    class Program
    {
        private static Service _service;

        public static Service Service
        {
            get
            {
                if (_service == null)
                {
                    _service = new Service();      
                }
                return _service; 
            }
        }

        static void Main(string[] args)
        {
            RunFirstStep();
            RunSecondStep();

            RunFourthStep();
            RunFifthStep();

            WriteLine("Taper une touche pour finir");
            System.Console.ReadKey();
        }

        private static void RunFifthStep()
        {
            WriteLine("Etape 5 : pricing avec le premier pricer");
            WritePricerOutputs(new Pricer.OtherPricer());
        }

        private static void RunFourthStep()
        {
            WriteLine("Etape 4 : pricing avec le premier pricer");
            WritePricerOutputs(new Pricer.Pricer());
        }

        private static void WritePricerOutputs(IPricer pricer)
        {
            foreach (string shape in Service.GetEstimations(pricer))
            {
                WriteLine(shape);
            }
        }

        private static void RunSecondStep()
        {
            WriteLine("Etape 2 : ajouter une forme à cette collection (ex: Cercle MonNom 10)");
            string newShape = System.Console.ReadLine();
            Service.Add(newShape);

            RunThirdStep();
        }

        private static void RunThirdStep()
        {
            string stringPath = string.Format(@"{0}collection.json", AppDomain.CurrentDomain.BaseDirectory);
            WriteLine(string.Format("Etape 3 : serialization de la collection dans le fichier '{0}'", stringPath));
            Service.SerializeCollection(stringPath);
        }

        private static void RunFirstStep()
        {
            WriteLine("Etape 1 : affichage d'une collection de formes");

            foreach (string shape in Service.GetShapes())
            {
                WriteLine(shape);
            }
        }

        private static void WriteLine(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}

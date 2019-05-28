using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsumidorSoap.ServiceReference1;

namespace ConsumidorSoap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Aplicación...");

            var client = new HelloWorldClient();
            var valor = client.sayHelloWorld("pepe");

            Console.WriteLine(valor);

            Console.ReadLine();

        }
    }
}

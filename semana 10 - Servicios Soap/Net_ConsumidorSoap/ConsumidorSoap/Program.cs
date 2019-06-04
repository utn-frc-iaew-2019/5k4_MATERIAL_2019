using ConsumidorSoap.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumidorSoap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Aplicación...");

            var client = new WCFReservaVehiculosClient();
            var credentials = new Credentials();
            credentials.UserName = "grupo_nro1";
            credentials.Password = "AzArobmjV0";

            var request = new ConsultarCiudadesRequest();
            request.IdPais = 1;
            var valor = client.ConsultarCiudades(credentials, request);

            foreach(var ciudad in valor.Ciudades)
            {
                Console.WriteLine(ciudad.Nombre);

            }


            Console.ReadLine();

        }
    }
}

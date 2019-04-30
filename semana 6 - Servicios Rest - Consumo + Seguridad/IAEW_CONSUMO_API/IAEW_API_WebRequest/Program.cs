using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IAEW_API_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("IAEW - Ejemplo Consumo API");

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("(GET) - Listando Usuarios...");
            ListarTodos();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("(GET) - Consultando Usuario...");
            ConsultarDatosUsuario(1);

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("(POST) - Insertando Usuario...");
            var nuevoUsuario = new Usuario();
            nuevoUsuario.name = "Perez, Juan";
            nuevoUsuario.username = "perez.juan";

            NuevoUsuario(ref nuevoUsuario);

            Console.WriteLine("El usuario se generó correctamente. ID = " + nuevoUsuario.id);

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("(PUT) - Actualizando Usuario...");

            var usuarioModif = new Usuario();
            usuarioModif.id = 2;
            usuarioModif.name = "Perez, Juan";
            usuarioModif.username = "perez.juan";
            ActualizarUsuario(ref usuarioModif);

            Console.WriteLine("El usuario se modificó correctamente. ID = " + usuarioModif.id);


            Console.WriteLine("---------------------------------------");
            Console.WriteLine("(DELETE) - Eliminando Usuario: ID = 1");
            EliminarUsuario(1);

            Console.WriteLine("El usuario se eliminó correctamente. ID = " + usuarioModif.id);

            Console.ReadLine();
        }

        private static void ListarTodos()
        {
            try
            {
                //Inicializamos el objeto WebRequest
                var req = WebRequest.Create(@"http://jsonplaceholder.typicode.com/users/");

                //Indicamos el método a utilizar
                req.Method = "GET";
                //Definimos que el contenido del cuerpo del request tiene el formato Json
                req.ContentType = "application/json";

                //Realizamos la llamada a la API de la siguiente forma.
                var resp = req.GetResponse() as HttpWebResponse;
                if (resp != null && resp.StatusCode == HttpStatusCode.OK)
                {
                    using (var respStream = resp.GetResponseStream())
                    {
                        if (respStream != null)
                        {
                            //Obtenemos de la siguiente el cuerpo de la respuesta
                            var reader = new StreamReader(respStream, Encoding.UTF8);
                            string result = reader.ReadToEnd();

                            //El cuerpo en formato Json lo deserealizamos en el objeto usuario
                            var listResult = JsonConvert.DeserializeObject<List<Usuario>>(result);

                            foreach (var usuario in listResult)
                            {
                                Console.WriteLine("---------------------------------------");
                                Console.WriteLine(" id:" + usuario.id);
                                Console.WriteLine(" name:" + usuario.name);
                                Console.WriteLine(" username:" + usuario.username);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription);

                }

            }
            catch (WebException ex)
            {
                //En caso de un error en la llamada se dispara la excepcion WebException con los datos del error.
                //Que lo podemos obtener de la siguiente forma.
                Console.WriteLine("Message:" + ex.Message);

                using (Stream respStream = ex.Response.GetResponseStream())
                {
                    var reader = new StreamReader(respStream, Encoding.UTF8);
                    var result = reader.ReadToEnd();
                    Console.WriteLine(result);
                }
            }

        }

        private static void ConsultarDatosUsuario(int idUsuario)
        {
            try
            {
                //Inicializamos el objeto WebRequest
                var req = WebRequest.Create(@"http://jsonplaceholder.typicode.com/users/" + idUsuario);
                //Indicamos el método a utilizar
                req.Method = "GET";
                //Definimos que el contenido del cuerpo del request tiene el formato Json
                req.ContentType = "application/json";

                //Realizamos la llamada a la API de la siguiente forma.
                var resp = req.GetResponse() as HttpWebResponse;
                //El protocolo HTTP define un cambpo Status que indica el estado de la peticion.
                //StatusCode = 200 (OK), indica que la llamada se proceso correctamente.
                //Cualquier otro caso corresponde a un error.
                if (resp != null && resp.StatusCode == HttpStatusCode.OK)
                {
                    using (var respStream = resp.GetResponseStream())
                    {
                        if (respStream != null)
                        {
                            //Obtenemos de la siguiente el cuerpo de la respuesta
                            var reader = new StreamReader(respStream, Encoding.UTF8);
                            string result = reader.ReadToEnd();

                            //El cuerpo en formato Json lo deserealizamos en el objeto usuario
                            var resultEntity = JsonConvert.DeserializeObject<Usuario>(result);

                            Console.WriteLine("id:" + resultEntity.id);
                            Console.WriteLine("name:" + resultEntity.name);
                            Console.WriteLine("username:" + resultEntity.username);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription);

                }

            }
            catch (WebException ex)
            {
                //En caso de un error en la llamada se dispara la excepcion WebException con los datos del error.
                //Que lo podemos obtener de la siguiente forma.
                Console.WriteLine("Message:" + ex.Message);

                using (Stream respStream = ex.Response.GetResponseStream())
                {
                    var reader = new StreamReader(respStream, Encoding.UTF8);
                    var result = reader.ReadToEnd();
                    Console.WriteLine(result);
                }
            }

        }

        private static void NuevoUsuario(ref Usuario nuevoUsuario)
        {
            try
            {
                //Inicializamos el objeto WebRequest
                var req = WebRequest.Create(@"http://jsonplaceholder.typicode.com/users/");

                //Indicamos el método a utilizar
                req.Method = "POST";
                //Definimos que el contenido del cuerpo del request tiene el formato Json
                req.ContentType = "application/json";

                //Escribimos sobre el cuerpo del request los datos del usuario en formato Json
                using (var streamWriter = new StreamWriter(req.GetRequestStream()))
                {
                    //Serializamos el objeto usuario en un string con formato Json
                    var jsonData = JsonConvert.SerializeObject(nuevoUsuario);

                    streamWriter.Write(jsonData);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                //Realizamos la llamada a la API de la siguiente forma.
                var resp = req.GetResponse() as HttpWebResponse;

                //El protocolo HTTP define un cambpo Status que indica el estado de la peticion.
                //StatusCode = 200 (OK), indica que la llamada se proceso correctamente.
                //Cualquier otro caso corresponde a un error.
                if (resp != null && resp.StatusCode == HttpStatusCode.OK)
                {
                    using (var respStream = resp.GetResponseStream())
                    {
                        if (respStream != null)
                        {
                            //Obtenemos de la siguiente el cuerpo de la respuesta
                            var reader = new StreamReader(respStream, Encoding.UTF8);
                            string result = reader.ReadToEnd();

                            //El cuerpo en formato Json lo deserealizamos en el objeto usuario
                            nuevoUsuario = JsonConvert.DeserializeObject<Usuario>(result);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription);
                }

            }
            catch (WebException ex)
            {
                //En caso de un error en la llamada se dispara la excepcion WebException con los datos del error.
                //Que lo podemos obtener de la siguiente forma.
                Console.WriteLine("Message:" + ex.Message);

                using (Stream respStream = ex.Response.GetResponseStream())
                {
                    var reader = new StreamReader(respStream, Encoding.UTF8);
                    var result = reader.ReadToEnd();
                    Console.WriteLine(result);
                }
            }
        }

        private static void ActualizarUsuario(ref Usuario usuario)
        {
            try
            {
                //Inicializamos el objeto WebRequest
                var req = WebRequest.Create(@"http://jsonplaceholder.typicode.com/users/" + usuario.id);

                //Indicamos el método a utilizar
                req.Method = "PUT";
                //Definimos que el contenido del cuerpo del request tiene el formato Json
                req.ContentType = "application/json";

                //Escribimos sobre el cuerpo del request los datos del usuario en formato Json
                using (var streamWriter = new StreamWriter(req.GetRequestStream()))
                {
                    var jsonData = JsonConvert.SerializeObject(usuario);

                    streamWriter.Write(jsonData);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                //Realizamos la llamada a la API de la siguiente forma.
                var resp = req.GetResponse() as HttpWebResponse;

                //El protocolo HTTP define un cambpo Status que indica el estado de la peticion.
                //StatusCode = 200 (OK), indica que la llamada se proceso correctamente.
                //Cualquier otro caso corresponde a un error.
                if (resp != null && resp.StatusCode == HttpStatusCode.OK)
                {
                    using (var respStream = resp.GetResponseStream())
                    {
                        if (respStream != null)
                        {
                            //Obtenemos de la siguiente el cuerpo de la respuesta
                            var reader = new StreamReader(respStream, Encoding.UTF8);
                            string result = reader.ReadToEnd();

                            //El cuerpo en formato Json lo deserealizamos en el objeto usuario
                            usuario = JsonConvert.DeserializeObject<Usuario>(result);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription);
                }

            }
            catch (WebException ex)
            {
                //En caso de un error en la llamada se dispara la excepcion WebException con los datos del error.
                //Que lo podemos obtener de la siguiente forma.
                Console.WriteLine("Message:" + ex.Message);

                using (Stream respStream = ex.Response.GetResponseStream())
                {
                    var reader = new StreamReader(respStream, Encoding.UTF8);
                    var result = reader.ReadToEnd();
                    Console.WriteLine(result);
                }
            }
        }

        private static void EliminarUsuario(int idUsuario)
        {
            try
            {
                //Inicializamos el objeto WebRequest
                var req = WebRequest.Create(@"http://jsonplaceholder.typicode.com/users/" + idUsuario);

                //Indicamos el método a utilizar
                req.Method = "DELETE";
                //Definimos que el contenido del cuerpo del request tiene el formato Json
                req.ContentType = "application/json";

                //Realizamos la llamada a la API de la siguiente forma.
                var resp = req.GetResponse() as HttpWebResponse;

                //El protocolo HTTP define un cambpo Status que indica el estado de la peticion.
                //StatusCode = 200 (OK), indica que la llamada se proceso correctamente.
                //Cualquier otro caso corresponde a un error.
                if (resp == null || resp.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine("Status Code: {0}, Status Description: {1}", resp.StatusCode,
                        resp.StatusDescription);
                }
            }
            catch (WebException ex)
            {
                //En caso de un error en la llamada se dispara la excepcion WebException con los datos del error.
                //Que lo podemos obtener de la siguiente forma.
                Console.WriteLine("Message:" + ex.Message);

                using (Stream respStream = ex.Response.GetResponseStream())
                {
                    var reader = new StreamReader(respStream, Encoding.UTF8);
                    var result = reader.ReadToEnd();
                    Console.WriteLine(result);
                }
            }
        }
    }
}

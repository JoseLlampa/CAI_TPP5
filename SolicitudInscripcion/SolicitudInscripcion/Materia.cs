using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SolicitudInscripcion
{
    static class Materia
    {
        static public void MostrarAprobadas(int registro)
        {
            string path = @"C:\Users\Administrador\Documents\GitHub\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\MateriaCursada.csv";
            String[] lineas = File.ReadAllLines(path);
            //string datosMateriaCursada = "";
            Console.WriteLine("Indique si aprobó algunas de las siguientes materias.");

            foreach (var linea in lineas)
            {
                var campo = linea.Split(';');

                if (int.Parse(campo[0]) == registro && campo[3] == "solicitado")
                {
                    string confirmacion = "";
                    Console.WriteLine("Código: " + campo[1] + " - Materia:" + campo[2] + ". ¿Usted aprobó esta materia? Y/N");
                    confirmacion = Console.ReadLine();
                    ConfirmarMateria(campo[0], campo[1], confirmacion);
                }
            }
        }

        internal static int IngresarMostrarMateria()
        {
            int resultadoCodigoMateria;
            bool resultadoEstadoMateria;
            do
            {
                Console.WriteLine("Ingrese la materia que quiere inscribirse y presione [Enter]");
                var codigoMateria = Console.ReadLine();

                //TODO: Validar codigo materia

                resultadoCodigoMateria = ObtenerMostrarMateria(codigoMateria); //si lo encuentra devuelve el int CodigoMateria, sino devuelve 0 si no lo encuentra
                
                if (resultadoCodigoMateria == 0)
                {
                    Console.WriteLine("No se encuentra la materia ingresada");                    
                }    

            } while (resultadoCodigoMateria == 0);

            resultadoEstadoMateria = EstaHabilitado(resultadoCodigoMateria); 

            if (!resultadoEstadoMateria)
            {
                Console.WriteLine("Esta materia no reune las condiciones de correlatividad");
                return -1;
            }

            return resultadoCodigoMateria;
        }

        private static bool EstaHabilitado(int resultadoCodigoMateria)
        {
            bool habilitado = false;
            string path = @"C:\Users\Administrador\Documents\GitHub\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\MateriaCursada.csv";
            String[] lineas = File.ReadAllLines(path);

            foreach (var linea in lineas)
            {
                var campo = linea.Split(';');

                if (resultadoCodigoMateria == int.Parse(campo[1]) && campo[3] == "habilitado")
                {
                    habilitado = true;
                    break;
                }
            }
            return habilitado;
        }

        internal static string GetNombreMateria(int codigoMateria)
        {
            string NombreMateria = "NoEncontrado";
            string path = @"C:\Users\Administrador\Documents\GitHub\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\Materia.csv";
            String[] lineas = File.ReadAllLines(path);

            foreach (var linea in lineas)
            {
                var campo = linea.Split(';');

                if (codigoMateria == int.Parse(campo[0]))
                {
                    NombreMateria = campo[1];
                    return NombreMateria;
                }
            }
            return NombreMateria;
        }

        private static int ObtenerMostrarMateria(string codigoMateria)
        {
            int resultadoCodigoMateria = 0;
            string path = @"C:\Users\Administrador\Documents\GitHub\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\Materia.csv";
            String[] lineas = File.ReadAllLines(path);

            foreach (var linea in lineas)
            {
                var campo = linea.Split(';');

                if (codigoMateria == campo[0])
                {
                    Console.WriteLine($"Materia: {campo[0]} - {campo[1]}");
                    Console.WriteLine($"Correlativas: {campo[2]}");

                    resultadoCodigoMateria = int.Parse(campo[0]);
                    return resultadoCodigoMateria;
                }                
            }
            return resultadoCodigoMateria;
        }

        static public void ConfirmarMateria(string registroEstudiante, string codigoMateria, string confirmacion)
        {
            //TODO: Hacer que se escriba la materia correlativa a "materia"
            //TODO: Puedo agregar validacion al parametro confirmacion

            if (confirmacion == "Y")
            {
                string path = @"C:\Users\Administrador\Documents\GitHub\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\MateriaCursada.csv";
                String[] lineas = File.ReadAllLines(path);

                foreach (var linea in lineas)
                {
                    var campo = linea.Split(';');
                    string registroViejo;
                    string registroNuevo;

                    if (registroEstudiante == campo[0] && codigoMateria == campo[1])
                    {
                        registroViejo = campo[0] + ';' + campo[1] + ';' + campo[2] + ';' + "solicitado";
                        registroNuevo = campo[0] + ';' + campo[1] + ';' + campo[2] + ';' + "aprobada";

                        string ArchivoActualizado = File.ReadAllText(path);

                        ArchivoActualizado = ArchivoActualizado.Replace(registroViejo, registroNuevo);
                        File.WriteAllText(path, ArchivoActualizado);
                        break;
                    }
                }
            }            
        }

        static public void HabilitarMaterias(int registroEstudiante)
        {
            //HABILITA DERECHO INFORMATICO 2
            string estadoMateria;
            
            int derechoInformatico2 = 1604;
            int derechoInformatico1 = 1603;
            estadoMateria = BuscarEstadoMateria(registroEstudiante,derechoInformatico1); 
            

            if (estadoMateria == "aprobada")
            {
                string path = @"C:\Users\Administrador\Documents\GitHub\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\MateriaCursada.csv";
                String[] lineas = File.ReadAllLines(path);

                foreach (var linea in lineas)
                {
                    var campo = linea.Split(';');
                    string registroViejo;
                    string registroNuevo;

                    if (registroEstudiante == int.Parse(campo[0]) && derechoInformatico2 == int.Parse(campo[1]))
                    {
                        registroViejo = campo[0] + ';' + campo[1] + ';' + campo[2] + ';' + "deshabilitado";
                        registroNuevo = campo[0] + ';' + campo[1] + ';' + campo[2] + ';' + "habilitado";

                        string ArchivoActualizado = File.ReadAllText(path);

                        ArchivoActualizado = ArchivoActualizado.Replace(registroViejo, registroNuevo);
                        File.WriteAllText(path, ArchivoActualizado);
                        break;
                    }
                }
            }
        }

        static public string BuscarEstadoMateria(int registroEstudiante, int codigoMateria)
        {
            string path = @"C:\Users\Administrador\Documents\GitHub\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\MateriaCursada.csv";
            String[] lineas = File.ReadAllLines(path);

            foreach (var linea in lineas)
            {
                var campo = linea.Split(';');
                if (registroEstudiante == int.Parse(campo[0]) && codigoMateria == int.Parse(campo[1]))
                {
                    return campo[3];
                }       
                
            }
            return "null";
        }

        static public void UltimasMaterias(int registroEstudiante)
        {
            string respuesta;
            Console.WriteLine("Está cursando las últimas 4 materias? S/N");
            respuesta = Console.ReadLine();
            //TODO: validar el ingreso de la persona. Tiene que ingresar un sólo caracter y ser S o N
            if (respuesta == "S")
            {
                HabilitarTodasMaterias(registroEstudiante);
            }
        }

        static public void HabilitarTodasMaterias(int registroEstudiante)
        {
            string path = @"C:\Users\Administrador\Documents\GitHub\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\MateriaCursada.csv";
            String[] lineas = File.ReadAllLines(path);

            foreach (var linea in lineas)
            {
                var campo = linea.Split(';');
                string registroViejo;
                string registroNuevo;

                if (registroEstudiante == int.Parse(campo[0]) && "deshabilitado" == campo[3])
                {
                    registroViejo = campo[0] + ';' + campo[1] + ';' + campo[2] + ';' + "deshabilitado";
                    registroNuevo = campo[0] + ';' + campo[1] + ';' + campo[2] + ';' + "habilitado";

                    string ArchivoActualizado = File.ReadAllText(path);

                    ArchivoActualizado = ArchivoActualizado.Replace(registroViejo, registroNuevo);
                    File.WriteAllText(path, ArchivoActualizado);
                }
            }          
        }

        /*
        private void SeleccionarMateria()
        {

        }
        */

    }
}



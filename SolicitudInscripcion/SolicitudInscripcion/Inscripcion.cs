using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SolicitudInscripcion
{
    class Inscripcion
    {
        public int registro;

        public void GestionarInscripcion()
        {
            registro = BuscarRegistro();
            MostrarEstudiante(registro);
            Ultimas4Materias(registro);
            InscripcionCursos(registro);
            ConfirmarInscripcion(registro);
            Console.WriteLine("Presione [Enter] para salir.");
        }

        public static int BuscarRegistro()
        {
            int registro = Validador.ValidarRegistro("número de registro");
            return registro;
        }

        public static void MostrarEstudiante(int registro)
        {
            //Estudiante estudiante = new Estudiante();
            Console.WriteLine("Nombre: "+ Estudiante.MostrarNombre(registro));
            //Console.ReadKey();
        }

        private void Ultimas4Materias(int registro)
        {
            //Materia materia = new Materia();
            Materia.UltimasMaterias(registro);
            //Console.ReadKey();
        }

        private void InscripcionCursos(int registro)
        {
            var respuesta = "S";
            string respuestaValidada;
            int contador = 0;
            do
            {
                int codigoMateria = Materia.IngresarMostrarMateria();

                

                if (codigoMateria != -1)
                {
                    Console.WriteLine("Ingrese código de curso");
                    var codigoCurso = Console.ReadLine();
                    Validador.ValidarIngresoEntero(codigoCurso);
                    Curso.ObtenerNombreDocente(codigoCurso, codigoMateria);

                    InscribirACurso(registro, codigoCurso, codigoMateria);
                    contador += 1;
                }

                Console.WriteLine("¿Desea seguir inscribiendose a materias? S/N");
                respuesta = Console.ReadLine();
                respuestaValidada = Validador.ValidarIngresoSoN(respuesta);
                //flag

            } while (respuestaValidada.ToUpper() == "S" && contador <4);

            if (contador == 4)
            {
                Console.WriteLine("No se puede inscribir a más materias. Se inscribió a 4.");
            }

        }

        private void InscribirACurso(int registro, string codigoCurso, int codigoMateria)
        {
            //ValidarDobleInscripcion();
            string nombreEstudiante;
            string nombreMateria;
            string docenteTitular;

            nombreEstudiante = Estudiante.MostrarNombre(registro);
            nombreMateria = Materia.GetNombreMateria(codigoMateria);
            docenteTitular = Curso.GetDocenteTitular(codigoMateria, codigoCurso);

            string path = @"C:\Users\Administrador\Documents\GitHub\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\Inscripcion.csv";
            StreamWriter stream = File.AppendText(path);
            stream.WriteLine(registro + ";" + nombreEstudiante + ";" + codigoMateria + ";" + nombreMateria + ";" + codigoCurso + ";" + docenteTitular + ";pendiente");
            stream.Close();
            Console.WriteLine("La inscripción se guardo correctamente y se encuentra pendiente a confirmar");

        }

        private void ConfirmarInscripcion(int registro)
        {

            Console.WriteLine("¿Desea confirmar todas las inscripciones anteriores? S/N");
            var respuesta = Console.ReadLine();
            Validador.ValidarIngresoSoN(respuesta);
           

            if (respuesta.ToUpper() == "S")
            {
                ActualizaAConfirmado(registro);
                MostrarInscripción(registro);
            }
            else if (respuesta.ToUpper() == "N")
            {
                EliminaPendiente(registro);
            }
        }

        private void ActualizaAConfirmado(int registro)
        {
            string path = @"C:\Users\Administrador\Documents\GitHub\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\Inscripcion.csv";
            String[] lineas = File.ReadAllLines(path);

            string registroViejo;
            string registroNuevo;

            foreach (var linea in lineas)
            {
                var campo = linea.Split(';');

                if (int.Parse(campo[0]) == registro && campo[6] == "pendiente")
                {
                    registroViejo = campo[0] + ';' + campo[1] + ';' + campo[2] + ';' + campo[3] + ';' + campo[4] + ';' + campo[5] + ';' + "pendiente";
                    registroNuevo = campo[0] + ';' + campo[1] + ';' + campo[2] + ';' + campo[3] + ';' + campo[4] + ';' + campo[5] + ';' + "confirmado";

                    string ArchivoActualizado = File.ReadAllText(path);

                    ArchivoActualizado = ArchivoActualizado.Replace(registroViejo, registroNuevo);
                    File.WriteAllText(path, ArchivoActualizado);

                }
            }
        }

        private void MostrarInscripción(int registro)
        {
            string path = @"C:\Users\Administrador\Documents\GitHub\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\Inscripcion.csv";
            String[] lineas = File.ReadAllLines(path);

            Console.WriteLine("Usted realizó la solicitud de inscripción de las siguientes materias");

            foreach (var linea in lineas)
            {
                var campo = linea.Split(';');

                if (int.Parse(campo[0]) == registro && campo[6] == "confirmado")
                {
                    Console.WriteLine($"{campo[2]} {campo[3]} Curso {campo[4]} {campo[5]}");
                }
            }
        }

        private void EliminaPendiente(int registro)
        {
            string path = @"C:\Users\Administrador\Documents\GitHub\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\Inscripcion.csv";
            String[] lineas = File.ReadAllLines(path);

            string registroViejo;
            string registroNuevo;

            foreach (var linea in lineas)
            {
                var campo = linea.Split(';');

                if (int.Parse(campo[0]) == registro && campo[6] == "pendiente")
                {
                    registroViejo = campo[0] + ';' + campo[1] + ';' + campo[2] + ';' + campo[3] + ';' + campo[4] + ';' + campo[5] + ';' + "pendiente";
                    registroNuevo = "";

                    string ArchivoActualizado = File.ReadAllText(path);

                    ArchivoActualizado = ArchivoActualizado.Replace(registroViejo, registroNuevo);
                    File.WriteAllText(path, ArchivoActualizado);
                    
                }
            }
        }

    }
}

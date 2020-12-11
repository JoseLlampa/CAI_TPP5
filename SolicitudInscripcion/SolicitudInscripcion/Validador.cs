using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SolicitudInscripcion
{
    class Validador
    {
        public static int ValidarRegistro(string msg)
        {
            do
            {
                Console.Write("Ingrese " + msg + ": ");
                var in_registro = Console.ReadLine();
                if (!int.TryParse(in_registro, out int registro))
                {
                    Console.WriteLine("Ingrese un número entero");
                    continue;
                }
                if (!ExisteEstudiante(registro))
                {
                    Console.WriteLine("El estudiante no se encuentra registrado en el sistema");
                    continue;
                }
                return registro;
            } while (true);
        }

        private static bool ExisteEstudiante(int registro)
        {
            string path = @"C:\Users\Administrador\Documents\GitHub\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\Estudiante.csv";
            String[] lineas = File.ReadAllLines(path);
            bool existe = false;

            foreach (var linea in lineas)
            {
                var campo = linea.Split(';');
                if (int.Parse(campo[0]) == registro && campo[2] == "activo")
                {
                    existe = true;
                }

            }
            return existe;
        }

        public static string ValidarIngresoSoN(string ingreso)
        {
            bool validado = false;
            string ingresonuevo = ingreso;
            do
            {

                if (ingresonuevo.ToUpper() == "S" || ingresonuevo.ToUpper() == "N")
                {
                    validado = true;
                }
                else
                {
                    Console.WriteLine("Ingrese S para indicar Sí, o ingrese N para indicar No");
                    ingresonuevo = Console.ReadLine();
                }

            } while (!validado);

            return ingresonuevo;
        }

        public static void ValidarIngresoEntero(string ingreso)
        {
            bool validado = false;
            string ingresonuevo = ingreso;
            do
            {

                if (int.TryParse(ingresonuevo, out int entero))
                {
                    validado = true;
                }
                else
                {
                    Console.WriteLine("Ingrese un número entero");
                    ingresonuevo = Console.ReadLine();
                }

            } while (!validado);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SolicitudInscripcion
{
    static class Curso
    {
        internal static void ObtenerNombreDocente(string codigoCurso, int codigoMateria)
        {
            bool existe = false;
            string path = @"C:\Users\Administrador\Documents\GitHub\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\Curso.csv";
            String[] lineas = File.ReadAllLines(path);

            //TODO: Validar Codigo de curso. Infinitamente hasta que ingrese uno correcto

            foreach (var linea in lineas)
            {
                var campo = linea.Split(';');

                if (codigoMateria == int.Parse(campo[0]) && codigoCurso == campo[1])
                {
                    Console.WriteLine($"Titular: {campo[2]}");
                    existe = true;
                    break;
                }
            }

            if (!existe)
            {
                Console.WriteLine("El codigo de Curso no existe");
            }
            //TODO: Si el codigo de curso no existe en el archivo, ver si lo pedimos infinitamente hasta que ingrese uno correcto o lo dejamos así.
        }

        internal static string GetDocenteTitular(int codigoMateria, string codigoCurso)
        {
            string docenteTitular = "NoEncontrado";
            string path = @"C:\Users\Administrador\Documents\GitHub\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\Curso.csv";
            String[] lineas = File.ReadAllLines(path);

            //TODO: Validar Codigo de curso. Infinitamente hasta que ingrese uno correcto

            foreach (var linea in lineas)
            {
                var campo = linea.Split(';');

                if (codigoMateria == int.Parse(campo[0]) && codigoCurso == campo[1])
                {
                    docenteTitular = campo[2];
                    return docenteTitular;
                }
            }

            return docenteTitular;          
        }
    }
}

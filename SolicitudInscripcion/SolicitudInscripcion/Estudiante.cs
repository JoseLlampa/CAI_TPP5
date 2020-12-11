using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SolicitudInscripcion
{
    class Estudiante
    {
        public int registro;
        public string nombre;
        public string estado;

        static public string MostrarNombre(int registro)
        {
            string path = @"C:\Users\Administrador\Documents\GitHub\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\Estudiante.csv";
            String[] lineas = File.ReadAllLines(path);
            string Nombre = "NoEncontrado";

            foreach (var linea in lineas)
            {
                var campo = linea.Split(';');
                if (int.Parse(campo[0]) == registro && campo[2] == "activo")
                {
                    Nombre = campo[1];
                    return Nombre;
                }
            }
            return Nombre;
            //TODO: Agregar un mensaje de error si no se encuentra.
        }

    }
}

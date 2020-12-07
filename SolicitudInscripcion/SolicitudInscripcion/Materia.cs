using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SolicitudInscripcion
{
    class Materia
    {
        public void MostrarAprobadas(int registro)
        {
            string path = @"C:\Users\hecto\source\repos\CAI_TPP5\SolicitudInscripcion\SolicitudInscripcion\bin\Debug\MateriaCursada.csv";
            String[] lineas = File.ReadAllLines(path);
            //string datosMateriaCursada = "";
            Console.WriteLine("Indique si aprobó algunas de las siguientes materias.");

            foreach (var linea in lineas)
            {
                var campo = linea.Split(';');
                
                if (int.Parse(campo[0]) == registro)
                {
                    string confirmacion = "";
                    Console.WriteLine("Código: "+campo[1]+" - Materia:" + campo[2]+". ¿Usted aprobó esta materia? Y/N");
                    confirmacion = Console.ReadLine();
                    ConfirmarMateria(confirmacion);
                    
                }   
            }
        }

        private void ConfirmarMateria(string confirmacion)
        {
            //TODO: Hacer que se escriba la materia correlativa a "materia"


        }
    }
}

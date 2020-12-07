using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudInscripcion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solicitud de Inscripción - Sistemas de Información de las Organizaciones");
            Inscripcion inscripcion = new Inscripcion();
            inscripcion.GestionarInscripcion();
            Console.ReadKey();
        }
        
        
    }
}

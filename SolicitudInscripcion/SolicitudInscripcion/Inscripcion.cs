using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudInscripcion
{
    class Inscripcion
    {
        public int registro;


        public void GestionarInscripcion()
        {
            
            registro = BuscarRegistro();
            MostrarEstudiante(registro);
            MostrarMateriasCursadas(registro);
        }

        public static int BuscarRegistro()
        {
            int registro = Validador.ValidarRegistro("número de registro");
            return registro;
        }

        public static void MostrarEstudiante(int registro)
        {
            Estudiante estudiante = new Estudiante();
            Console.WriteLine(estudiante.MostrarNombre(registro));
            Console.ReadKey();
        }

        private static void MostrarMateriasCursadas(int registro)
        {
            Materia materia = new Materia();
            materia.MostrarAprobadas(registro);
            Console.ReadKey();
        }

        private static void AgregarAprobadas()
        {

        }

        private static void MarcarCuatroUltimas()
        {

        }

        private static void InscribirCurso()
        {

        }

        private static void MostrarInscripcion()
        {

        }
    }
}

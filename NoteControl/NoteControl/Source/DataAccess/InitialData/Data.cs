using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.DataAccess.InitialData
{
    public class Data
    {
       public string[] privilegios = { "Mantenedor de Perfiles", "Mantenedor de Usuarios","Mantenedor de Cursos",
                "Mantenedor de Profesores","Mantenedor de Especialidades","Ingresar Notas",
               "Consulta de Alumnos por Cursos","Consulta de Profesores por Cursos",
                "Generacion de Informes"};
        public string[] asignaturas = {"Artes Visuales",
                            "Ciencias Naturales",
                            "Educación Física y Salud",
                            "Historia", "Geografía y Ciencias Sociales",
                            "Inglés",
                            "Lenguaje y Comunicación",
                            "Matemática",
                            "Música" };
        public int[] RutAlum = { 203450459, 21029468, 213848479, 23482736, 212139847, 21837463, 20837463, 20383646 };
        public string[] NombresAlum = { "Matias", "Felipe", "Camilo", "Ricardo", "Emilio", "Cesar", "Francisco", "Pablo" };
        public string[] ApellidosAlum = { "Rivera", "Cardenas", "Jaramillo", "Fernandez", "Sanchez", "Vidal", "Dias", "Bravo" };
        public int[] RutProfesor = { 162728334, 156373948, 172736737, 172838464,128384737, 133849388, 112342342, 143834853 };
        public string[] ProfesoresNombre = { "Juan", "Carlos","Eduardo",
                "Francisco","Joseph","Claudia",
                "Carla","Emilio"};
        public string[] ProfesoresApellido = { "Martinez", "Urrutia","Rivas",
                "Sangueza","Lopez","Espeniza",
                "Peters","Pereira"};
        public string[] Especialidades = { "Juan", "Carlos","Eduardo",
                "Francisco","Joseph","Claudia",
                "Carla","Emilio"};
        public Data()
        {

        }
    }
}

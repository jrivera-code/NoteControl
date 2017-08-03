using NoteControl.Source.DataAccess.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.BusinessLogic
{
    public class BLNotas
    {
        private DANotas _da = new DANotas();

        public void AgregarNuevaNota(float calificacion, string asignaturaCode, int rut,int numeroNota)
        {
            try {
                _da.AgregarNuevaNota(calificacion, asignaturaCode, rut, numeroNota);

            } catch { throw; }
       
        }
    }
}

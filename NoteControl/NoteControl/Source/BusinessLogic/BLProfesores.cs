using NoteControl.Source.DataAccess.Source;
using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteControl.Source.BusinessLogic
{
   public class BLProfesores
    {
        DAProfesores _da = new DAProfesores();
        //metodo para agregar un profesor
        public void crearProfesor(Profesor profe)
        {
            try
            {
                _da.crearProfesor(profe);
                MessageBox.Show("Profesor Creado Exitosamente!");
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        //metodo para listar todos los profesores
        public List<Profesor> listarProfesores()
        {
            try
            {
                return _da.listarProfesores();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

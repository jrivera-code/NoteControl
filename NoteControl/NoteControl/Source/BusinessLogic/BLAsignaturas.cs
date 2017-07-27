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
   public class BLAsignaturas
    {
        DAAsignaturas _da = new DAAsignaturas();
        //metodo para agregar una asignatura
        public void crearAsignatura(Asignatura asig)
        {
            try
            {
                _da.crearAsignatura(asig);
                MessageBox.Show("Asignatura Creada Exitosamente!");
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        //metodo para listar todos las asignaturas
        public List<Asignatura> listarAsignaturas()
        {
            try
            {
                return _da.listarAsignaturas();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

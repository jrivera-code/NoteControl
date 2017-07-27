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
   public class BLEspecialidades
    {
        DAEspecialidades _da = new DAEspecialidades();
        //metodo para agregar una especialidad
        public void crearEspecialidad(Especialidad especialidad)
        {
            try
            {
                _da.crearEspecialidad(especialidad);
                MessageBox.Show("Especialidad Creada Exitosamente!");
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        //metodo para listar todos las especialidades
        public List<Especialidad> listarEspecialidades()
        {
            try
            {
                return _da.listarEspecialidades();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

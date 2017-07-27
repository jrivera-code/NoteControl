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

        public void eliminarEspecialidad(string textBoxCode)
        {
            try
            {
                _da.eliminarEspecialidad(textBoxCode);
                MessageBox.Show("La especialidad ha sido eliminada");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void modificarEspecialidad(Especialidad especialidad, string textBoxCode)
        {
            try
            {
                _da.modificarEspecialidad(especialidad, textBoxCode);
                MessageBox.Show("La especialidad ha sido modificada");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

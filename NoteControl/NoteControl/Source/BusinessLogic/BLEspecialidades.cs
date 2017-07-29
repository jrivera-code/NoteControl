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
        public void CrearEspecialidad(Especialidad especialidad)
        {
            try
            {
                _da.CrearEspecialidad(especialidad);
                MessageBox.Show("Especialidad Creada Exitosamente!");
            }
            catch 
            {
                throw;
            }

        }
        //metodo para listar todos las especialidades
        public List<Especialidad> ListarEspecialidades()
        {
            try
            {
                return _da.ListarEspecialidades();
            }
            catch 
            {
                throw;
            }
        }

        public void EliminarEspecialidad(string textBoxCode)
        {
            try
            {
                _da.EliminarEspecialidad(textBoxCode);
                MessageBox.Show("La especialidad ha sido eliminada");
            }
            catch 
            {
                throw;
            }
        }

        public void ModificarEspecialidad(Especialidad especialidad, string textBoxCode)
        {
            try
            {
                _da.ModificarEspecialidad(especialidad, textBoxCode);
                MessageBox.Show("La especialidad ha sido modificada");
            }
            catch 
            {
                throw;
            }
        }
    }
}

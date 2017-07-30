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
   public class BLCursos
    {
        DACursos _da = new DACursos();
        //metodo para agregar un curso
        public void CrearCurso(Curso curso, int profesorJefe)
        {
            try
            {
                _da.CrearCurso(curso, profesorJefe);
                MessageBox.Show("Curso Creado Exitosamente!");
            }
            catch
            {
                throw;
            }

        }
        //metodo para listar todos los cursos
        public List<Curso> ListarCursos()
        {
            try
            {
                return _da.ListarCursos();
            }
            catch 
            {
                throw;
            }
        }

        public void ModificarCurso(Curso curso, string textBoxCodeCurso,int newProfe)
        {
            try
            {
                _da.ModificarCurso(curso, textBoxCodeCurso, newProfe);
                MessageBox.Show("Curso "+textBoxCodeCurso+" modificado con exito");
            }
            catch
            {
                throw;
            }
          
        }

        public void EliminarCurso(string textBoxCodeCurso)
        {
            try
            {
                _da.EliminarCurso(textBoxCodeCurso);
                MessageBox.Show("Curso " + textBoxCodeCurso + "fue eliminado");
            }
            catch 
            {
                throw;
            }
        }
    }
}

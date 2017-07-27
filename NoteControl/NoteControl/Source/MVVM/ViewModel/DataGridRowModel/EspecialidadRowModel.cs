using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.ViewModel.DataGridRowModel
{
    public class EspecialidadRowModel
    {
        string _especialidadCode;
        string _nombre;
        public string EspecialidadCode
        {
            get
            {
                return _especialidadCode;
            }
            set
            {
                _especialidadCode = value;
            }
        }
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }
    }
}

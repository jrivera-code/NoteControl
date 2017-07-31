using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.ViewModel.DataGridRowModel
{
    public class AsigNotasModel
    {
        private string _rut;

        public string Rut
        {
            get { return _rut; }
            set { _rut = value; }
        }
        private string _nombreApellido;

        public string NombreApellido
        {
            get { return _nombreApellido; }
            set { _nombreApellido = value; }
        }
    }
}

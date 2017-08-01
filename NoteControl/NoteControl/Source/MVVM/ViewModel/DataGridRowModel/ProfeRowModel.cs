using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NoteControl.Source.MVVM.ViewModel.DataGridRowModel
{
    public class ProfeRowModel : INotifyPropertyChanged
    {
        private int _rut;
        private string _nombre;
        private string _apellido;
        private string _asignaturas;
        public int Rut
        {
            get
            {
                return _rut;
            }
            set
            {
                _rut = value;
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
        public string Apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
            }
        }
        public string AsignaturasItems
        {
            get { return _asignaturas; }
            set {
                _asignaturas = value;
                NotifyPropertyChanged("AsignaturasItems");
                    }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

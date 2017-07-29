using NoteControl.Source.BusinessLogic;
using NoteControl.Source.MVVM.Model;
using NoteControl.Source.MVVM.ViewModel.Commands;
using NoteControl.Source.MVVM.ViewModel.DataGridRowModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NoteControl.Source.MVVM.ViewModel
{
   public class ConsProfeCursoViewModel : INotifyPropertyChanged
    {
        private BLProfesores _blProfesores = new BLProfesores();
        private BLCursos _blCursos = new BLCursos();
        public Command ButtonConsClick { get; set; }
        private List<ComboBoxItem> _comboBoxCursosItems = new List<ComboBoxItem>();
        public List<ComboBoxItem> ComboBoxCursosItems
        {
            get => _comboBoxCursosItems;
            set  {_comboBoxCursosItems = value;
                NotifyPropertyChanged("ComboBoxCursosItems"); }
        }
        private ComboBoxItem _selectedComboBoxCursosItems;
        public ComboBoxItem SelectedComboBoxCursosItems
        {
            get => _selectedComboBoxCursosItems;
            set { _selectedComboBoxCursosItems = value;
                NotifyPropertyChanged("SelectedComboBoxCursosItems");
            }
        }
        private List<ProfeRowModel> _dataGridColumnProfesores = new List<ProfeRowModel>();

        public List<ProfeRowModel> DataGridColumnProfesores
        {
            get => _dataGridColumnProfesores; 
            set { _dataGridColumnProfesores = value;
                NotifyPropertyChanged("DataGridColumnProfesores");
            }
        }
       
        public ConsProfeCursoViewModel()
        {
            CargarComboBox();
            ButtonConsClick = new Command(CargarDataGrid, () => true);
            
           //var list = _blProfesores.ListarProfesoresPorCurso((string)_selectedComboBoxCursosItems.Content);
        }
        private void CargarDataGrid()
        {
            DataGridColumnProfesores.Clear();
            string code = _selectedComboBoxCursosItems.Tag.ToString();
            List<Profesor> list = _blProfesores.ListarProfesoresPorCurso(code);
              foreach (Profesor p in list)
            {
                    string asignaturas = "";
                    foreach (CursoProfeAsignatura asig in p.CursoProfeAsignaturas)
                    {
                    asignaturas += asig.Asignaturas.Nombre+", ";
                    }
                    asignaturas = asignaturas.Trim().TrimEnd(',');
                    DataGridColumnProfesores.Add(new ProfeRowModel()
                    {
                        Rut = p.Rut,
                        Nombre = p.Nombre,
                        Apellido = p.Apellido,
                        AsignaturasItems = asignaturas
                    });
                
               
            }
            NotifyPropertyChanged("DataGridColumnProfesores");
        }
        private void CargarComboBox()
        {
            foreach (Curso c in _blCursos.ListarCursos())
            {
                ComboBoxCursosItems.Add(new ComboBoxItem() { Content = c.Nombre, Tag = c.CursoCode });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

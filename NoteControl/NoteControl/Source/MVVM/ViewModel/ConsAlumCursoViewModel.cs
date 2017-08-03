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
    public class ConsAlumCursoViewModel : INotifyPropertyChanged
    {
        private BLAlumnos _blAlumnos = new BLAlumnos();
        private BLCursos _blCursos = new BLCursos();
        public Command ButtonConsClick { get; set; }
        private List<ComboBoxItem> _comboBoxCursosItems = new List<ComboBoxItem>();
        public List<ComboBoxItem> ComboBoxCursosItems
        {
            get { return _comboBoxCursosItems; }
            set { _comboBoxCursosItems = value; NotifyPropertyChanged("ComboBoxCursosItems"); }
        }

        private ComboBoxItem _selectedComboBoxCursosItems = new ComboBoxItem();
        public ComboBoxItem SelectedComboBoxCursosItems
        {
            get { return _selectedComboBoxCursosItems; }
            set
            {
                if (_selectedComboBoxCursosItems == value) return;

                _selectedComboBoxCursosItems = value;
                ButtonConsClick.methodToDetectCanExecute = () => true;
                NotifyPropertyChanged("SelectedComboBoxCursosItems");
            }
        }
        private List<AlumnoRowModel> _dataGridColumnAlumnos = new List<AlumnoRowModel>();
        public List<AlumnoRowModel> DataGridColumnAlumnos
        {
            get
            {
                return _dataGridColumnAlumnos;
            }
            set
            {
                _dataGridColumnAlumnos = value;
                NotifyPropertyChanged("DataGridColumnAlumnos");
            }
        }
        public ConsAlumCursoViewModel()
        {
            ButtonConsClick = new Command(CargarDataGrid, () => false);
            CargarComboBox();
        }
        private void CargarDataGrid()
        {
            DataGridColumnAlumnos.Clear();
            string code = _selectedComboBoxCursosItems.Tag.ToString();
            List<Alumno> list = _blAlumnos.ListarAlumnosPorCurso(code);
            foreach (Alumno a in list)
            {

                DataGridColumnAlumnos.Add(new AlumnoRowModel()
                {
                    Rut = a.Rut.ToString(),
                    Nombre = a.Nombre,
                    Apellido = a.Apellido
                });
            }
            NotifyPropertyChanged("DataGridColumnAlumnos");
        }
        private void CargarComboBox()
        {
            foreach (Curso c in _blCursos.ListarCursos())
            {
                ComboBoxCursosItems.Add(new ComboBoxItem() { Content = c.Nombre+" - Año: "+c.Anio ,
                    Tag = c.CursoCode,
                    ToolTip = "Seleccione un Alumno"
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

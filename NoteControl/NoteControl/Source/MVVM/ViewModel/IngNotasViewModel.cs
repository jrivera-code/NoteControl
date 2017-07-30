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
using System.Windows.Forms;

namespace NoteControl.Source.MVVM.ViewModel 
{
   public class IngNotasViewModel : INotifyPropertyChanged
    {
        private BLProfesores _blProfesores = new BLProfesores();
        private BLAsignaturas _blAsignaturas = new BLAsignaturas();
        private BLCursos _blCursos = new BLCursos();
        public Command ButtonBuscarAsig { get; set; }
        private List<ComboBoxItem> _comboBoxCurso = new List<ComboBoxItem>();
        public List<ComboBoxItem> ComboBoxCurso
        {
            get => _comboBoxCurso; 
            set { _comboBoxCurso = value;
                NotifyPropertyChanged("ComboBoxCurso");
            }
        }
        private ComboBoxItem _selectedComboBoxProfesores;

        public ComboBoxItem SelectedComboBoxProfesores
        {
            get => _selectedComboBoxProfesores; 
            set { _selectedComboBoxProfesores = value;
                NotifyPropertyChanged("SelectedComboBoxProfesores"); }
        }


        private List<AsigCursoProfeModel> _dataGridAsigCursoProfe = new List<AsigCursoProfeModel>();
       public List<AsigCursoProfeModel> DataGridAsigCursoProfe
        {
            get => _dataGridAsigCursoProfe; 
            set { _dataGridAsigCursoProfe = value;
                NotifyPropertyChanged("DataGridAsigCursoProfe");
            }
        }
        public IngNotasViewModel()
        {
            CargarComboBoxCurso();
            ButtonBuscarAsig = new Command( CargarDataGrid , () => true);
        }

        private void CargarComboBoxCurso()
        {
            foreach (Curso c in _blCursos.ListarCursos()) {
             ComboBoxCurso.Add(new ComboBoxItem() { Content = c.Nombre, Tag = c.CursoCode , ToolTip = c.CursoCode });
            }
        }
            private void CargarDataGrid()
        {
            DataGridAsigCursoProfe.Clear();
            int rut = int.Parse(_selectedComboBoxProfesores.Tag.ToString());
            foreach (Asignatura asig in _blAsignaturas.ListarAsignaturasPorProfesor(rut)) {
                asig.CursoAsignaturas.ForEach(e => {
                    DataGridAsigCursoProfe.Add(new AsigCursoProfeModel()
                    {
                        CodeCurso = e.CursoCode,
                        NombreCurso = e.Cursos.Nombre,
                        CodeAsignatura = e.AsignaturaCode,
                        NombreAsignatura = e.Asignaturas.Nombre

                    });
                });
            }
            NotifyPropertyChanged("DataGridAsigCursoProfe");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

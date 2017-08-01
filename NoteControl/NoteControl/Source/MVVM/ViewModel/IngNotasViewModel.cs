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
        private BLAlumnos _blAlumnos = new BLAlumnos();
        private BLCursos _blCursos = new BLCursos();
        public Command ButtonBuscarAlum { get; set; }
        private bool _isProfe;
        private List<ComboBoxItem> _comboBoxCurso = new List<ComboBoxItem>();
        public List<ComboBoxItem> ComboBoxCurso
        {
            get => _comboBoxCurso;
            set
            {
                _comboBoxCurso = value;
                NotifyPropertyChanged("ComboBoxCurso");
            }
        }
        private ComboBoxItem _selectedComboBoxCurso;

        public ComboBoxItem SelectedComboBoxCurso
        {
            get { return _selectedComboBoxCurso; }
            set
            {
                _selectedComboBoxCurso = value;
                if (_selectedComboBoxCurso != null)
                {
                    CargarComboBoxAsignatura();
                    IsEnableComboBoxAsignaturas = true;
                }
                NotifyPropertyChanged("SelectedComboBoxCurso");
            }
        }

        public List<ComboBoxItem> _comboBoxAsignaturas = new List<ComboBoxItem>();
        public List<ComboBoxItem> ComboBoxAsignaturas
        {
            get => _comboBoxAsignaturas;
            set
            {
                _comboBoxAsignaturas = value;
                NotifyPropertyChanged("ComboBoxAsignaturas");
            }
        }
        private ComboBoxItem _selectedComboBoxAsig;

        public ComboBoxItem SelectedComboBoxAsig
        {
            get => _selectedComboBoxAsig;
            set
            {
                _selectedComboBoxAsig = value;
                NotifyPropertyChanged("SelectedComboBoxAsig");
            }
        }
        private bool _isEnableComboBoxAsignaturas;

        public bool IsEnableComboBoxAsignaturas
        {
            get { return _isEnableComboBoxAsignaturas; }
            set { _isEnableComboBoxAsignaturas = value; NotifyPropertyChanged("IsEnableComboBoxAsignaturas"); }
        }

        private bool _isEnableButtonBuscarAlum;

        public bool IsEnableButtonBuscarAlum
        {
            get { return _isEnableButtonBuscarAlum; }
            set { _isEnableButtonBuscarAlum = value; NotifyPropertyChanged("IsEnableButtonBuscarAlum"); }
        }


        private List<AsigNotasModel> _dataGridAsigNotas = new List<AsigNotasModel>();
        private Usuario userLogeado;

        public List<AsigNotasModel> DataGridAsigNotas
        {
            get => _dataGridAsigNotas;
            set
            {
                _dataGridAsigNotas = value;
                NotifyPropertyChanged("DataGridAsigNotas");
            }
        }
        public IngNotasViewModel(Usuario userLogeado)
        {
            this.userLogeado = userLogeado;
            ButtonBuscarAlum = new Command(CargarDataGrid, () => true);
            int perfil = userLogeado.Perfiles.PerfilId;
            //define si es un profe o no
            InitPage(perfil);
        }

        private void InitPage(int perfil)
        {
          
            switch (perfil)
            {
                //si es administrador
                case 1:
                    if (_blCursos.ListarCursos().Count > 0)
                    {
                        foreach (Curso c in _blCursos.ListarCursos())
                        {
                            ComboBoxCurso.Add(new ComboBoxItem() {
                                Content = c.Nombre + " - Año: " + c.Anio,
                                Tag = c.CursoCode, ToolTip = c.CursoCode });
                        }
                    }
                    else
                    {
                        MessageBox.Show("No tiene cursos designados");
                    }
                    IsEnableButtonBuscarAlum = false;
                    IsEnableComboBoxAsignaturas = false;
                    break;
                // si es profe
                case 2:
                    List<Curso> cursos = _blCursos.ListarCursosPorProfesor(userLogeado.Rut);
                    if (cursos.Count > 0)
                    {
                        foreach (Curso c in cursos)
                        {
                            ComboBoxCurso.Add(new ComboBoxItem() { Content = c.Nombre+ " - Año:     "+c.Anio,
                                Tag = c.CursoCode, ToolTip = c.CursoCode });
                        }
                    }
                    else
                    {
                        MessageBox.Show("No tiene cursos designados");
                    }
                    IsEnableButtonBuscarAlum = false;
                    IsEnableComboBoxAsignaturas = false;
                break;
            }

        }
        private void CargarComboBoxAsignatura()
        {
            string cursoCode = _selectedComboBoxCurso.Tag.ToString();
            foreach (Asignatura a in _blAsignaturas.ListarAsignaturasPorProfesorYCurso(userLogeado.Rut, cursoCode))
            {
                ComboBoxAsignaturas.Add(new ComboBoxItem()
                {
                    Content = a.Nombre,
                    Tag = a.AsignaturaCode,
                    ToolTip = a.AsignaturaCode
                });
            }
        }
        private void CargarDataGrid()
        {
            DataGridAsigNotas.Clear();
            int rut = int.Parse(_selectedComboBoxAsig.Tag.ToString());
            foreach (Alumno alum in _blAlumnos.ListarAlumnosPorCurso(""))
            {

                DataGridAsigNotas.Add(new AsigNotasModel()
                {
                    Rut = alum.Rut.ToString(),
                    NombreApellido = alum.Nombre + " " + alum.Apellido,
                });
                NotifyPropertyChanged("DataGridAsigCursoProfe");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

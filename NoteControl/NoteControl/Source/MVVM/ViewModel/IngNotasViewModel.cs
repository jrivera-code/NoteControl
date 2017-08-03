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
        private BLNotas _blNotas = new BLNotas();
        private BLAlumnos _blAlumnos = new BLAlumnos();
        private BLCursos _blCursos = new BLCursos();
        private bool _isProfe;
        public Command ButtonBuscarAlum { get; set; }
        private List<ComboBoxItem> _comboBoxCurso = new List<ComboBoxItem>();
        public List<ComboBoxItem> ComboBoxCurso
        {
            get { return _comboBoxCurso; }
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
                    IsEnableComboBoxAsignaturas = true;
                }
                CargarComboBoxAsignatura();
                NotifyPropertyChanged("SelectedComboBoxCurso");
            }
        }
        private bool _isEnableComboBoxCursos;

        public bool IsEnableComboBoxCursos
        {
            get { return _isEnableComboBoxCursos; }
            set { _isEnableComboBoxCursos = value; NotifyPropertyChanged("IsEnableComboBoxCursos"); }
        }

        public List<ComboBoxItem> _comboBoxAsignaturas = new List<ComboBoxItem>();
        public List<ComboBoxItem> ComboBoxAsignaturas
        {
            get { return _comboBoxAsignaturas; }
            set
            {
                _comboBoxAsignaturas = value;
                NotifyPropertyChanged("ComboBoxAsignaturas");
            }
        }
        private ComboBoxItem _selectedComboBoxAsig;

        public ComboBoxItem SelectedComboBoxAsig
        {
            get {return _selectedComboBoxAsig; }
            set
            {
                _selectedComboBoxAsig = value;
                if (_selectedComboBoxAsig != null) {
                    IsEnableButtonBuscarAlum = true;
                }
                else{
                    IsEnableButtonBuscarAlum = false;
                }
               
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
            get { return _dataGridAsigNotas; }
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
            IsEnableComboBoxCursos = true;
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
                            ComboBoxCurso.Add(new ComboBoxItem()
                            {
                                Content = c.Nombre + " - Año: " + c.Anio,
                                Tag = c.CursoCode,
                                ToolTip = c.CursoCode
                            });
                        }
                    }
                    else
                    {
                        IsEnableComboBoxCursos = true;
                    }
                    IsEnableButtonBuscarAlum = false;
                    break;
                // si es profe
                case 2:
                    _isProfe = true;
                    List<Curso> cursos = _blCursos.ListarCursosPorProfesor(userLogeado.Rut);
                    if (cursos.Count > 0)
                    {
                        foreach (Curso c in cursos)
                        {
                            ComboBoxCurso.Add(new ComboBoxItem()
                            {
                                Content = c.Nombre + " - Año: " + c.Anio,
                                Tag = c.CursoCode,
                                ToolTip = c.CursoCode
                            });
                        }
                    }
                    else
                    {
                        //a propiedad enabled de cbcursos false
                       IsEnableComboBoxCursos = false;
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
            ComboBoxAsignaturas.Clear();
            if (_isProfe)
            {
                List<ComboBoxItem> cbListPr = new List<ComboBoxItem>();
                foreach (Asignatura a in _blAsignaturas.ListarAsignaturasPorProfesorYCurso(userLogeado.Rut, cursoCode))
                {
                    cbListPr.Add(new ComboBoxItem()
                    {
                        Content = a.Nombre,
                        Tag = a.AsignaturaCode,
                        ToolTip = a.AsignaturaCode
                    });
                }
                ComboBoxAsignaturas = cbListPr;
            }
            else {
                List<ComboBoxItem> cbList = new List<ComboBoxItem>();
                foreach (Asignatura a in _blAsignaturas.ListarAsignaturasPorCurso(cursoCode))
                {
                    cbList.Add(new ComboBoxItem()
                    {
                        Content = a.Nombre,
                        Tag = a.AsignaturaCode,
                        ToolTip = a.AsignaturaCode
                    });
                }
                ComboBoxAsignaturas = cbList;
            }
       
           
        }
        private void CargarDataGrid()
        {
            
            DataGridAsigNotas.Clear();
            string asig = _selectedComboBoxAsig.Tag.ToString();
            string curso = _selectedComboBoxCurso.Tag.ToString();
            List<AsigNotasModel> list = new List<AsigNotasModel>();
            foreach (Alumno alum in _blAlumnos.ListarAlumnosPorCursoYAsignatura(asig, curso))
            {
                //trae las notas
             List<AlumnoNotaAsignatura> anaList = _blNotas.ListarNotasPorAlumnoCursoAsignatura(curso,asig,alum.Rut);
                // toda la logica de guardar nuevas notas se hace en AsigNotasModel.cs
                list.Add(new AsigNotasModel()
                {
                    AsignaturaCode = asig,
                    Rut = alum.Rut.ToString(),
                    NombreApellido = alum.Nombre + " " + alum.Apellido,
                    Nota1 = (anaList.Exists(e => e.NumeroNota == 1)) ? anaList.Where(e => e.NumeroNota == 1).FirstOrDefault().Calificacion : 0,
                    Nota2 = (anaList.Exists(e => e.NumeroNota == 2)) ? anaList.Where(e => e.NumeroNota == 2).FirstOrDefault().Calificacion : 0,
                    Nota3 = (anaList.Exists(e => e.NumeroNota == 3)) ? anaList.Where(e => e.NumeroNota == 3).FirstOrDefault().Calificacion : 0,
                    Nota4 = (anaList.Exists(e => e.NumeroNota == 4)) ? anaList.Where(e => e.NumeroNota == 4).FirstOrDefault().Calificacion : 0,
                    Nota5 = (anaList.Exists(e => e.NumeroNota == 5)) ? anaList.Where(e => e.NumeroNota == 5).FirstOrDefault().Calificacion : 0,
                    Nota6 = (anaList.Exists(e => e.NumeroNota == 6)) ? anaList.Where(e => e.NumeroNota == 6).FirstOrDefault().Calificacion : 0,
                    Nota7 = (anaList.Exists(e => e.NumeroNota == 7)) ? anaList.Where(e => e.NumeroNota == 7).FirstOrDefault().Calificacion : 0,
                    Nota8 = (anaList.Exists(e => e.NumeroNota == 8)) ? anaList.Where(e => e.NumeroNota == 8).FirstOrDefault().Calificacion : 0,
                    Nota9 = (anaList.Exists(e => e.NumeroNota == 9)) ? anaList.Where(e => e.NumeroNota == 9).FirstOrDefault().Calificacion : 0,
                    Nota10 = (anaList.Exists(e => e.NumeroNota == 10)) ? anaList.Where(e => e.NumeroNota == 10).FirstOrDefault().Calificacion : 0,
                 
                });
            }
           list.ForEach(e => {
                float prom = 0;
                prom += sumarParaForEach(e.Nota1);
                prom += sumarParaForEach(e.Nota2);
                prom += sumarParaForEach(e.Nota3);
                prom += sumarParaForEach(e.Nota4);
                prom += sumarParaForEach(e.Nota5);
                prom += sumarParaForEach(e.Nota6);
                prom += sumarParaForEach(e.Nota7);
                prom += sumarParaForEach(e.Nota8);
                prom += sumarParaForEach(e.Nota9);
                prom += sumarParaForEach(e.Nota10);
                e.Promedio = prom / _countNotZero;
                _countNotZero = 0;
            });
            DataGridAsigNotas = list;
            NotifyPropertyChanged("DataGridAsigNotas");
        }
        private int _countNotZero = 0;
        private float sumarParaForEach(float value)
        {
            //metodo por el cual sacamos el count
            if (value != 0)
            {
                _countNotZero++;
                return value;
            }
            else {
                return 0;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

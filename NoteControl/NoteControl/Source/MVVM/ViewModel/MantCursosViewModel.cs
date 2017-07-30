using NoteControl.Source.BusinessLogic;
using NoteControl.Source.MVVM.Model;
using NoteControl.Source.MVVM.ViewModel.Commands;
using NoteControl.Source.MVVM.ViewModel.DataGridRowModel;
using NoteControl.Source.MVVM.ViewModel.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace NoteControl.Source.MVVM.ViewModel
{

    public class MantCursosViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BLCursos _blCursos = new BLCursos();
        private BLProfesores _blProfesores = new BLProfesores();
        private Curso _cursoEncontrado = null;
        public Command ButtonSaveClick { get; set; }
        public Command ButtonDeleteClick { get; set; }
        public Command ButtonUpdateClick { get; set; }

        private bool _buttonSaveEnable;
        public bool ButtonSaveEnable
        {
            get { return _buttonSaveEnable; }
            set { _buttonSaveEnable = value; NotifyPropertyChanged("ButtonSaveEnable"); }
        }
        private bool _buttonDeleteEnable;
        public bool ButtonDeleteEnable
        {
            get { return _buttonDeleteEnable; }
            set { _buttonDeleteEnable = value; NotifyPropertyChanged("ButtonDeleteEnable"); }
        }
        private bool _buttonUpdateEnable;

        public bool ButtonUpdateEnable
        {
            get { return _buttonUpdateEnable; }
            set { _buttonUpdateEnable = value; NotifyPropertyChanged("ButtonUpdateEnable"); }
        }

        private string _textBoxCodeCurso;
        public string TextBoxCodeCurso
        {
            get
            {
                return _textBoxCodeCurso;
            }
            set
            {
                _textBoxCodeCurso = value.ToUpper();
                NotifyPropertyChanged("TextBoxCodeCurso");
                //consulta si el curso ya existe
                if (!CursoExist(_textBoxCodeCurso))
                {
                    if (_textBoxCodeCurso.Length > 0)
                        ButtonSaveEnable = true;
                    else ButtonSaveEnable = false;
                    ButtonDeleteEnable = false;
                    ButtonUpdateEnable = false;
                    _cursoEncontrado = null;
                    TextBoxNombreCurso = "";
                    TextBoxDescription = "";
                    SelectedComboBoxProfesorJefe = null;
                }
                else
                {
                    //si ya existe desabilita el boton save y activa el update y delete
                    ButtonSaveEnable = false;
                    ButtonDeleteEnable = true;
                    ButtonUpdateEnable = true;
                    //carga los datos del usuario en el formulario
                    CargarDatoCurso();
                }
            }
        }
        private string _textBoxNombreCurso;
        public string TextBoxNombreCurso
        {
            get
            {
                return _textBoxNombreCurso;
            }
            set
            {
                _textBoxNombreCurso = value;
                NotifyPropertyChanged("TextBoxNombreCurso");
            }
        }
        private string _textBoxAnio;
        public string TextBoxAnio
        {
            get
            {
                return _textBoxAnio;
            }
            set
            {
                _textBoxAnio = StaticMethods.NumberValidationTextBox(value);
                NotifyPropertyChanged("TextBoxAnio");
            }
        }
        private string _textBoxDescription;
        public string TextBoxDescription
        {
            get
            {
                return _textBoxDescription;
            }
            set
            {
                _textBoxDescription = value;
                NotifyPropertyChanged("TextBoxDescription");
            }
        }
        private List<CursoRowModel> _dataGridColumnCursos = new List<CursoRowModel>();
        public List<CursoRowModel> DataGridColumnCursos
        {
            get
            {
                return _dataGridColumnCursos;
            }
            set
            {
                _dataGridColumnCursos = value;
                NotifyPropertyChanged("DataGridColumnCursos");
            }
        }
        private List<ComboBoxItem> _comboBoxProfesorJefe = new List<ComboBoxItem>();
        public List<ComboBoxItem> ComboBoxProfesorJefe
        {
            get => _comboBoxProfesorJefe; 
            set { _comboBoxProfesorJefe = value; NotifyPropertyChanged("ComboBoxProfesorJefe"); }
        }
        private ComboBoxItem _selectedComboBoxProfesorJefe = new ComboBoxItem();
        public ComboBoxItem SelectedComboBoxProfesorJefe
        {
            get => _selectedComboBoxProfesorJefe;
            set { _selectedComboBoxProfesorJefe = value; NotifyPropertyChanged("SelectedComboBoxProfesorJefe"); }   
        }

        public MantCursosViewModel()
        {
            //constructor
            CargarDataGrid();
            CargarComboBoxProfeJefe();
            //inicializa los buttons como disabled
            ButtonSaveClick = new Command(SaveClick, () => true);
            ButtonDeleteClick = new Command(DeleteClick, () => true);
            ButtonUpdateClick = new Command(UpdateClick, () => true);
        }
        
        private void UpdateClick()
        {
            int newProfe = int.Parse(_selectedComboBoxProfesorJefe.Tag.ToString());
            Curso curso = new Curso()
            {
                Nombre = _textBoxNombreCurso,
                Descripcion = _textBoxDescription,
                Anio = int.Parse(_textBoxAnio)
            };
            _blCursos.ModificarCurso(curso, _textBoxCodeCurso,newProfe);
            CargarDataGrid();
            NotifyPropertyChanged("DataGridColumnCursos");
        }
        private void CargarComboBoxProfeJefe() {
            _blProfesores.ListarProfesores().ForEach(e=> {
                ComboBoxProfesorJefe.Add(new ComboBoxItem() {
                    Content = e.Nombre+" "+e.Apellido,
                    Tag = e.Rut,
                    ToolTip = "Rut: "+e.Rut
                });
            });
        }

        private void DeleteClick()
        {
            _blCursos.EliminarCurso(_textBoxCodeCurso);
            CargarDataGrid();
            NotifyPropertyChanged("DataGridColumnCursos");
            TextBoxCodeCurso = "";
            SelectedComboBoxProfesorJefe = null;
        }

        private void SaveClick()
        {
            if (_selectedComboBoxProfesorJefe.Tag != null)
            {
                int profesorJefe = int.Parse(_selectedComboBoxProfesorJefe.Tag.ToString());
                Curso curso = new Curso()
                {
                    CursoCode = _textBoxCodeCurso,
                    Nombre = _textBoxNombreCurso,
                    Descripcion = _textBoxDescription
                };
                _blCursos.CrearCurso(curso, profesorJefe);
                CargarDataGrid();
            }
            else {
                MessageBox.Show("No puede guardar sin antes esfecificar un profesro jefe para el curso");
            }
           
            NotifyPropertyChanged("DataGridColumnCursos");
        }
        private bool CursoExist(string text)
        {
            foreach (Curso cur in _blCursos.ListarCursos())
            {
                if (cur.CursoCode == text)
                {
                    _cursoEncontrado = cur;
                    return true;
                }
            }
            return false;
        }
        private void CargarDatoCurso()
        {
            TextBoxNombreCurso = _cursoEncontrado.Nombre;
            TextBoxDescription = _cursoEncontrado.Descripcion;
            TextBoxAnio = _cursoEncontrado.Anio.ToString();
            if (_cursoEncontrado.Profesor != null)
            {
                SelectedComboBoxProfesorJefe = ComboBoxProfesorJefe.Where(p => p.Tag.ToString()
                            == _cursoEncontrado.Profesor.Rut.ToString()).FirstOrDefault();
            }
            else {
                MessageBox.Show("A este curso no se le ha asignado un profesor jefe");
            }
            
        }
        private void CargarDataGrid()
        {
            DataGridColumnCursos.Clear();
            foreach (Curso c in _blCursos.ListarCursos())
            {
                DataGridColumnCursos.Add(new CursoRowModel()
                {
                    CursoCode = c.CursoCode,
                    Nombre = c.Nombre,
                    Description = c.Descripcion
                });
            }
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

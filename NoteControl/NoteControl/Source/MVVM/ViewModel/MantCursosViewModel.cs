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

namespace NoteControl.Source.MVVM.ViewModel
{

    public class MantCursosViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public BLCursos blCursos = new BLCursos();
        private Curso cursoEncontrado = null;
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
                if (!cursoExist(_textBoxCodeCurso))
                {
                    if (_textBoxCodeCurso.Length > 0)
                        ButtonSaveEnable = true;
                    else ButtonSaveEnable = false;
                    ButtonDeleteEnable = false;
                    ButtonUpdateEnable = false;
                    cursoEncontrado = null;
                    TextBoxNombreCurso = "";
                    TextBoxDescription = "";
                }
                else
                {
                    //si ya existe desabilita el boton save y activa el update y delete
                    ButtonSaveEnable = false;
                    ButtonDeleteEnable = true;
                    ButtonUpdateEnable = true;
                    //carga los datos del usuario en el formulario
                    cargarDatoCurso();
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
        public MantCursosViewModel()
        {
            //constructor
            cargarDataGrid();
            //inicializa los buttons como disabled
            ButtonSaveClick = new Command(saveClick, () => true);
            ButtonDeleteClick = new Command(deleteClick, () => true);
            ButtonUpdateClick = new Command(updateClick, () => true);
        }

        private void updateClick()
        {
            Curso curso = new Curso()
            {
                Nombre = _textBoxNombreCurso,
                Descripcion = _textBoxDescription
            };
            blCursos.modificarCurso(curso, _textBoxCodeCurso);
            cargarDataGrid();
            NotifyPropertyChanged("DataGridColumnCursos");
        }

        private void deleteClick()
        {
            blCursos.eliminarCurso(_textBoxCodeCurso);
            cargarDataGrid();
            NotifyPropertyChanged("DataGridColumnCursos");
            TextBoxCodeCurso = "";
        }

        private void saveClick()
        {
           
            Curso curso = new Curso()
            {
                CursoCode = _textBoxCodeCurso,
                Nombre = _textBoxNombreCurso,
                Descripcion = _textBoxDescription
            };
            blCursos.crearCurso(curso);
            cargarDataGrid();
            NotifyPropertyChanged("DataGridColumnCursos");
        }
        private bool cursoExist(string text)
        {
            foreach (Curso cur in blCursos.listarCursos())
            {
                if (cur.CursoCode == text)
                {
                    cursoEncontrado = cur;
                    return true;
                }
            }
            return false;
        }
        private void cargarDatoCurso()
        {
            TextBoxNombreCurso = cursoEncontrado.Nombre;
            TextBoxDescription = cursoEncontrado.Descripcion;
        }
        private void cargarDataGrid()
        {
            DataGridColumnCursos.Clear();
            foreach (Curso c in blCursos.listarCursos())
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

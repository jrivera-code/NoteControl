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
        private string _textBoxCodeCurso;
        public string TextBoxCodeCurso
        {
            get
            {
                return _textBoxCodeCurso;
            }
            set
            {
                _textBoxCodeCurso = value;
                NotifyPropertyChanged("TextBoxCodeCurso");
                //consulta si el curso ya existe
                if (!cursoExist(_textBoxCodeCurso))
                {
                    changeEnableButton();
                    ButtonDeleteClick.methodToDetectCanExecute = () => false;
                    ButtonUpdateClick.methodToDetectCanExecute = () => false;
                    cursoEncontrado = null;
                }
                else
                {
                    //si ya existe desabilita el boton save y activa el update y delete
                    ButtonSaveClick.methodToDetectCanExecute = () => false;
                    ButtonDeleteClick.methodToDetectCanExecute = () => true;
                    ButtonUpdateClick.methodToDetectCanExecute = () => true;
                    //carga los datos del usuario en el formulario
                    cargarDatoUsuario();
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
            ButtonSaveClick = new Command(saveClick, () => false);
            ButtonDeleteClick = new Command(deleteClick, () => false);
            ButtonUpdateClick = new Command(updateClick, () => false);
        }

        private void updateClick()
        {
            Curso curso = new Curso()
            {
                Nombre = _textBoxNombreCurso,
                Descripcion = _textBoxDescription
            };
            blCursos.modificarCurso(curso, _textBoxCodeCurso);
        }

        private void deleteClick()
        {
            blCursos.eliminarCurso(_textBoxCodeCurso);
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
        private void cargarDatoUsuario()
        {
            TextBoxNombreCurso = cursoEncontrado.Nombre;
            TextBoxDescription = cursoEncontrado.Descripcion;
        }
        private void cargarDataGrid()
        {
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
        private void changeEnableButton()
        {
            if (_textBoxCodeCurso.Length > 0)
            {
                ButtonSaveClick.methodToDetectCanExecute = () => true;
            }
            else
            {
                ButtonSaveClick.methodToDetectCanExecute = () => false;
            }
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

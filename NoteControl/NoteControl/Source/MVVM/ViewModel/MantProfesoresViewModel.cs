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

    public class MantProfesoresViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public BLProfesores blProfesores = new BLProfesores();
        private Profesor profesorEncontrado = null;
        public Command ButtonSaveClick { get; set; }
        public Command ButtonDeleteClick { get; set; }
        public Command ButtonUpdateClick { get; set; }
        private string _textBoxRut;
        public string TextBoxRut
        {
            get
            {
                return _textBoxRut;
            }
            set
            {
                _textBoxRut = value;
                NotifyPropertyChanged("TextBoxRut");
                //consulta si el profesor ya existe
                if (!profeExist(_textBoxRut))
                {
                    changeEnableButton();
                    ButtonDeleteClick.methodToDetectCanExecute = () => false;
                    ButtonUpdateClick.methodToDetectCanExecute = () => false;
                    profesorEncontrado = null;
                }
                else
                {
                    //si ya existe desabilita el boton save y activa el update y delete
                    ButtonSaveClick.methodToDetectCanExecute = () => false;
                    ButtonDeleteClick.methodToDetectCanExecute = () => true;
                    ButtonUpdateClick.methodToDetectCanExecute = () => true;
                    //carga los datos del usuario en el formulario
                    cargarDatoProfesor();
                }
            }
        }
        private string _textBoxNombreProfe;
        public string TextBoxNombreProfe
        {
            get
            {
                return _textBoxNombreProfe;
            }
            set
            {
                _textBoxNombreProfe = value;
                NotifyPropertyChanged("TextBoxNombreProfe");
            }
        }
        private string _textBoxApellido;
        public string TextBoxApellido
        {
            get
            {
                return _textBoxApellido;
            }
            set
            {
                _textBoxApellido = value;
                NotifyPropertyChanged("TextBoxApellido");
            }
        }
        private List<ProfeRowModel> _dataGridColumnProfe = new List<ProfeRowModel>();
        public List<ProfeRowModel> DataGridColumnProfe
        {
            get
            {
                return _dataGridColumnProfe;
            }
            set
            {
                _dataGridColumnProfe = value;
                NotifyPropertyChanged("DataGridColumnProfe");
            }
        }
        public MantProfesoresViewModel()
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
            Profesor profesor = new Profesor()
            {
                Nombre = _textBoxNombreProfe,
                Apellido = _textBoxApellido
            };
            blProfesores.modificarProfesor(profesor, _textBoxRut);
            cargarDataGrid();
            NotifyPropertyChanged("DataGridColumnProfe");
        }

        private void deleteClick()
        {
            blProfesores.eliminarProfesor(_textBoxRut);
            cargarDataGrid();
            NotifyPropertyChanged("DataGridColumnProfe");
            TextBoxRut = "";
            TextBoxApellido = "";
            TextBoxNombreProfe = "";
        }

        private void saveClick()
        {

            Profesor profe = new Profesor()
            {
                Rut = int.Parse(_textBoxRut),
                Nombre = _textBoxNombreProfe,
                Apellido = _textBoxApellido
            };
            blProfesores.crearProfesor(profe);
            cargarDataGrid();
            NotifyPropertyChanged("DataGridColumnProfe");
        }
        private bool profeExist(string text)
        {
            foreach (Profesor p in blProfesores.listarProfesores())
            {
                if (p.Rut.ToString() == text)
                {
                    profesorEncontrado = p;
                    return true;
                }
            }
            return false;
        }
        private void cargarDatoProfesor()
        {
            TextBoxNombreProfe = profesorEncontrado.Nombre;
            TextBoxApellido = profesorEncontrado.Apellido;
        }
        private void cargarDataGrid()
        {
            DataGridColumnProfe.Clear();
            foreach (Profesor p in blProfesores.listarProfesores())
            {
                DataGridColumnProfe.Add(new ProfeRowModel()
                {
                    Rut = p.Rut.ToString(),
                    Nombre = p.Nombre,
                    Apellido = p.Apellido
                });
            }
        }
        private void changeEnableButton()
        {
            if (_textBoxRut.Length > 0)
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

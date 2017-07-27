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

    public class MantEspecialidadesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public BLEspecialidades blEspecialidades = new BLEspecialidades();
        private Especialidad especialidadEncontrado = null;
        public Command ButtonSaveClick { get; set; }
        public Command ButtonDeleteClick { get; set; }
        public Command ButtonUpdateClick { get; set; }
        private string _textBoxCode;
        public string TextBoxCode
        {
            get
            {
                return _textBoxCode;
            }
            set
            {
                _textBoxCode = value;
                NotifyPropertyChanged("TextBoxCode");
                //consulta si el especialidad ya existe
                if (!especialidadExist(_textBoxCode))
                {
                    changeEnableButton();
                    ButtonDeleteClick.methodToDetectCanExecute = () => false;
                    ButtonUpdateClick.methodToDetectCanExecute = () => false;
                    especialidadEncontrado = null;
                }
                else
                {
                    //si ya existe desabilita el boton save y activa el update y delete
                    ButtonSaveClick.methodToDetectCanExecute = () => false;
                    ButtonDeleteClick.methodToDetectCanExecute = () => true;
                    ButtonUpdateClick.methodToDetectCanExecute = () => true;
                    //carga los datos de la especialidad en el formulario
                    cargarDatoEspecialidad();
                }
            }
        }
        private string _textBoxNombre;
        public string TextBoxNombre
        {
            get
            {
                return _textBoxNombre;
            }
            set
            {
                _textBoxNombre = value;
                NotifyPropertyChanged("TextBoxNombre");
            }
        }
        private List<EspecialidadRowModel> _dataGridColumnEspecialidad = new List<EspecialidadRowModel>();
        public List<EspecialidadRowModel> DataGridColumnEspecialidad
        {
            get
            {
                return _dataGridColumnEspecialidad;
            }
            set
            {
                _dataGridColumnEspecialidad = value;
                NotifyPropertyChanged("DataGridColumnEspecialidad");
            }
        }
        public MantEspecialidadesViewModel()
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
            Especialidad especialidad = new Especialidad()
            {
                Nombre =  _textBoxNombre
            };
            blEspecialidades.modificarEspecialidad(especialidad, _textBoxCode);
            cargarDataGrid();
            NotifyPropertyChanged("DataGridColumnEspecialidad");
        }

        private void deleteClick()
        {
            blEspecialidades.eliminarEspecialidad(_textBoxCode);
            cargarDataGrid();
            NotifyPropertyChanged("DataGridColumnEspecialidad");
            TextBoxCode = "";
            TextBoxNombre = "";
        }

        private void saveClick()
        {

            Especialidad especialidad = new Especialidad()
            {
                EspecialidadCode = _textBoxCode,
                Nombre = _textBoxNombre
            };
            blEspecialidades.crearEspecialidad(especialidad);
            cargarDataGrid();
            NotifyPropertyChanged("DataGridColumnEspecialidad");

        }
        private bool especialidadExist(string text)
        {
            foreach (Especialidad e in blEspecialidades.listarEspecialidades())
            {
                if (e.EspecialidadCode == text)
                {
                    especialidadEncontrado = e;
                    return true;
                }
            }
            return false;
        }
        private void cargarDatoEspecialidad()
        {
            TextBoxNombre = especialidadEncontrado.Nombre;
        }
        private void cargarDataGrid()
        {
            DataGridColumnEspecialidad.Clear();
            foreach (Especialidad e in blEspecialidades.listarEspecialidades())
            {
                DataGridColumnEspecialidad.Add(new EspecialidadRowModel()
                {
                    EspecialidadCode = e.EspecialidadCode,
                    Nombre = e.Nombre
                });
            }
        }
        private void changeEnableButton()
        {
            if (_textBoxCode.Length > 0)
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
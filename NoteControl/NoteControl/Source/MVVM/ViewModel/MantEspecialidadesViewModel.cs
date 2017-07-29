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
        public BLEspecialidades _blEspecialidades = new BLEspecialidades();
        private Especialidad _especialidadEncontrado = null;
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
                if (!EspecialidadExist(_textBoxCode))
                {
                    ChangeEnableButton();
                    ButtonDeleteClick.methodToDetectCanExecute = () => false;
                    ButtonUpdateClick.methodToDetectCanExecute = () => false;
                    _especialidadEncontrado = null;
                }
                else
                {
                    //si ya existe desabilita el boton save y activa el update y delete
                    ButtonSaveClick.methodToDetectCanExecute = () => false;
                    ButtonDeleteClick.methodToDetectCanExecute = () => true;
                    ButtonUpdateClick.methodToDetectCanExecute = () => true;
                    //carga los datos de la especialidad en el formulario
                    CargarDatoEspecialidad();
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
            CargarDataGrid();
            //inicializa los buttons como disabled
            ButtonSaveClick = new Command(SaveClick, () => false);
            ButtonDeleteClick = new Command(DeleteClick, () => false);
            ButtonUpdateClick = new Command(UpdateClick, () => false);
        }

        private void UpdateClick()
        {
            Especialidad especialidad = new Especialidad()
            {
                Nombre =  _textBoxNombre
            };
            _blEspecialidades.ModificarEspecialidad(especialidad, _textBoxCode);
            CargarDataGrid();
            NotifyPropertyChanged("DataGridColumnEspecialidad");
        }

        private void DeleteClick()
        {
            _blEspecialidades.EliminarEspecialidad(_textBoxCode);
            CargarDataGrid();
            NotifyPropertyChanged("DataGridColumnEspecialidad");
            TextBoxCode = "";
            TextBoxNombre = "";
        }

        private void SaveClick()
        {

            Especialidad especialidad = new Especialidad()
            {
                EspecialidadCode = _textBoxCode,
                Nombre = _textBoxNombre
            };
            _blEspecialidades.CrearEspecialidad(especialidad);
            CargarDataGrid();
            NotifyPropertyChanged("DataGridColumnEspecialidad");

        }
        private bool EspecialidadExist(string text)
        {
            foreach (Especialidad e in _blEspecialidades.ListarEspecialidades())
            {
                if (e.EspecialidadCode == text)
                {
                    _especialidadEncontrado = e;
                    return true;
                }
            }
            return false;
        }
        private void CargarDatoEspecialidad()
        {
            TextBoxNombre = _especialidadEncontrado.Nombre;
        }
        private void CargarDataGrid()
        {
            DataGridColumnEspecialidad.Clear();
            foreach (Especialidad e in _blEspecialidades.ListarEspecialidades())
            {
                DataGridColumnEspecialidad.Add(new EspecialidadRowModel()
                {
                    EspecialidadCode = e.EspecialidadCode,
                    Nombre = e.Nombre
                });
            }
        }
        private void ChangeEnableButton()
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
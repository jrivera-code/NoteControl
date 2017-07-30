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
using System.Windows;
using System.Windows.Controls;

namespace NoteControl.Source.MVVM.ViewModel 
{
    public class MantUsuariosViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BLUsuarios _blUsuarios = new BLUsuarios();
        private BLPerfiles _blPerfiles = new BLPerfiles();
        public Command ButtonSaveClick { get; set; }
        public Command ButtonDeleteClick { get; set; }
        public Command ButtonUpdateClick { get; set; }
        private bool _isEnabledMant;
        public bool IsEnabledMant { get=>_isEnabledMant;
            set { _isEnabledMant = value; NotifyPropertyChanged("IsEnabledMant"); }}

        private bool _isEnabledIng;
        public bool IsEnabledIng
        {
            get => _isEnabledIng;
            set { _isEnabledIng = value; NotifyPropertyChanged("IsEnabledIng"); }
        }
        private bool _isEnabledCon;
        public bool IsEnabledCon
        {
            get => _isEnabledCon;
            set { _isEnabledCon = value; NotifyPropertyChanged("IsEnabledCon"); }
        }
        private bool _isEnabledRep;
        public bool IsEnabledRep
        {
            get => _isEnabledRep;
            set { _isEnabledRep = value; NotifyPropertyChanged("IsEnabledRep"); }
        }
        private bool _isSelectedMant;
        public bool IsSelectedMant
        {
            get => _isSelectedMant;
            set { _isSelectedMant = value; NotifyPropertyChanged("IsSelectedMant"); }
        }

        private bool _isSelectedIng;
        public bool IsSelectedIng
        {
            get => _isSelectedIng;
            set { _isSelectedIng = value; NotifyPropertyChanged("IsSelectedIng"); }
        }
        private bool _isSelectedCon;
        public bool IsSelectedCon
        {
            get => _isSelectedCon;
            set { _isSelectedCon = value; NotifyPropertyChanged("IsSelectedCon"); }
        }
        private bool _isSelectedRep;
        public bool IsSelectedRep
        {
            get => _isSelectedRep;
            set { _isSelectedRep = value; NotifyPropertyChanged("IsSelectedRep"); }
        }
        private Usuario _usuarioEncontrado = null;
        private List<ComboBoxItem> _comboBoxPerfilItems = new List<ComboBoxItem>();
        public List<ComboBoxItem> ComboBoxPerfilItems
        {get { return _comboBoxPerfilItems; }
            set {_comboBoxPerfilItems = value; NotifyPropertyChanged("ComboBoxPerfilItems"); }}
        private ComboBoxItem _selectedComboBoxPerfilItems = new ComboBoxItem();
        public ComboBoxItem SelectedComboBoxPerfilItems{ get { return _selectedComboBoxPerfilItems; }
            set {
                if (_selectedComboBoxPerfilItems == null) return;

                if (value.Content.ToString() == "Profesor") {
                    IsSelectedIng = true; IsSelectedMant = false;
                    IsSelectedCon = false; IsSelectedRep = false; IsEnabledIng = false;
                    IsEnabledMant = true; IsEnabledCon = true; IsEnabledRep = true;
                }
                else if (value.Content.ToString() == "Administrador")
                {
                    IsSelectedIng = true;IsSelectedMant = true;
                    IsSelectedCon = true; IsSelectedRep = true; IsEnabledIng = false;
                    IsEnabledMant = false; IsEnabledCon = false; IsEnabledRep = false;
                }


                _selectedComboBoxPerfilItems = value;
                NotifyPropertyChanged("SelectedComboBoxPerfilItems");
            }
        }
        private List<ComboBoxItem> _comboBoxEstadoItems = new List<ComboBoxItem>();
        public List<ComboBoxItem> ComboBoxEstadoItems
        {
            get { return _comboBoxEstadoItems; }
            set { _comboBoxEstadoItems = value; NotifyPropertyChanged("ComboBoxEstadoItems"); }
        }
        private ComboBoxItem _selectedEstadoItem = new ComboBoxItem();
        public ComboBoxItem SelectedEstadoItem
        {
            get { return _selectedEstadoItem; }
            set { _selectedEstadoItem = value; NotifyPropertyChanged("SelectedEstadoItem"); }
        }
        private bool _buttonDeleteEnable;
        public bool ButtonDeleteEnable
        {
            get { return _buttonDeleteEnable; }
            set {
                _buttonDeleteEnable = value;
                NotifyPropertyChanged("ButtonDeleteEnable"); }
        }
        private bool _buttonUpdateEnable;
        public bool ButtonUpdateEnable
        {
            get { return _buttonUpdateEnable; }
            set
            {
                _buttonUpdateEnable = value;
                NotifyPropertyChanged("ButtonUpdateEnable");
            }
        }
        private bool _buttonSaveEnable;
        public bool ButtonSaveEnable
        {
            get { return _buttonSaveEnable; }
            set
            {
                _buttonSaveEnable = value;
                NotifyPropertyChanged("ButtonSaveEnable");
            }
        }

        public string _textBoxUsuario;
        public string TextBoxUsuario
        {
            get
            {
                return _textBoxUsuario;
            }
            set
            {
                _textBoxUsuario = value.ToUpper();
                NotifyPropertyChanged("TextBoxUsuario");
                //consulta si el nombre de perfil ya existe
                if (!UserExist(_textBoxUsuario))
                {
                    ButtonDeleteEnable = false;
                    ButtonUpdateEnable = false;
                    if (_textBoxUsuario.Length > 0)
                        ButtonSaveEnable = true;
                    else {
                        ButtonSaveEnable = false;
                    } 
                    SelectedEstadoItem = null;
                    _usuarioEncontrado = null;
                }
                else
                {
                    ButtonDeleteEnable = true;
                    ButtonUpdateEnable = true;
                    ButtonSaveEnable = false;
                    //carga los datos del usuario en el formulario
                    CargarDatoUsuario();
                }
            }
        }
     
        private List<UsuarioRowModel> _dataGridColumnUsuarios = new List<UsuarioRowModel>();
        public List<UsuarioRowModel> DataGridColumnUsuarios {
            get
            {
                return _dataGridColumnUsuarios;
            } set {
                _dataGridColumnUsuarios = value;
                NotifyPropertyChanged("DataGridColumnUsuarios");
            }
        }

        public MantUsuariosViewModel() {
            //constructor
            //carga de combobox perfiles
            LoadComboBoxPerfiles();
            //carga de combobox estado
            ComboBoxEstadoItems.Add(new ComboBoxItem() { Content = "Activo" });
            ComboBoxEstadoItems.Add(new ComboBoxItem() { Content = "Desactivado" });
            //inicializa los command para los buttons
            ButtonSaveClick = new Command(SaveClick,() => true);
            ButtonDeleteClick = new Command(DeleteClick, () => true);
            ButtonUpdateClick = new Command(UpdateClick, () => true);
            //carga data grid con los datos de todos los usuarios
            CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            DataGridColumnUsuarios.Clear();
            foreach (Usuario u in _blUsuarios.ListarUsuarios()) {
                string estado = u.Estado == 1 ? "Activo" : "Desactivado";
                DataGridColumnUsuarios.Add(new UsuarioRowModel() {
                    NombreUsuario = u.Nombre,
                    Estado = estado,
                    Perfil = u.Perfiles.Nombre
             });
            }
        }
    
        private void CargarDatoUsuario() {
            foreach (ComboBoxItem item in ComboBoxPerfilItems)
            {
                if (item.Content.ToString() == _usuarioEncontrado.Perfiles.Nombre)
                {
                    SelectedComboBoxPerfilItems = item;
                    break;
                }
            }


            foreach (ComboBoxItem item in ComboBoxEstadoItems)
            {
                string estado = _usuarioEncontrado.Estado == 1 ? "Activo" : "Desactivado";
                if (item.Content.ToString() == estado)
                {
                    SelectedEstadoItem = item;
                    break;
                }
            }

        }
        private void LoadComboBoxPerfiles() {
            List<Perfil> list = _blPerfiles.ListarPerfiles();
            foreach (Perfil p in list) {
         //ademas de guardar crear el content gracias al perfil , guardamos una copia de la instancia en un tag
                ComboBoxPerfilItems.Add(new ComboBoxItem() { Content = p.Nombre});
            }
        }

        private bool UserExist(string text)
        {
            foreach (Usuario user in _blUsuarios.ListarUsuarios())
            {
                if (user.Nombre == text)
                {
                    _usuarioEncontrado = user;
                    return true;
                }
            }
            return false;
        }
    
        private void UpdateClick()
        {
           int estado = SelectedEstadoItem.Content.ToString() == "Activo" ? 1 : 0;
            string perfil = _selectedComboBoxPerfilItems.Content.ToString();
            Usuario user = new Usuario() {
                Nombre = _textBoxUsuario,
                Clave = GetPassword(),
                Estado = estado,
            };
            _blUsuarios.ModificarUser(user,_textBoxUsuario, perfil);
            CargarDataGrid();
            NotifyPropertyChanged("DataGridColumnUsuarios");
        }

        private void DeleteClick()
        {
            _blUsuarios.EliminarUser(_textBoxUsuario);
            CargarDataGrid();
            NotifyPropertyChanged("DataGridColumnUsuarios");
            TextBoxUsuario = "";
        }

        private void SaveClick()
        {
            //si es igual a profesor debe referenciar el rut del usuario al profesor
           // if(_selectedComboBoxPerfilItems.Content.ToString() == "Profesor")
            int estado = SelectedEstadoItem.Content.ToString() == "Activo" ? 1 : 0;
            Usuario user = new Usuario() {
                Nombre = _textBoxUsuario,
                Clave = GetPassword(),
                Estado = estado
        };
            _blUsuarios.CrearUsuario(user, _selectedComboBoxPerfilItems.Content.ToString());
            CargarDataGrid();
            NotifyPropertyChanged("DataGridColumnUsuarios");
        }

        private string GetPassword() {
            PasswordBox passwordBox = new PasswordBox();
            string pass = "";
            if(_usuarioEncontrado == null){
                pass = (ButtonSaveClick.parameters as PasswordBox).Password;
            }
            else {
                pass = (ButtonUpdateClick.parameters as PasswordBox).Password;
            }
            return pass;
        }


        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

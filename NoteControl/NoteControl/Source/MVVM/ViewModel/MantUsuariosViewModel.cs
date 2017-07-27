using NoteControl.Source.BusinessLogic;
using NoteControl.Source.MVVM.Model;
using NoteControl.Source.MVVM.ViewModel.Commands;
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
        BLUsuarios blUsuarios = new BLUsuarios();
        BLPerfiles blPerfiles = new BLPerfiles();
        public Command ButtonSaveClick { get; set; }
        public Command ButtonDeleteClick { get; set; }
        public Command ButtonUpdateClick { get; set; }
        private Usuario usuarioEncontrado = null;
        private List<ComboBoxItem> _comboBoxPerfilItems = new List<ComboBoxItem>();
        public List<ComboBoxItem> ComboBoxPerfilItems
        {
            get { return _comboBoxPerfilItems; }
            set { _comboBoxPerfilItems = value; NotifyPropertyChanged("ComboBoxPerfilItems"); }
        }
        private ComboBoxItem _selectedComboBoxPerfilItems = new ComboBoxItem();
        public ComboBoxItem SelectedComboBoxPerfilItems
        {
            get { return _selectedComboBoxPerfilItems; }
            set {
                if (_selectedComboBoxPerfilItems == value) return;

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
        public string _textBoxUsuario;
        public string TextBoxUsuario
        {
            get
            {
                return _textBoxUsuario;
            }
            set
            {
                _textBoxUsuario = value;
                NotifyPropertyChanged("TextBoxUsuario");
                //consulta si el nombre de perfil ya existe
                if (!userExist(_textBoxUsuario))
                {
                    changeEnableButton();
                    ButtonDeleteClick.methodToDetectCanExecute = () => false;
                    ButtonUpdateClick.methodToDetectCanExecute = () => false;
                    SelectedEstadoItem = null;
                    SelectedComboBoxPerfilItems = null;
                    usuarioEncontrado = null;
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
       public class RowModel {
            string _nombreUsuario;
            string _estado; 
            string _perfil;
            public string NombreUsuario {
                get {
                    return _nombreUsuario;
                } set {
                    _nombreUsuario = value;
                }
            }
            public string Estado
            {
                get
                {
                    return _estado;
                }
                set
                {
                    _estado = value;
                }
            }
            public string Perfil
            {
                get
                {
                    return _perfil;
                }
                set
                {
                    _perfil = value;
                }
            }
        }
        private List<RowModel> _dataGridColumnUsuarios = new List<RowModel>();
        public List<RowModel> DataGridColumnUsuarios {
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
            loadComboBoxPerfiles();
            //carga de combobox estado
            ComboBoxEstadoItems.Add(new ComboBoxItem() { Content = "Activo" });
            ComboBoxEstadoItems.Add(new ComboBoxItem() { Content = "Desactivado" });
            //inicializa los buttons como disabled
            ButtonSaveClick = new Command(saveClick,() => false);
            ButtonDeleteClick = new Command(deleteClick, () => false);
            ButtonUpdateClick = new Command(updateClick, () => false);
            //carga data grid con los datos de todos los usuarios
            cargarDataGrid();
        }

        private void cargarDataGrid()
        {
            foreach (Usuario u in blUsuarios.listarUsuarios()) {
                DataGridColumnUsuarios.Add(new RowModel() {
                    NombreUsuario = u.Nombre,
                    Estado = u.Estado.ToString(),
                    Perfil = u.Perfiles.Nombre
             });
            }
        }

        private void cargarDatoUsuario() {
            foreach (ComboBoxItem item in ComboBoxPerfilItems)
            {
                if (item.Content.ToString() == usuarioEncontrado.Perfiles.Nombre)
                {
                    SelectedComboBoxPerfilItems = item;
                    break;
                }
            }


            foreach (ComboBoxItem item in ComboBoxEstadoItems)
            {
                string estado = usuarioEncontrado.Estado == 1 ? "Activo" : "Desactivado";
                if (item.Content.ToString() == estado)
                {
                    SelectedEstadoItem = item;
                    break;
                }
            }

        }
        private void loadComboBoxPerfiles() {
            List<Perfil> list = blPerfiles.listarPerfiles();
            foreach (Perfil p in list) {
         //ademas de guardar crear el content gracias al perfil , guardamos una copia de la instancia en un tag
                ComboBoxPerfilItems.Add(new ComboBoxItem() { Content = p.Nombre});
            }
        }

        private bool userExist(string text)
        {
            foreach (Usuario user in blUsuarios.listarUsuarios())
            {
                if (user.Nombre == text)
                {
                    usuarioEncontrado = user;
                    return true;
                }
            }
            return false;
        }
        private void changeEnableButton()
        {
            if (_textBoxUsuario.Length > 0)
            {
                ButtonSaveClick.methodToDetectCanExecute = () => true;
            }
            else
            {
                ButtonSaveClick.methodToDetectCanExecute = () => false;
            }
        }
        private void updateClick()
        {
           int estado = SelectedEstadoItem.Content.ToString() == "Activo" ? 1 : 0;
            string perfil = _selectedComboBoxPerfilItems.Content.ToString();
            Usuario user = new Usuario() {
                Nombre = _textBoxUsuario,
                Clave = getPassword(),
                Estado = estado,
            };
            blUsuarios.modificarUser(user,_textBoxUsuario, perfil);
        }

        private void deleteClick()
        {
            blUsuarios.eliminarUser(_textBoxUsuario);
            TextBoxUsuario = "";
        }

        private void saveClick()
        {
            int estado = SelectedEstadoItem.Content.ToString() == "Activo" ? 1 : 0;
            Usuario user = new Usuario() {
                Nombre = _textBoxUsuario,
                Clave = getPassword(),
                Estado = estado
        };
            blUsuarios.crearUsuario(user, _selectedComboBoxPerfilItems.Content.ToString());
      
        }

        private string getPassword() {
            PasswordBox passwordBox = new PasswordBox();
            string pass = "";
            if(usuarioEncontrado == null){
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

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
using System.Globalization;
using System.Windows.Data;

namespace NoteControl.Source.MVVM.ViewModel
{
    public class MantUsuariosViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BLUsuarios _blUsuarios = new BLUsuarios();
        private BLPerfiles _blPerfiles = new BLPerfiles();
        private BLPrivilegiosExtra _blPrivilegiosExtra = new BLPrivilegiosExtra();
        public Command ButtonSaveClick { get; set; }
        public Command ButtonDeleteClick { get; set; }
        public Command ButtonUpdateClick { get; set; }

        private bool _isEnabledMant;
        public bool IsEnabledMant
        {
            get { return _isEnabledMant; }
            set { _isEnabledMant = value; NotifyPropertyChanged("IsEnabledMant"); }
        }

        private bool _isEnabledIng;
        public bool IsEnabledIng
        {
            get { return _isEnabledIng; }
            set { _isEnabledIng = value; NotifyPropertyChanged("IsEnabledIng"); }
        }
        private bool _isEnabledCon;
        public bool IsEnabledCon
        {
            get
			{ return _isEnabledCon; }
            set { _isEnabledCon = value; NotifyPropertyChanged("IsEnabledCon"); }
        }
        private bool _isEnabledRep;
        public bool IsEnabledRep
        {
            get
			{ return _isEnabledRep; }
            set { _isEnabledRep = value; NotifyPropertyChanged("IsEnabledRep"); }
        }
        private bool _isSelectedMant;
        public bool IsSelectedMant
        {
            get
			{ return _isSelectedMant; }
            set { _isSelectedMant = value; NotifyPropertyChanged("IsSelectedMant"); }
        }

        private bool _isSelectedIng;
        public bool IsSelectedIng
        {
            get
			{ return _isSelectedIng; }
            set { _isSelectedIng = value; NotifyPropertyChanged("IsSelectedIng"); }
        }
        private bool _isSelectedCon;
        public bool IsSelectedCon
        {
            get
			{ return _isSelectedCon; }
            set { _isSelectedCon = value; NotifyPropertyChanged("IsSelectedCon"); }
        }
        private bool _isSelectedRep;
        public bool IsSelectedRep
        {
            get
			{ return _isSelectedRep; }
            set { _isSelectedRep = value; NotifyPropertyChanged("IsSelectedRep"); }
        }
        private Usuario _usuarioEncontrado = null;
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
            set
            {
                if (_selectedComboBoxPerfilItems == null) return;

                
                    if (value.Content.ToString() == "Profesor" || value.Content.ToString() == "Secretaria")
                    {
                        IsSelectedIng = true; IsSelectedMant = false;
                        IsSelectedCon = false; IsSelectedRep = false; IsEnabledIng = false;
                        IsEnabledMant = true; IsEnabledCon = true; IsEnabledRep = true;

                    }
                    else if (value.Content.ToString() == "Administrador")
                    {
                        IsSelectedIng = true; IsSelectedMant = true;
                        IsSelectedCon = true; IsSelectedRep = true; IsEnabledIng = false;
                        IsEnabledMant = false; IsEnabledCon = false; IsEnabledRep = false;
                    }
                    _selectedComboBoxPerfilItems = value;
                    NotifyPropertyChanged("SelectedComboBoxPerfilItems");
                
            }
        }
        private void CargaCheckBoxsDePrivExtras()
        {
            List<int> privilegios = new List<int>();
            if (_usuarioEncontrado != null)
            {
                foreach (PrivilegioExtra p in _blPrivilegiosExtra.ListarPrivilegiosExtra(_usuarioEncontrado))
                {
                    privilegios.Add(p.PrivilegioId);
                }
                //buscar si tiene mantenedores
                if (privilegios.Contains(1))
                    IsSelectedMant = true; NotifyPropertyChanged("IsSelectedMant");
                //buscar si tiene Ing notas
                if (privilegios.Contains(5))
                    IsSelectedIng = true;
                //buscar si tiene consultas
                if (privilegios.Contains(6))
                    IsSelectedCon = true;
                //buscar si tiene reportes
                if (privilegios.Contains(8))
                    IsSelectedRep = true;
            }
            else
            {
                // respeta los checkbox desabilitados
                if (IsEnabledMant) IsSelectedMant = false;
                if (IsEnabledIng) IsSelectedIng = false;
                if (IsEnabledCon) IsSelectedCon = false;
                if (IsEnabledRep) IsSelectedRep = false;
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
            set
            {
                _buttonDeleteEnable = value;
                NotifyPropertyChanged("ButtonDeleteEnable");
            }
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
        private string _textBoxRut;
        public string TextBoxRut
        {
            get { return _textBoxRut; }
            set
            {
                _textBoxRut = StaticMethods.NumberValidationTextBox(value);
                NotifyPropertyChanged("TextBoxRut");
                if (!UserExistRut(_textBoxRut))
                {
                    ButtonDeleteEnable = false;
                    ButtonUpdateEnable = false;
                    if (_textBoxRut.Length > 0)
                        ButtonSaveEnable = true;
                    else
                    {
                        ButtonSaveEnable = false;

                    }
                    SelectedEstadoItem = null;
                    _usuarioEncontrado = null;
                    CargaCheckBoxsDePrivExtras();
                }
                else
                {
                    ButtonDeleteEnable = true;
                    ButtonUpdateEnable = true;
                    ButtonSaveEnable = false;
                    //carga los datos del usuario en el formulario
                    CargarDatoUsuario();
                    CargaCheckBoxsDePrivExtras();
                }
            }
        }
        private string _textBoxCorreo;
        public string TextBoxCorreo
        {
            get { return _textBoxCorreo; }
            set
            {
                _textBoxCorreo = value;
                NotifyPropertyChanged("TextBoxCorreo");
            }
        }
        private string _textBoxTelefono;
        public string TextBoxTelefono
        {
            get { return _textBoxTelefono; }
            set
            {
                _textBoxTelefono = value;
                NotifyPropertyChanged("TextBoxTelefono");
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
            }
        }

        private List<UsuarioRowModel> _dataGridColumnUsuarios = new List<UsuarioRowModel>();
        public List<UsuarioRowModel> DataGridColumnUsuarios
        {
            get
            {
                return _dataGridColumnUsuarios;
            }
            set
            {
                _dataGridColumnUsuarios = value;
                NotifyPropertyChanged("DataGridColumnUsuarios");
            }
        }

        public MantUsuariosViewModel()
        {
            //constructor
            //carga de combobox perfiles
            LoadComboBoxPerfiles();
            //carga de combobox estado
            ComboBoxEstadoItems.Add(new ComboBoxItem() { Content = "Activo" });
            ComboBoxEstadoItems.Add(new ComboBoxItem() { Content = "Desactivado" });
            //inicializa los command para los buttons
            ButtonSaveClick = new Command(SaveClick, () => true);
            ButtonDeleteClick = new Command(DeleteClick, () => true);
            ButtonUpdateClick = new Command(UpdateClick, () => true);
            //carga data grid con los datos de todos los usuarios
            CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            DataGridColumnUsuarios.Clear();
            foreach (Usuario u in _blUsuarios.ListarUsuarios())
            {
                string estado = u.Estado == 1 ? "Activo" : "Desactivado";
                DataGridColumnUsuarios.Add(new UsuarioRowModel()
                {
                    Rut = u.Rut.ToString(),
                    NombreUsuario = u.Nombre,
                    Estado = estado,
                    Perfil = u.Perfiles.Nombre,
                    Correo = u.Email,
                    Telefono = u.Telefono
                });
            }
        }

        private void CargarDatoUsuario()
        {
            TextBoxUsuario = _usuarioEncontrado.Nombre;
            TextBoxCorreo = _usuarioEncontrado.Email;
            TextBoxTelefono = _usuarioEncontrado.Telefono;
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
        private void LoadComboBoxPerfiles()
        {
            List<Perfil> list = _blPerfiles.ListarPerfiles();
            foreach (Perfil p in list)
            {
                //ademas de guardar crear el content gracias al perfil , guardamos una copia de la instancia en un tag
                ComboBoxPerfilItems.Add(new ComboBoxItem() { Content = p.Nombre });
            }
        }
        private bool UserExistRut(string text)
        {
            foreach (Usuario user in _blUsuarios.ListarUsuarios())
            {
                if (user.Rut.ToString() == text)
                {
                    _usuarioEncontrado = user;
                    return true;
                }
            }
            return false;
        }

        private void UpdateClick()
        {
            List<bool> checkboxs = new List<bool>()
            {
                IsSelectedMant,IsSelectedIng,IsSelectedCon,IsSelectedRep
            };
            string password = (ButtonUpdateClick.parameters as PasswordBox).Password;
            int estado = SelectedEstadoItem.Content.ToString() == "Activo" ? 1 : 0;
            string perfil = _selectedComboBoxPerfilItems.Content.ToString();
            Usuario user = new Usuario()
            {
                Rut = int.Parse(_textBoxRut),
                Nombre = _textBoxUsuario,
                Clave = password,
                Estado = estado,
                Email = _textBoxCorreo,
                Telefono = _textBoxTelefono
            };
            _blUsuarios.ModificarUser(user, _textBoxUsuario, perfil);
            AsignarPrivilegiosExtras(user, checkboxs, true);
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
            // recibe el arreglo de objetos del multibinding [(Pass),(chkIsChecked)...]
            List<bool> checkboxs = new List<bool>()
            {
                IsSelectedMant,IsSelectedIng,IsSelectedCon,IsSelectedRep
            };
            if (SelectedEstadoItem.Content.ToString() != "")
            {
                //si es igual a profesor debe referenciar el rut del usuario al profesor
                // if(_selectedComboBoxPerfilItems.Content.ToString() == "Profesor")
                int estado = SelectedEstadoItem.Content.ToString() == "Activo" ? 1 : 0;
                Usuario user = new Usuario()
                {
                    Rut = int.Parse(_textBoxRut),
                    Nombre = _textBoxUsuario,
                    Clave = (ButtonSaveClick.parameters as PasswordBox).Password,
                    Telefono = _textBoxTelefono,
                    Email = _textBoxCorreo,
                    Estado = estado
                };
                _blUsuarios.CrearUsuario(user, _selectedComboBoxPerfilItems.Content.ToString());
                //llama al metodo que asigna privilegios extras
                AsignarPrivilegiosExtras(user, checkboxs);
                CargarDataGrid();
                NotifyPropertyChanged("DataGridColumnUsuarios");
            }
            else
            {
                MessageBox.Show("Debe Asignarle un estado");
            }


        }
        private void AsignarPrivilegiosExtras(Usuario user, List<bool> checkboxs, bool update = false)
        {
            if (update)
            {
                _blPrivilegiosExtra.RemoverTodasLasRelaciones(user);
            }
            #region
            //pregunta por si tiene privilegios extras
            for (int i = 0; i < checkboxs.Count; i++)
            {
               
                //se debe enviar un arreglo de int con los id de los privilegios
                if (checkboxs[i])
                {
                    switch (i)
                    {
                        case 0:
                            if (IsEnabledMant)
                                _blPrivilegiosExtra.CrearRelacionUsuarioPrivilegioExtras(user, new int[] { 1, 2, 3, 4 });
                            break;
                        case 1:
                            if (IsEnabledIng)
                                _blPrivilegiosExtra.CrearRelacionUsuarioPrivilegioExtras(user, new int[] { 5 });
                            break;
                        case 2:
                            if (IsEnabledCon)
                                _blPrivilegiosExtra.CrearRelacionUsuarioPrivilegioExtras(user, new int[] { 6, 7 });
                            break;
                        case 3:
                            if (IsEnabledRep)
                                _blPrivilegiosExtra.CrearRelacionUsuarioPrivilegioExtras(user, new int[] { 8 });
                            break;
                    }

                }
            }
            #endregion
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

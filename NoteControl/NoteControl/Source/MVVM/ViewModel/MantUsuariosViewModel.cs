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
        public Command ButtonSaveClick { get; set; }
        public Command ButtonDeleteClick { get; set; }
        public Command ButtonUpdateClick { get; set; }
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
                }
                else
                {
                    ButtonSaveClick.methodToDetectCanExecute = () => false;
                    MessageBox.Show("Este usuario ya existe");
                }

            }
        }
        public MantUsuariosViewModel() {
            ButtonSaveClick = new Command(saveClick,() => false);
            ButtonDeleteClick = new Command(deleteClick, () => false);
            ButtonUpdateClick = new Command(updateClick, () => false);

        }
        private bool userExist(string text)
        {
            foreach (Usuario user in blUsuarios.listarUsuarios())
            {
                if (user.Nombre == text)
                {
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
            throw new NotImplementedException();
        }

        private void deleteClick()
        {
            throw new NotImplementedException();
        }

        private void saveClick()
        {
          
            MessageBox.Show(getPassword());
        }

        private string getPassword() {
            var passwordBox = ButtonSaveClick.parameters as PasswordBox;
            return passwordBox.Password;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

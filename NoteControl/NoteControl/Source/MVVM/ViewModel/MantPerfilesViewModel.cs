using NoteControl.Source.BusinessLogic;
using NoteControl.Source.DataAccess.Source;
using NoteControl.Source.MVVM.Model;
using NoteControl.Source.MVVM.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace NoteControl.Source.MVVM.ViewModel 
{
    public class MantPerfilesViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        BLPerfiles blPerfiles = null;
        public Command ButtonClick { get; set; }
        public bool IsSelectedOne { get; set; }
        public bool IsSelectedTwo { get; set; }
        public bool IsSelectedThree { get; set; }
        public bool IsSelectedFour { get; set; }
        public bool IsSelectedFive { get; set; }
        public bool IsSelectedSix { get; set; }
        public bool IsSelectedSeven { get; set; }
        public bool IsSelectedEigth { get; set; }
        public bool IsSelectedNine { get; set; }
        public bool IsSelectedTen { get; set; }
        public string _textBoxPerfil;
        public string TextBoxPerfil {
            get {
                return _textBoxPerfil;
            }
            set {
                _textBoxPerfil = value;
                NotifyPropertyChanged("TextBoxPerfil");
                //consulta si el nombre de perfil ya existe
                if (!perfilExist(_textBoxPerfil))
                {
                    changeEnableButton();
                }
                else {
                    ButtonClick.methodToDetectCanExecute = () => false;
                    MessageBox.Show("Este perfil ya existe");
                }
               
            }
        }
        public MantPerfilesViewModel()
        {
            blPerfiles = new BLPerfiles();
            //primer parametro el metodo que ejecutara y el segundo si se habilita o no el control
            ButtonClick = new Command(GuardarPerfilMasPrivilegios, () => false);
     
        }

        private bool perfilExist(string text)
        {
            foreach (Perfil perfil in blPerfiles.listarPerfiles()) {
                if (perfil.Nombre == text) {
                    return true;
                }
            }
            return false;
        }
        private void changeEnableButton()
        {
            if (_textBoxPerfil.Length > 0)
            {
                ButtonClick.methodToDetectCanExecute = () => true;
            }
            else
            {
                ButtonClick.methodToDetectCanExecute = () => false;
            }
        }

        private void GuardarPerfilMasPrivilegios()
        {

            if (TextBoxPerfil != "" && TextBoxPerfil != null)
            {
                Perfil perfil = new Perfil() { Nombre = TextBoxPerfil };
                blPerfiles.crearPerfil(perfil);

                List<bool> CheckBoxsIsSelected = new List<bool>();
                CheckBoxsIsSelected.Add(IsSelectedOne);
                CheckBoxsIsSelected.Add(IsSelectedTwo);
                CheckBoxsIsSelected.Add(IsSelectedThree);
                CheckBoxsIsSelected.Add(IsSelectedFour);
                CheckBoxsIsSelected.Add(IsSelectedFive);
                CheckBoxsIsSelected.Add(IsSelectedSix);
                CheckBoxsIsSelected.Add(IsSelectedSeven);
                CheckBoxsIsSelected.Add(IsSelectedEigth);
                CheckBoxsIsSelected.Add(IsSelectedNine);
                CheckBoxsIsSelected.Add(IsSelectedTen);
                int flagId = 1;
                foreach (bool ischecked in CheckBoxsIsSelected)
                {
                    if (ischecked)
                    {
                        BLPerfilPrivilegio blPerfilPrivilegio = new BLPerfilPrivilegio();
                        blPerfilPrivilegio.crearRelacionPerfilPrivilegio(perfil, flagId /*Indice Privilegio*/);
                    }
                    flagId++;
                }
            }
            else {
                MessageBox.Show(""+IsSelectedSix);
            }
            
            
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

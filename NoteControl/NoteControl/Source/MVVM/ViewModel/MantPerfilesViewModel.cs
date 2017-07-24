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
using System.Windows.Forms;

namespace NoteControl.Source.MVVM.ViewModel 
{
    public class MantPerfilesViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CommandBinding ButtonClick { get; set; }
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
   
        public string TextBoxPerfil { get; set; } 
        public MantPerfilesViewModel()
        {
           
            //llama el command binding class para
            //registrar el evento click de boton 
            ButtonClick = new CommandBinding(GuardarPerfilMasPrivilegios);
            //Enable the button click event
            ButtonClick.IsEnabled = true;
           
        }
       
        private void GuardarPerfilMasPrivilegios()
        {

            if (TextBoxPerfil != "" && TextBoxPerfil != null)
            {
                BLPerfiles blPerfiles = new BLPerfiles();
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

        protected void NotifyPropertyChanged(string propertyName)
        {
         
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

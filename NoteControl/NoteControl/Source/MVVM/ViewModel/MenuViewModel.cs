using NoteControl.Source.MVVM.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections.Specialized;
using NoteControl.Source.MVVM.Model;
using NoteControl.Source.BusinessLogic;


namespace NoteControl.Source.MVVM.ViewModel
{
        public class MenuViewModel : INotifyPropertyChanged
          {
        public List<MenuItem> Menus { get; }
        BLPerfiles blPerfiles = new BLPerfiles();

            public MenuViewModel(Usuario usuario)
             {
            Menus = new List<MenuItem>();
            //pasa el perfil del usuario y devuelve la lista de privilegios
            List<Privilegio> listPrivilegios = blPerfiles.listarPrivilegiosDelPerfil(usuario.Perfiles);
            foreach (MenuItem menuitem in crearMenu(listPrivilegios)) {
                if(menuitem.Items.Count != 0)
                Menus.Add(menuitem);
            }
      }
        private List<MenuItem> crearMenu(List<Privilegio> privilegiosList) {
            return crearHeaderItems(crearSubItems(privilegiosList));
        }
        private List<MenuItem> crearHeaderItems(List<MenuItem> items) {
            MenuItem listMantenedores = new MenuItem() {Header = "Mantenedores" };
            MenuItem listNotas = new MenuItem() { Header = "Ingreso de Notas" };
            MenuItem listConsultas = new MenuItem() { Header = "Consultas" };
            MenuItem listInformes = new MenuItem() { Header = "Informes" };
            var mantenedores = from p in items
                    where int.Parse(p.Tag.ToString()) < 6 
                    select p;
            var notas = from p in items
                        where int.Parse(p.Tag.ToString()) > 5 && int.Parse(p.Tag.ToString()) < 8
                        select p;
            var consultas = from p in items
                        where int.Parse(p.Tag.ToString()) > 7 && int.Parse(p.Tag.ToString()) < 10
                        select p;
            var informes = from p in items
                        where int.Parse(p.Tag.ToString()) > 9 
                        select p;
            if (mantenedores != null) {
                foreach(MenuItem m in mantenedores)
                listMantenedores.Items.Add(m);
            }
            if (notas != null) {
                foreach (MenuItem m in notas)
                    listNotas.Items.Add(m);
            }
            if (consultas != null)
            {
                foreach (MenuItem m in consultas)
                    listConsultas.Items.Add(m);
            }
            if (informes != null)
            {
                foreach (MenuItem m in informes)
                    listInformes.Items.Add(m);
            }
            return new List<MenuItem> { listMantenedores, listNotas, listConsultas, listInformes };
        }
        private List<MenuItem> crearSubItems(List<Privilegio> list){
            List<MenuItem> menuItems = new List<MenuItem>();
            foreach (Privilegio p in list) {
                switch (p.PrivilegioId) {
                    case 1:
                        menuItems.Add(new MenuItem() {Header = p.Nombre ,Tag = p.PrivilegioId });
                        break;
                    case 2:
                        menuItems.Add(new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId });
                        break;
                    case 3:
                        menuItems.Add(new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId });
                        break;
                    case 4:
                        menuItems.Add(new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId });
                        break;
                    case 5:
                        menuItems.Add(new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId });
                        break;
                    case 6:
                        menuItems.Add(new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId });
                        break;
                    case 7:
                        menuItems.Add(new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId });
                        break;
                    case 8:
                        menuItems.Add(new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId });
                        break;
                    case 9:
                        menuItems.Add(new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId });
                        break;
                    case 10:
                        menuItems.Add(new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId });
                        break;

                }
            }
            return menuItems;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

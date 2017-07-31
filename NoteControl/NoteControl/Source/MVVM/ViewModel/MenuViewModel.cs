﻿using NoteControl.Source.MVVM.ViewModel.Commands;
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
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NoteControl.Source.MVVM.ViewModel
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        private BLPrivilegiosExtra _blPrivilegiosExtra = new BLPrivilegiosExtra();
        private Usuario userLogeado;
        private Page _frameContent;
        public Page FrameContent
        {
            get
            {
                return _frameContent;
            }
            set
            {
                if (Equals(FrameContent, value))
                {
                    return;
                }

                this._frameContent = value;
                NotifyPropertyChanged("FrameContent");
            }
        }
       
        public List<MenuItem> Menus { get; }
        private BLPerfiles _blPerfiles = new BLPerfiles();
        private string _usuarioLogeado { get; set; }
        public string UsuarioLogeado
        {
            get
            {
                return _usuarioLogeado;
            }
            set
            {
                _usuarioLogeado = value;
                NotifyPropertyChanged("UsuarioLogeado");
            }
        }


        public MenuViewModel(Usuario usuario)
        {
            userLogeado = usuario;
            UsuarioLogeado = userLogeado.Nombre;
            Menus = new List<MenuItem>();
            //pasa el perfil del usuario y devuelve la lista de privilegios
            List<Privilegio> listPrivilegios = _blPerfiles.ListarPrivilegiosDelPerfil(userLogeado.Perfiles);
            List<PrivilegioExtra> listPrivilegiosExtra = _blPrivilegiosExtra.ListarPrivilegiosExtra(userLogeado);
            int countIcon = 0;
            foreach (MenuItem menuitem in CrearMenu(listPrivilegios))
            {
                string url = "pack://application:,,,/NoteControl;component/Source/MVVM/View/Img/Icons/";
                string[] iconName = { "mant_icon", "add_note", "search", "report" };
                if (menuitem.Items.Count != 0)
                {
                    menuitem.Icon = new Image
                    {
                        Source = new BitmapImage(new Uri(url + iconName[countIcon] + ".png"))
                    };
                    Menus.Add(menuitem);
                }
                countIcon++;
            }
        }
        
        private List<MenuItem> CrearMenu(List<Privilegio> privilegiosList)
        {
            return CrearHeaderItems(CrearSubItems(privilegiosList));
        }
        private List<MenuItem> CrearHeaderItems(List<MenuItem> items)
        {
            MenuItem listMantenedores = new MenuItem() { Header = "Mantenedores" };
            MenuItem listNotas = new MenuItem() { Header = "Ingreso de Notas" };
            MenuItem listConsultas = new MenuItem() { Header = "Consultas" };
            MenuItem listInformes = new MenuItem() { Header = "Informes" };
            var mantenedores = from p in items
                               where int.Parse(p.Tag.ToString()) < 5
                               select p;
            var notas = from p in items
                        where int.Parse(p.Tag.ToString()) == 5 
                        select p;
            var consultas = from p in items
                            where int.Parse(p.Tag.ToString()) > 5 && int.Parse(p.Tag.ToString()) < 7
                            select p;
            var informes = from p in items
                           where int.Parse(p.Tag.ToString()) > 7
                           select p;
            if (mantenedores != null)
            {
                foreach (MenuItem m in mantenedores)
                    listMantenedores.Items.Add(m);
            }
            if (notas != null)
            {
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
        private List<MenuItem> CrearSubItems(List<Privilegio> list)
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            foreach (Privilegio p in list)
            {
                MenuItem item;
                switch (p.PrivilegioId)
                {

                    case 1:
                        item = new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId };
                        item.Click += ClickMenuItem;
                        menuItems.Add(item);
                        break;
                    case 2:
                        item = new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId };
                        item.Click += ClickMenuItem;
                        menuItems.Add(item);
                        break;
                    case 3:
                        item = new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId };
                        item.Click += ClickMenuItem;
                        menuItems.Add(item);
                        break;
                    case 4:
                        item = new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId };
                        item.Click += ClickMenuItem;
                        menuItems.Add(item);
                        break;
                    case 5:
                        item = new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId };
                        item.Click += ClickMenuItem;
                        menuItems.Add(item);
                        break;
                    case 6:
                        item = new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId };
                        item.Click += ClickMenuItem;
                        menuItems.Add(item);
                        break;
                    case 7:
                        item = new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId };
                        item.Click += ClickMenuItem;
                        menuItems.Add(item);
                        break;
                    case 8:
                        item = new MenuItem() { Header = p.Nombre, Tag = p.PrivilegioId };
                        item.Click += ClickMenuItem;
                        menuItems.Add(item);
                        break;
                }
            }
            return menuItems;
        }
        private void ClickMenuItem(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            int id = int.Parse(item.Tag.ToString());
            switch (id)
            {
                case 1:
                    FrameContent = new MantUsuario();
                    break;
                case 2:
                    FrameContent = new MantCurso();
                    break;
                case 3:
                    FrameContent = new MantProfe();
                    break;
                case 4:
                    FrameContent = new MantEspecialidades();
                    break;
                case 5:
                    FrameContent = new IngNotas(userLogeado);
                    break;
                case 6:
                    FrameContent = new ConsAlumCurso();
                    break;
                case 7:
                    FrameContent = new ConsProfeCurso();
                    break;
                case 8:
                    FrameContent = new InformeParcial();
                    break;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

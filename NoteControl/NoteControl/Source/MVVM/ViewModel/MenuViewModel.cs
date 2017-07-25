using NoteControl.Source.MVVM.Model.ControlsModel;
using NoteControl.Source.MVVM.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteControl.Source.MVVM.ViewModel
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MenulModel> _Menus;
        public ObservableCollection<MenulModel> Menus
        {
            get { return _Menus; }
            set
            {
                _Menus = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Menus")); ;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MenuViewModel() { InitializeMenus(); }

        private void InitializeMenus()
        {
            if (Menus == null) Menus = new ObservableCollection<MenulModel>();
            Menus.Add(
             new MenulModel()
             {
                 MenuLabel = "Menu 1",
                 SucMenus = new ObservableCollection<MenulModel>()
              {
      new MenulModel()
      {
       MenuLabel = "Sub Menu 1",
       MenuCommand = new RelayCommand(p => { MessageBox.Show("Click Menu 1 -> Sub Menu 1"); }, p => true)
      },
      new MenulModel()
      {
       MenuLabel = "Sub Menu 2",
       MenuCommand = new RelayCommand(p => { MessageBox.Show("Click Menu 1 -> Sub Menu 2"); }, p => true)
      }
              }
             });
            Menus.Add(
             new MenulModel()
             {
                 MenuLabel = "Menu 2",
                 SucMenus = new ObservableCollection<MenulModel>()
              {
      new MenulModel()
      {
       MenuLabel = "Sub Menu 1",
       MenuCommand = new RelayCommand(p => { MessageBox.Show("Click Menu 2 -> Sub Menu 1"); }, p => true)
      },
      new MenulModel()
      {
       MenuLabel = "Sub Menu 2",
       MenuCommand = new RelayCommand(p => { MessageBox.Show("Click Menu 2 -> Sub Menu 2"); }, p => true)
      }
              }
             });
            // ......
        }

        // Other methods...
    }
}

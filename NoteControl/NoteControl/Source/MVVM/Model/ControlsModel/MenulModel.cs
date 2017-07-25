using NoteControl.Source.MVVM.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.Model.ControlsModel
{
    public class MenulModel : INotifyPropertyChanged
    {
        private string _MenuLabel;
        public string MenuLabel
        {
            get { return _MenuLabel; }
            set
            {
                _MenuLabel = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MenuLabel"));
            }
        }

        public ObservableCollection<MenulModel> SucMenus { get; set; }

        public RelayCommand MenuCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        // Other properties ...
    }
}

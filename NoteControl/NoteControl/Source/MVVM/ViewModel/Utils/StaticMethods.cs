using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.ViewModel.Utils
{
    public static class StaticMethods
    {
        public static string NumberValidationTextBox(string value)
        {
            Regex regex = new Regex("[^0-9]+");
            return (regex.IsMatch(value)) ? null : value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NoteControl.Source.MVVM.ViewModel.Converters
{
    public class FloatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (float)value;
            return val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string formatValue = value.ToString().Replace(".", "");
            var val = formatValue.Substring(0, 1) +"."+ formatValue.Substring(1);
            float floatValidate = float.Parse(val);
            if (floatValidate > 9 && floatValidate < 71)
            {
                return val;
            }
            else
            {
                MessageBox.Show("Formato de nota invalido");
                return false;
            }
        }
           
        }
    }


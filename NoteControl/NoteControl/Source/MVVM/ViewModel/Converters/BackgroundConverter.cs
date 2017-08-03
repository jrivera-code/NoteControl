using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace NoteControl.Source.MVVM.ViewModel.Converters
{
    public class BackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float nota = 0;
            string color = "";
            try {
                nota = (float)value;
                if (nota > 0.9 && nota < 7.1)
                {
                    if (nota > 0.9 && nota < 4.1)
                    {
                        color = "#F6697A";
                    }
                    else if (nota > 3.9 && nota < 7.1)
                    {
                        color = "#BCC3FF";
                    }
                }
                else if (nota == 0) {
                    color = "#ffffff";
                }
                else
                {
                    color = "#ffffff";
                }
            } catch {

            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;

namespace Vistas
{
    public class ConversorDeEstados : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo Culture)
        {
            String estado = (String)value;

            if (value != null)
            {
                switch (estado.ToString()){
                    case "Libre": return new SolidColorBrush(Colors.Green); 
                    case "Reservada": return new SolidColorBrush(Colors.Orange); 
                    case "Ocupada": return new SolidColorBrush(Colors.Red); 
                    case "Pidiendo": return new SolidColorBrush(Colors.Fuchsia); 
                    case "En espera": return new SolidColorBrush(Colors.GreenYellow); 
                    case "Servidos": return new SolidColorBrush(Colors.Salmon); 
                    case "Esperando Cuenta": return new SolidColorBrush(Colors.RoyalBlue); 
                    case "Pagando": return new SolidColorBrush(Colors.Olive); 
                }
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo Culture)
        {
            return Binding.DoNothing;
        }
    }
}

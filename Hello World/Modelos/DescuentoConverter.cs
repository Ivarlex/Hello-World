using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Hello_World.Modelos
{
    public class DescuentoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal precio && parameter is JuegoPromocion juego && juego.en_oferta)
            {
                return precio * 0.8m;
            }
            return value; // Devuelve el precio original si no hay oferta
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
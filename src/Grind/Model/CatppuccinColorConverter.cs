using CommunityToolkit.Maui;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Model
{
    public class CatppuccinColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = value.ToString();

            if (Application.Current.UserAppTheme == AppTheme.Light)
            {
                return color switch
                {
                    "Rosewater" => Color.FromRgb(220, 138, 120),
                    "Flamingo" => Color.FromRgb(221, 120, 120),
                    "Pink" => Color.FromRgb(234, 118, 203),
                    "Mauve" => Color.FromRgb(136, 57, 239),
                    "Red" => Color.FromRgb(210, 15, 57),
                    "Maroon" => Color.FromRgb(230, 69, 83),
                    "Peach" => Color.FromRgb(254, 100, 11),
                    "Yellow" => Color.FromRgb(223, 142, 29),
                    "Green" => Color.FromRgb(64, 160, 43),
                    "Teal" => Color.FromRgb(23, 146, 153),
                    "Sky" => Color.FromRgb(4, 165, 229),
                    "Sapphire" => Color.FromRgb(32, 159, 181),
                    "Blue" => Color.FromRgb(30, 102, 245),
                    "Lavender" => Color.FromRgb(114, 135, 253),
                    _ => Colors.White,
                };
            }
            else
            {
                return color switch
                {
                    "Rosewater" => Color.FromRgb(244, 219, 214),
                    "Flamingo" => Color.FromRgb(240, 198, 198),
                    "Pink" => Color.FromRgb(245, 189, 230),
                    "Mauve" => Color.FromRgb(198, 160, 246),
                    "Red" => Color.FromRgb(237, 135, 150),
                    "Maroon" => Color.FromRgb(238, 153, 160),
                    "Peach" => Color.FromRgb(245, 169, 127),
                    "Yellow" => Color.FromRgb(238, 212, 159),
                    "Green" => Color.FromRgb(166, 218, 149),
                    "Teal" => Color.FromRgb(139, 213, 202),
                    "Sky" => Color.FromRgb(145, 215, 227),
                    "Sapphire" => Color.FromRgb(125, 196, 228),
                    "Blue" => Color.FromRgb(138, 173, 244),
                    "Lavender" => Color.FromRgb(183, 189, 248),
                    _ => Colors.White,
                };
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public static Color GetColor(string value)
        {
            if (Application.Current.UserAppTheme.Equals(AppTheme.Light))
            {
                return value switch
                {
                    "Rosewater" => Color.FromRgb(220, 138, 120),
                    "Flamingo" => Color.FromRgb(221, 120, 120),
                    "Pink" => Color.FromRgb(234, 118, 203),
                    "Mauve" => Color.FromRgb(136, 57, 239),
                    "Red" => Color.FromRgb(210, 15, 57),
                    "Maroon" => Color.FromRgb(230, 69, 83),
                    "Peach" => Color.FromRgb(254, 100, 11),
                    "Yellow" => Color.FromRgb(223, 142, 29),
                    "Green" => Color.FromRgb(64, 160, 43),
                    "Teal" => Color.FromRgb(23, 146, 153),
                    "Sky" => Color.FromRgb(4, 165, 229),
                    "Sapphire" => Color.FromRgb(32, 159, 181),
                    "Blue" => Color.FromRgb(30, 102, 245),
                    "Lavender" => Color.FromRgb(114, 135, 253),
                    _ => Colors.White,
                };
            }
            else
            {
                return value switch
                {
                    "Rosewater" => Color.FromRgb(244, 219, 214),
                    "Flamingo" => Color.FromRgb(240, 198, 198),
                    "Pink" => Color.FromRgb(245, 189, 230),
                    "Mauve" => Color.FromRgb(198, 160, 246),
                    "Red" => Color.FromRgb(237, 135, 150),
                    "Maroon" => Color.FromRgb(238, 153, 160),
                    "Peach" => Color.FromRgb(245, 169, 127),
                    "Yellow" => Color.FromRgb(238, 212, 159),
                    "Green" => Color.FromRgb(166, 218, 149),
                    "Teal" => Color.FromRgb(139, 213, 202),
                    "Sky" => Color.FromRgb(145, 215, 227),
                    "Sapphire" => Color.FromRgb(125, 196, 228),
                    "Blue" => Color.FromRgb(138, 173, 244),
                    "Lavender" => Color.FromRgb(183, 189, 248),
                    _ => Colors.White,
                };
            }
        }

        public static Color GetLatteColor(string value)
        {
            return value switch
            {
                "Rosewater" => Color.FromRgb(220, 138, 120),
                "Flamingo" => Color.FromRgb(221, 120, 120),
                "Pink" => Color.FromRgb(234, 118, 203),
                "Mauve" => Color.FromRgb(136, 57, 239),
                "Red" => Color.FromRgb(210, 15, 57),
                "Maroon" => Color.FromRgb(230, 69, 83),
                "Peach" => Color.FromRgb(254, 100, 11),
                "Yellow" => Color.FromRgb(223, 142, 29),
                "Green" => Color.FromRgb(64, 160, 43),
                "Teal" => Color.FromRgb(23, 146, 153),
                "Sky" => Color.FromRgb(4, 165, 229),
                "Sapphire" => Color.FromRgb(32, 159, 181),
                "Blue" => Color.FromRgb(30, 102, 245),
                "Lavender" => Color.FromRgb(114, 135, 253),
                _ => Colors.White,
            };
        }

        public static Color GetMacchiatoColor(string value)
        {
            return value switch
            {
                "Rosewater" => Color.FromRgb(244, 219, 214),
                "Flamingo" => Color.FromRgb(240, 198, 198),
                "Pink" => Color.FromRgb(245, 189, 230),
                "Mauve" => Color.FromRgb(198, 160, 246),
                "Red" => Color.FromRgb(237, 135, 150),
                "Maroon" => Color.FromRgb(238, 153, 160),
                "Peach" => Color.FromRgb(245, 169, 127),
                "Yellow" => Color.FromRgb(238, 212, 159),
                "Green" => Color.FromRgb(166, 218, 149),
                "Teal" => Color.FromRgb(139, 213, 202),
                "Sky" => Color.FromRgb(145, 215, 227),
                "Sapphire" => Color.FromRgb(125, 196, 228),
                "Blue" => Color.FromRgb(138, 173, 244),
                "Lavender" => Color.FromRgb(183, 189, 248),
                _ => Colors.White,
            };
        }
    }
}

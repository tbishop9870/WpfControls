using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfControls.Utilities
{
    internal static class VisibilityHelper
    {
        public static bool IsTrue(object value, object param)
        {
            if (value is bool)
            {
                return (bool) value;
            }

            var str = value as string;
            if (str != null)
            {
                return !string.IsNullOrWhiteSpace(str);
            }

            if (value is int)
            {
                if (param is double)
                {
                    return (int)value > (double)param;
                }
                if (param is int)
                {
                    return (int)value > (int)param;
                }
                return (int)value > 0;
            }

            if (value is double)
            {
                if (param is double)
                {
                    return (double)value > (double)param;
                }
                if (param is int)
                {
                    return (double)value > (int)param;
                }
                return (double)value > 0;
            }

            var enumerable = value as IEnumerable;
            if (enumerable != null)
            {
                return enumerable.Cast<object>().Any();
            }

            return value != null;
        }
    }
    public class GeneralVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return VisibilityHelper.IsTrue(value, parameter) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class InvertedGeneralVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return VisibilityHelper.IsTrue(value, parameter) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class GeneralVisibilityMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.All(v => VisibilityHelper.IsTrue(v, parameter)) ? Visibility.Visible : Visibility.Hidden;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class InvertedGeneralVisibilityMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Any(v => VisibilityHelper.IsTrue(v, parameter)) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

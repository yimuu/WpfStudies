using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SortVisualization
{
    public class ItemIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is DependencyObject obj)
            {
                var container = ItemsControl.ItemsControlFromItemContainer(obj);
                var index = container.ItemContainerGenerator.IndexFromContainer(obj);
                return (index + 1) * 50;
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("This converter only works for one-way binding.");
        }
    }
}

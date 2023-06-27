using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Commands
{
    /// <summary>
    /// Interaction logic for CustomCommand.xaml
    /// </summary>
    public partial class CustomCommand : Window
    {
        public CustomCommand()
        {
            InitializeComponent();
        }

        private void RequeryCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Requery");
        }
    }

    public class DataCommands
    {
        private static readonly RoutedCommand requery;

        static DataCommands ()
        {
            InputGestureCollection inputs = new();
            inputs.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl+R"));
            requery = new RoutedUICommand("Requery", "Requery", typeof(DataCommands), inputs);
        }

        public static RoutedCommand Requery => requery;
    }
}

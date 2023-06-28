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

namespace Recources
{
    /// <summary>
    /// Interaction logic for DynamicResource.xaml
    /// </summary>
    public partial class DynamicResource : Window
    {
        public DynamicResource()
        {
            InitializeComponent();
        }

        private void CmdChange_Click(object sender, RoutedEventArgs e)
        {
            //this.Resources["TileBrush"] = new SolidColorBrush(Colors.Red);

            this.Resources["TileBrush"] = (ImageBrush)Application.Current.FindResource("TileBrush2");

            //ImageBrush brush = (ImageBrush)this.Resources["TileBrush"];
            //brush.Viewport = new Rect(0, 0, 5, 5);            
        }
    }
}

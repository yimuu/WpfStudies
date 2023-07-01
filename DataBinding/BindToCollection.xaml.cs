using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BindToCollection : Window
    {
        public BindToCollection()
        {
            InitializeComponent();
        }

        private ObservableCollection<Product>? products;

        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            products = products = new ObservableCollection<Product>(Product.GetProducts());
            lstProducts.ItemsSource = products;
        }

        private void cmdDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            products?.Remove((Product)lstProducts.SelectedItem);
        }

        private void cmdAddProduct_Click(object sender, RoutedEventArgs e)
        {
            products?.Add(new Product("00000", "?", "?", 0));
        }

        private bool isDirty = false;
        private void txt_TextChanged(object sender, RoutedEventArgs e)
        {
            isDirty = true;
        }

        private void lstProducts_SelectionChanged(object sender, RoutedEventArgs e)
        {
            isDirty = false;
        }
    }
}

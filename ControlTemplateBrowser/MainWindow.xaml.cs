using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace ControlTemplateBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Type controlType = typeof(Control);
            List<Type> derivedTypes = new List<Type>();

            // Search all the types in the assembly where the COntrol class is defined.
            Assembly? assembly = Assembly.GetAssembly(typeof(Control));
            foreach(Type type in assembly.GetTypes())
            {
                // Only add a type of the list if it's a Control, a concrete class, and public
                if (type.IsSubclassOf(controlType) && !type.IsAbstract && type.IsPublic)
                {
                    derivedTypes.Add(type);
                }
            }

            // Sort the types by type name.
            derivedTypes.Sort((x, y) => x.Name.CompareTo(y.Name));

            // Show the list of types.
            lstTypes.ItemsSource = derivedTypes;
        }

        private void lstTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Get the selected type.
                Type type = (Type)lstTypes.SelectedItem;

                // Instantiate the type
                ConstructorInfo? info = type.GetConstructor(Type.EmptyTypes);
                Control control = (Control)info.Invoke(null);

                Window? win = control as Window;
                if (win != null)
                {
                    // Create the window (but keep it minmized).
                    win.WindowState = WindowState.Minimized;
                    win.ShowInTaskbar = false;
                    win.Show();
                }
                else
                {
                    // Add it to the grid (but keep it hidden).
                    control.Visibility = Visibility.Collapsed;
                    grid.Children.Add(control);
                }

                // Get the template
                ControlTemplate template = control.Template;

                // Get the XAML for the template.
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                StringBuilder sb = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(sb, settings);
                XamlWriter.Save(template, writer);

                // Displat the template.
                txtTemplate.Text = sb.ToString();

                // Remove the control form the grid.
                if (win != null)
                {
                    win.Close();
                }
                else
                {
                    grid.Children.Remove(control);
                }
            }
            catch (Exception ex)
            {
                txtTemplate.Text = "<< Error generating template: " + ex.Message + ">>";
            }
        }
    }
}

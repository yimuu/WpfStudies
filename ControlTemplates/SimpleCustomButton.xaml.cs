﻿using System;
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

namespace ControlTemplates
{
    /// <summary>
    /// Interaction logic for SimpleCustomButton.xaml
    /// </summary>
    public partial class SimpleCustomButton : Window
    {
        public SimpleCustomButton()
        {
            InitializeComponent();
        }

        private void Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You clicked " + ((Button)sender).Name);
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

namespace SortVisualization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.SizeChanged += MainWindow_SizeChanged;
        }


        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MessageBox.Show("Size Changed");
        }
    }

    public class ViewModel : ObservableObject
    {
        private ObservableCollection<int> numbers = new() { 5, 11, 20, 18, 30, 14, 9, 17, 22 };
        private int count = 10;
        public ObservableCollection<int> Numbers
        {
            get => numbers;
            set => SetProperty(ref numbers, value);
        }

        public int Count
        {
            get => count;
            set => SetProperty(ref count, value);
        }

        public RelayCommand ExchangeItemCommand { get; }

        public AsyncRelayCommand SortItemCommand { get; }

        public ViewModel()
        {
            ExchangeItemCommand = new RelayCommand(ExcnahgeItem);
            SortItemCommand = new AsyncRelayCommand(InsertionSortAsync);
        }

        private void ExcnahgeItem()
        {
            var item1 = Numbers[0];
            Numbers[0] = Numbers[3];
            Numbers[3] = item1;
        }

        public async Task InsertionSortAsync()
        {
            for (int i = 1; i < Numbers.Count; i++)
            {
                int key = Numbers[i];
                int j = i - 1;

                // 将较大的数字右移
                while (j >= 0 && Numbers[j] > key)
                {
                    Numbers[j + 1] = Numbers[j];
                    j--;
                    await Task.Delay(200); // 延迟一段时间以实现动画效果
                }

                Numbers[j + 1] = key;
            }
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AlgorytmMrowkowyMinMax.ViewModel;

namespace AlgorytmMrowkowyMinMax
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Bez_przeszkod_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new BezPrzeszkodViewModel();
        }

        private void Statyczna_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new StatyczneViewModel();
        }

        private void DynamicznaCliked(object sender, RoutedEventArgs e)
        {
            DataContext = new DynamiczneViewModel();
        }
    }
}

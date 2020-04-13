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

namespace KolomyyaTrees
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            labelTreesKPD.Content = "syka";
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TreesListButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TreeAddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TreesMapButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

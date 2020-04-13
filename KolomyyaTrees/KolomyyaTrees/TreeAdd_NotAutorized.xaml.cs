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
    /// Логика взаимодействия для TreeAdd_NotAutorized.xaml
    /// </summary>
    public partial class TreeAdd_NotAutorized : Window
    {
        public TreeAdd_NotAutorized()
        {
            InitializeComponent();
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            HomePage_NotAutorized hmPageNA = new HomePage_NotAutorized();
            hmPageNA.Show();
            Close();
        }

        private void TreesListButton_Click(object sender, RoutedEventArgs e)
        {
            TreesList_NotAutorized trlistNA = new TreesList_NotAutorized();
            trlistNA.Show();
            Close();
        }

        private void TreeAddButton_Click(object sender, RoutedEventArgs e)
        {
            TreeAdd_NotAutorized trAddNA = new TreeAdd_NotAutorized();
            trAddNA.Show();
            Close();
        }

        private void TreesMapButton_Click(object sender, RoutedEventArgs e)
        {
            TreesMap_NotAutorized trMapNA = new TreesMap_NotAutorized();
            trMapNA.Show();
            Close();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

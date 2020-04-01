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
    /// Логика взаимодействия для TreeAdd.xaml
    /// </summary>
    public partial class TreeAdd : Window
    {
        public TreeAdd()
        {
            InitializeComponent();
        }

        private void textBoxPoroda_DragEnter(object sender, DragEventArgs e)
        {
            //labelTreeAdd.Visibility = Visibility.Visible;
        }

        private void textBoxPoroda_DragLeave(object sender, DragEventArgs e)
        {
            //labelTreeAdd.Visibility = Visibility.Hidden;
            //labelTreeAdd.Content = "pizda";
        }

        private void textBoxPoroda_LostFocus(object sender, RoutedEventArgs e)
        {
            labelTreeAdd.Visibility = Visibility.Visible;
        }

        private void textBoxPoroda_MouseLeave(object sender, MouseEventArgs e)
        {
            labelTreeAdd.Visibility = Visibility.Hidden;
            labelTreeAdd.Content = "pizda";
        }

        private void textBoxPoroda_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxPoroda.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

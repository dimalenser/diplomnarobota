using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для TreesMap.xaml
    /// </summary>
    public partial class TreesMap : Window
    {
        public TreesMap()
        {
            InitializeComponent();

            labelTreeCountUpdate();
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            HomePage hmPage = new HomePage();
            hmPage.Show();
            Close();
        }

        private void TreesListButton_Click(object sender, RoutedEventArgs e)
        {
            TreesList trlist = new TreesList();
            trlist.Show();
            Close();
        }

        private void TreeAddButton_Click(object sender, RoutedEventArgs e)
        {
            TreeAdd trAdd = new TreeAdd();
            trAdd.Show();
            Close();
        }

        private void TreesMapButton_Click(object sender, RoutedEventArgs e)
        {
            TreesMap trMap = new TreesMap();
            trMap.Show();
            Close();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void labelTreeCountUpdate()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `trees`", db.GetConnection());
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            int treeN = 0;
            while (reader.Read())
            {
                // выводим данные столбцов текущей строки в listBox1
                treeN++;
            }
            reader.Close();
            db.closeConnection();
            labelTreesKPD.Content = $"До нашої бази даних занесено {treeN - 1} дерев";
        }
    }
}

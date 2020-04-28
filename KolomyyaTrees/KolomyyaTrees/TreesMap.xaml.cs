using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Data;
using MySql.Data.MySqlClient;

namespace KolomyyaTrees
{
    /// <summary>
    /// Логика взаимодействия для TreesMap.xaml
    /// </summary>
    public partial class TreesMap : Window
    {
        String sURL = AppDomain.CurrentDomain.BaseDirectory + "html/map.html"; // Способ 2 як відкрити хтмл файл (нема помилкі скрипта)
        public TreesMap()
        {
            InitializeComponent();

            labelTreeCountUpdate();

            /* Способ 1 як відкрити хтмл файл
            string curDir = Directory.GetCurrentDirectory();
            //dimaweb.Silent = true;
            this.dimaweb.Navigate(new Uri(String.Format("file:///{0}/html/dimatest.html", curDir)));
            */

            string curDir = Directory.GetCurrentDirectory(); // Способ 2 як відкрити хтмл файл (нема помилкі скрипта)
            Uri uri = new Uri(sURL);                         // Способ 2 як відкрити хтмл файл (нема помилкі скрипта)
            TreesMapWB.Navigate(uri);                           // Способ 2 як відкрити хтмл файл (нема помилкі скрипта)
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

        private void BtnAllTrees_Click(object sender, RoutedEventArgs e)
        {
            
            Uri uri = new Uri(sURL);                         // Способ 2 як відкрити хтмл файл (нема помилкі скрипта)
            TreesMapWB.Navigate(uri);
            MessageBox.Show("Загружаю мапу з всіма деревами...");

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT t_id, t_vik, t_stan, t_poroda, t_plodu, t_positionN, t_positionE, t_info FROM Trees ORDER BY t_id", db.GetConnection());
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();
            DateTime now = DateTime.Today;
            int nowYear = now.Year;
            float age = 0;
            string treeVikInStr;
            while (reader.Read())
            {
                treeVikInStr = $"{reader[1]}";
                age = nowYear - float.Parse(treeVikInStr);
                // выводим данные столбцов текущей строки в listBox1
                TreesMapWB.InvokeScript("addMarker", new Object[] { age, $"{reader[2]}", $"{reader[3]}", $"{reader[4]}", $"{reader[5]}", $"{reader[6]}", $"{reader[7]}" });
            }
            reader.Close();
            db.closeConnection();
        }

        private void BtnCommonTrees_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRareTrees_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    // Object used for communication from JS -> WPF
    //[System.Runtime.InteropServices.ComVisibleAttribute(true)]
}

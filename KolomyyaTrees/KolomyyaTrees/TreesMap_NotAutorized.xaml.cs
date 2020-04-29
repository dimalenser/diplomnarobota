using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Логика взаимодействия для TreesMap_NotAutorized.xaml
    /// </summary>
    public partial class TreesMap_NotAutorized : Window
    {
        String sURL = AppDomain.CurrentDomain.BaseDirectory + "html/map.html"; // Способ 2 як відкрити хтмл файл (нема помилкі скрипта)
        public TreesMap_NotAutorized()
        {
            InitializeComponent();

            labelTreeCountUpdate();
            string curDir = Directory.GetCurrentDirectory(); // Способ 2 як відкрити хтмл файл (нема помилкі скрипта)
            Uri uri = new Uri(sURL);                         // Способ 2 як відкрити хтмл файл (нема помилкі скрипта)
            TreesMapWB.Navigate(uri);                           // Способ 2 як відкрити хтмл файл (нема помилкі скрипта)

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
            Uri uri = new Uri(sURL);                         // Способ 2 як відкрити хтмл файл (нема помилкі скрипта)
            TreesMapWB.Navigate(uri);
            MessageBox.Show("Загружаю мапу тільки з простими деревами...");

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT t_id, t_vik, t_stan, t_poroda, t_plodu, t_positionN, t_positionE, t_info FROM Trees WHERE t_info = 'Немає' ORDER BY t_id", db.GetConnection());
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

        private void BtnRareTrees_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(sURL);                         // Способ 2 як відкрити хтмл файл (нема помилкі скрипта)
            TreesMapWB.Navigate(uri);
            MessageBox.Show("Загружаю мапу тільки з рідкісними деревами...");

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT t_id, t_vik, t_stan, t_poroda, t_plodu, t_positionN, t_positionE, t_info FROM Trees WHERE t_info != 'Немає' ORDER BY t_id", db.GetConnection());
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
    }
}

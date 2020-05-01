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
    /// Логика взаимодействия для TreesList.xaml
    /// </summary>
    public partial class TreesList : Window
    {
        public TreesList()
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

        //Добавим информацию в таблицу
        private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            
            InitializeComponent();

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT t_id, t_vik, t_stan, t_poroda, t_plodu, t_positionN, t_positionE, t_info FROM Trees ORDER BY t_id", db.GetConnection());
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();
            DateTime now = DateTime.Today;
            int nowYear = now.Year;
            float age = 0;
            string treeVikInStr;
            string treeNumberInStr;
            int number = 0;
            List<MyTable> result = new List<MyTable>(3);
            while (reader.Read())
            {
                treeNumberInStr = $"{reader[0]}";
                number = int.Parse(treeNumberInStr);
                treeVikInStr = $"{reader[1]}";
                age = nowYear - float.Parse(treeVikInStr);
                // выводим данные столбцов текущей строки в listBox1
                
                result.Add(new MyTable(number, age, $"{reader[2].ToString()}", $"{reader[3].ToString()}", $"{reader[4].ToString()}", $"{reader[5].ToString()}", $"{reader[6].ToString()}", $"{reader[7].ToString()}"));
            }
            grid.ItemsSource = result;
            reader.Close();
            db.closeConnection();
            
        }

        private void TreeSearch_Click(object sender, RoutedEventArgs e)
        {
            TreeSearch trsearch = new TreeSearch();
            trsearch.Show();
            Close();
        }

        private void TreeUpdateBnt_Click(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Today;
            int nowYear = now.Year;
            float age = 0;
            age = nowYear - float.Parse(TreeVikTB.Text);

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("UPDATE `trees` SET `t_vik` = @t_rik, `t_stan` = @t_stan, `t_poroda` = @t_poroda,`t_plodu` = @t_plodu, `t_positionN` = @t_positionN, `t_positionE` = @t_positionE, `t_info` = @t_info WHERE `t_id` = @t_id", db.GetConnection());
            command.Parameters.Add("@t_id", MySqlDbType.VarChar).Value = TreeIdTB.Text;
            command.Parameters.Add("@t_rik", MySqlDbType.Int32).Value = age;
            command.Parameters.Add("@t_stan", MySqlDbType.VarChar).Value = TreeStanTB.Text;
            command.Parameters.Add("@t_poroda", MySqlDbType.VarChar).Value = TreePorodaTB.Text;
            command.Parameters.Add("@t_plodu", MySqlDbType.VarChar).Value = TreePloduTB.Text;
            command.Parameters.Add("@t_positionN", MySqlDbType.VarChar).Value = TreePositionNTB.Text;
            command.Parameters.Add("@t_positionE", MySqlDbType.VarChar).Value = TreePositionETB.Text;
            command.Parameters.Add("@t_info", MySqlDbType.Text).Value = TreeInfoTB.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Дерево успішно додано в нашу базу даних");
            }
            else
                MessageBox.Show("Дерево не було додано в нашу базу даних");

            db.closeConnection();
        }

        private void TreeRemoveBnt_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM `trees` WHERE `t_id` = @t_id", db.GetConnection());
            command.Parameters.Add("@t_id", MySqlDbType.VarChar).Value = TreeIdTB.Text;
            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Дерево успішно додано в нашу базу даних");
            }
            else
                MessageBox.Show("Дерево не було додано в нашу базу даних");

            db.closeConnection();
        }
    }
}

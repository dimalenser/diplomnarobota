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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
            labelTreeCountUpdate();

            textBoxLogin.Text = "Логін";
            textBoxLogin.Foreground = Brushes.LightGray;

            textBoxPassword.Text = "Пароль";
            textBoxPassword.Foreground = Brushes.LightGray;
                 
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

        private void buttonLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxLogin.Text == "Логін")
            {
                MessageBox.Show("Введіть логін користувача");
                return;
            }
            if (textBoxPassword.Text == "Пароль")
            {
                MessageBox.Show("Введіть пароль користувача");
                return;
            }

            string loginUser = textBoxLogin.Text;
            string passUser = textBoxPassword.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `u_login` = @uL AND `u_password` = @uP", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                MessageBox.Show("Вхід виконано успішно, приємного користування");
            else
            {
                MessageBox.Show("Пароль вказано не вірно, або такого користувача не існує");
                return;
            }

            HomePage hmPage = new HomePage();
            hmPage.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonLogIn_Click(this, null);
            }
        }

        private void textBoxLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxLogin.Text == "Логін")
            {
                textBoxLogin.Text = "";
                textBoxLogin.Foreground = Brushes.Black;
            }
        }

        private void textBoxLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxLogin.Text == "")
            {
                textBoxLogin.Text = "Логін";
                textBoxLogin.Foreground = Brushes.LightGray;
            }
        }

        private void textBoxPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPassword.Text == "Пароль")
            {
                textBoxPassword.Text = "";
                textBoxPassword.Foreground = Brushes.Black;
            }
        }

        private void textBoxPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Пароль";
                textBoxPassword.Foreground = Brushes.LightGray;
            }
        }

        public void labelTreeCountUpdate()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT t_kpd FROM `trees`", db.GetConnection());
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            int treeN = 0;
            float treeCusen = 0;
            string treeCusenStr;
            while (reader.Read())
            {
                // выводим данные столбцов текущей строки в listBox1
                treeN++;
                treeCusenStr = $"{reader[0]}";
                treeCusen += float.Parse(treeCusenStr);
            }
            reader.Close();
            db.closeConnection();
            labelTreesKPD.Content = $"До нашої бази даних занесено {treeN - 1} дерев";
        }
    }
}

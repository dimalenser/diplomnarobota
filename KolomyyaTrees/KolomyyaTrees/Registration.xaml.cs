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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();

            textBoxName.Text = "Введіть ім'я користувача";
            textBoxName.Foreground = Brushes.LightGray;

            textBoxSurname.Text = "Введіть прізвище користувача";
            textBoxSurname.Foreground = Brushes.LightGray;

            textBoxLogin.Text = "Введіть логін користувача";
            textBoxLogin.Foreground = Brushes.LightGray;

            textBoxPassword.Text = "Введіть пароль користувача";
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

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "Введіть ім'я користувача")
            {
                MessageBox.Show("Введіть ім'я користувача");
                return;
            }
            if (textBoxSurname.Text == "Введіть прізвище користувача")
            {
                MessageBox.Show("Введіть прізвище користувача");
                return;
            }
            if (textBoxLogin.Text == "Введіть логін користувача")
            {
                MessageBox.Show("Введіть логін користувача");
                return;
            }
            if (textBoxPassword.Text == "Введіть пароль користувача")
            {
                MessageBox.Show("Введіть пароль користувача");
                return;
            }

            if (isUserExists())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`u_name`, `u_surname`, `u_login`, `u_password`) VALUES (@name, @surname, @login, @pass)", db.GetConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBoxName.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBoxSurname.Text;
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBoxLogin.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт був створений");
            else
                MessageBox.Show("Аккаунт не був створений");

            db.closeConnection();


            textBoxName.Text = "Введіть ім'я користувача";
            textBoxName.Foreground = Brushes.LightGray;

            textBoxSurname.Text = "Введіть прізвище користувача";
            textBoxSurname.Foreground = Brushes.LightGray;

            textBoxLogin.Text = "Введіть логін користувача";
            textBoxLogin.Foreground = Brushes.LightGray;

            textBoxPassword.Text = "Введіть пароль користувача";
            textBoxPassword.Foreground = Brushes.LightGray;

            Authorization auth = new Authorization();
            auth.Show();
            Close();
        }

        public Boolean isUserExists()
        {

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `u_login` = @uL", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBoxLogin.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Користувач з таким логіном вже зареєстрований в системі, придумайте собі інший логін");
                return true;

            }
            else
            {
                MessageBox.Show("Реєстрація виконано успішно, тепер ви можете входити в програму");
                return false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Authorization auth = new Authorization();
            auth.Show();
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonRegistration_Click(this, null);
            }
        }

        private void textBoxName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "Введіть ім'я користувача")
            {
                textBoxName.Text = "";
                textBoxName.Foreground = Brushes.Black;
            }
        }

        private void textBoxName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "")
            {
                textBoxName.Text = "Введіть ім'я користувача";
                textBoxName.Foreground = Brushes.LightGray;
            }
        }

        private void textBoxSurname_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxSurname.Text == "Введіть прізвище користувача")
            {
                textBoxSurname.Text = "";
                textBoxSurname.Foreground = Brushes.Black;
            }
        }

        private void textBoxSurname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxSurname.Text == "")
            {
                textBoxSurname.Text = "Введіть прізвище користувача";
                textBoxSurname.Foreground = Brushes.LightGray;
            }
        }

        private void textBoxLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxLogin.Text == "Введіть логін користувача")
            {
                textBoxLogin.Text = "";
                textBoxLogin.Foreground = Brushes.Black;
            }
        }

        private void textBoxLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxLogin.Text == "")
            {
                textBoxLogin.Text = "Введіть логін користувача";
                textBoxLogin.Foreground = Brushes.LightGray;
            }
        }

        private void textBoxPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPassword.Text == "Введіть пароль користувача")
            {
                textBoxPassword.Text = "";
                textBoxPassword.Foreground = Brushes.Black;
            }
        }

        private void textBoxPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Введіть пароль користувача";
                textBoxPassword.Foreground = Brushes.LightGray;
            }
        }
    }
}

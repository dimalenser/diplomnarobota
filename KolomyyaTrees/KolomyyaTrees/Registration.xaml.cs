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

        private void buttonSignIn_Click(object sender, RoutedEventArgs e)
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

            /*
            nameField.Text = "Введіть ім'я користувача";
            nameField.ForeColor = Color.Gray;

            surnameField.Text = "Введіть прізвище користувача";
            surnameField.ForeColor = Color.Gray;

            loginField.Text = "Введіть логін користувача";
            loginField.ForeColor = Color.Gray;

            passField.Text = "Введіть пароль користувача";
            passField.ForeColor = Color.Gray;
            */
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
    }
}

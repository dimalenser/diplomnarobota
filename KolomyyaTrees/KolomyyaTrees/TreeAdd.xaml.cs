using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
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

            labelTreeCountUpdate();

            textBoxYears.Text = "Кількість років";
            textBoxYears.Foreground = Brushes.LightGray;
            
            textBoxStan.Text = "Стан";
            textBoxStan.Foreground = Brushes.LightGray;

            textBoxPoroda.Text = "Порода";
            textBoxPoroda.Foreground = Brushes.LightGray;

            textBoxPlody.Text = "Плоди";
            textBoxPlody.Foreground = Brushes.LightGray;

            textBoxMap.Text = "Місцезнаходження";
            textBoxMap.Foreground = Brushes.LightGray;

            textBoxInfo.Text = "Додаткова інформація";
            textBoxInfo.Foreground = Brushes.LightGray;
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

        private void buttonTreeAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxYears.Text == "Кількість років")
            {
                MessageBox.Show("Введіть вік дерева");
                return;
            }
            if (textBoxStan.Text == "Стан")
            {
                MessageBox.Show("Виберіть стан дерева");
                return;
            }
            if (textBoxPoroda.Text == "Порода")
            {
                MessageBox.Show("Виберіть породу дерева");
                return;
            }
            if (textBoxPlody.Text == "Плоди")
            {
                MessageBox.Show("Виберіть плоди дерева");
                return;
            }
            if (textBoxMap.Text == "Місцезнаходження")
            {
                MessageBox.Show("Введіть координати дерева");
                return;
            }
            if (textBoxInfo.Text == "Додаткова інформація")
            {
                MessageBox.Show("Введіть додаткову інформацію продерево");
                return;
            }


            DateTime now = DateTime.Today;
            int nowYear = now.Year;
            float age = 0;
            age = nowYear - float.Parse(textBoxYears.Text);

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `trees` (`t_vik`, `t_stan`, `t_poroda`, `t_plodu`, `t_ne`, `t_info`) VALUES (@t_rik, @t_stan, @t_poroda, @t_plodu, @t_NE, @t_info)", db.GetConnection());
            command.Parameters.Add("@t_rik", MySqlDbType.Int32).Value = age;
            command.Parameters.Add("@t_stan", MySqlDbType.VarChar).Value = textBoxStan.Text;
            command.Parameters.Add("@t_poroda", MySqlDbType.VarChar).Value = textBoxPoroda.Text;
            command.Parameters.Add("@t_plodu", MySqlDbType.VarChar).Value = textBoxPlody.Text;
            command.Parameters.Add("@t_NE", MySqlDbType.VarChar).Value = textBoxMap.Text;
            command.Parameters.Add("@t_info", MySqlDbType.Text).Value = textBoxInfo.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.Stream resourceStream = assembly.GetManifestResourceStream(@"KolomyyaTrees.treeAddSound.wav");
                SoundPlayer player = new SoundPlayer(resourceStream);
                player.Play();


                MessageBox.Show("Дерево успішно додано в нашу базу даних");
            }
            else
                MessageBox.Show("Дерево не було додано в нашу базу даних");

            db.closeConnection();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonTreeAdd_Click(this, null);
            }
        }
        private void textBoxYears_GotFocus(object sender, RoutedEventArgs e)
        {
            if(textBoxYears.Text == "Кількість років")
            {
                textBoxYears.Text = "";
                textBoxYears.Foreground = Brushes.Black;
            }
            
        }

        private void textBoxYears_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxYears.Text == "")
            {
                textBoxYears.Text = "Кількість років";
                textBoxYears.Foreground = Brushes.LightGray;
            }
        }

        private void textBoxStan_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxStan.Text == "Стан")
            {
                textBoxStan.Text = "";
                textBoxStan.Foreground = Brushes.Black;
            }
        }

        private void textBoxStan_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxStan.Text == "")
            {
                textBoxStan.Text = "Стан";
                textBoxStan.Foreground = Brushes.LightGray;
            }
        }

        private void textBoxPoroda_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPoroda.Text == "Порода")
            {
                textBoxPoroda.Text = "";
                textBoxPoroda.Foreground = Brushes.Black;
            }
        }

        private void textBoxPoroda_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPoroda.Text == "")
            {
                textBoxPoroda.Text = "Порода";
                textBoxPoroda.Foreground = Brushes.LightGray;
            }
        }

        private void textBoxPlody_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPlody.Text == "Плоди")
            {
                textBoxPlody.Text = "";
                textBoxPlody.Foreground = Brushes.Black;
            }
        }

        private void textBoxPlody_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPlody.Text == "")
            {
                textBoxPlody.Text = "Плоди";
                textBoxPlody.Foreground = Brushes.LightGray;
            }
        }

        private void textBoxMap_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxMap.Text == "Місцезнаходження")
            {
                textBoxMap.Text = "";
                textBoxMap.Foreground = Brushes.Black;
            }
        }

        private void textBoxMap_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxMap.Text == "")
            {
                textBoxMap.Text = "Місцезнаходження";
                textBoxMap.Foreground = Brushes.LightGray;
            }
        }

        private void textBoxInfo_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxInfo.Text == "Додаткова інформація")
            {
                textBoxInfo.Text = "";
                textBoxInfo.Foreground = Brushes.Black;
            }
        }

        private void textBoxInfo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxInfo.Text == "")
            {
                textBoxInfo.Text = "Додаткова інформація";
                textBoxInfo.Foreground = Brushes.LightGray;
            }
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

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

        private void buttonSignIn_Click(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Today;
            int nowYear = now.Year;
            float age = 0;
            age = nowYear - float.Parse(textBoxYears.Text);

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `trees` (`t_vik`, `t_stan`, `t_poroda`, `t_plodu`, `t_ne`, `t_kpd`) VALUES (@t_rik, @t_stan, @t_poroda, @t_plodu, @t_NE, @t_KPD)", db.GetConnection());
            command.Parameters.Add("@t_rik", MySqlDbType.Int32).Value = age;
            command.Parameters.Add("@t_stan", MySqlDbType.VarChar).Value = textBoxStan.Text;
            command.Parameters.Add("@t_poroda", MySqlDbType.VarChar).Value = textBoxPoroda.Text;
            command.Parameters.Add("@t_plodu", MySqlDbType.VarChar).Value = textBoxPlody.Text;
            command.Parameters.Add("@t_NE", MySqlDbType.VarChar).Value = textBoxMap.Text;
            command.Parameters.Add("@t_KPD", MySqlDbType.Int32).Value = textBoxInfo.Text;

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
    }
}

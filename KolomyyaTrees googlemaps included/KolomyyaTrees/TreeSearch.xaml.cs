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
    /// Логика взаимодействия для TreeSearch.xaml
    /// </summary>
    public partial class TreeSearch : Window
    {
        public TreeSearch()
        {
            InitializeComponent();

            labelTreeCountUpdate();
        }

        private void grid_Loaded(object sender, RoutedEventArgs e)
        {

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

        private void buttonSearchTree_Click(object sender, RoutedEventArgs e)
        {
            labelCommand.Content = "SELECT * FROM `trees` WHERE ";
            //----------------------------------------------------------------------------------------------------------------------------
            if ((bool)radioButton1.IsChecked == true)
            {
                if (textBoxN1.Text != "")
                {
                    string Str = textBoxN1.Text;
                    int text;
                    bool isNum = int.TryParse(Str, out text);
                    if (isNum)
                    {
                        labelCommand.Content = $"{labelCommand.Content} `t_id`={textBoxN1.Text}";
                    }
                    else
                    {
                        MessageBox.Show("В полі повинне бути число");
                        return;
                    }
                    if (textBoxN1.Text == "")
                    {
                        MessageBox.Show("Ви не заповнили повністю фільтр. \nЗаповність фільтр повністю та повторіть спробу");
                        return;
                    }
                }
            }

            if ((bool)radioButton2.IsChecked == true)
            {
                if (textBoxN1.Text != "" && textBoxN2.Text != "")
                {
                    string Str = textBoxN1.Text;
                    int checkINT1;
                    bool isNum1 = int.TryParse(Str, out checkINT1);
                    Str = textBoxN2.Text;
                    int checkINT2;
                    bool isNum2 = int.TryParse(Str, out checkINT2);
                    if (isNum1 && isNum2)
                    {
                        labelCommand.Content = $"{labelCommand.Content} `t_id`>={textBoxN1.Text} AND `t_id`<={textBoxN2.Text} ";
                    }
                    else
                    {
                        MessageBox.Show("В полях повинні бути числа");
                        return;
                    }
                }
                if ((textBoxN1.Text != "" && textBoxN2.Text == "") || (textBoxN1.Text == "" && textBoxN2.Text != "") || (textBoxN1.Text == "" && textBoxN2.Text == ""))
                {
                    MessageBox.Show("Ви не заповнили повністю фільтр. \nЗаповність фільтр повністю та повторіть спробу");
                    return;
                }
            }
            //----------------------------------------------------------------------------------------------------------------------------
            if ((bool)radioButtonVik1.IsChecked == true)
            {
                if (((bool)radioButton1.IsChecked == true || (bool)radioButton2.IsChecked == true))
                    labelCommand.Content = $"{labelCommand.Content} AND";
                if (textBoxVik1.Text != "")
                {
                    string Str = textBoxVik1.Text;
                    int checkINT;
                    bool isNum = int.TryParse(Str, out checkINT);
                    if (isNum)
                    {
                        
                        DateTime now1 = DateTime.Today;
                        int nowYear1 = now1.Year;
                        float age1 = 0;
                        age1 = nowYear1 - float.Parse(textBoxVik1.Text);
                        
                        labelCommand.Content = $"{labelCommand.Content} `t_vik`={age1}";
                    }
                    else
                    {
                        MessageBox.Show("В полі повинне бути число");
                        return;
                    }
                }

                if (textBoxVik1.Text == "")
                {
                    MessageBox.Show("Ви не заповнили повністю фільтр. \nЗаповність фільтр повністю та повторіть спробу");
                    return;
                }
            }

            if ((bool)radioButtonVik2.IsChecked == true)
            {
                if (((bool)radioButton1.IsChecked == true || (bool)radioButton2.IsChecked == true))
                    labelCommand.Content = $"{labelCommand.Content} AND";
                if (textBoxVik1.Text != "" && textBoxVik2.Text != "")
                {
                    string Str = textBoxVik1.Text;
                    int checkINT1;
                    bool isNum1 = int.TryParse(Str, out checkINT1);
                    Str = textBoxVik2.Text;
                    int checkINT2;
                    bool isNum2 = int.TryParse(Str, out checkINT2);
                    if (isNum1 && isNum2)
                    {
                        DateTime now1 = DateTime.Today;
                        int nowYear1 = now1.Year;
                        float age1 = 0;
                        float age2 = 0;
                        age1 = nowYear1 - float.Parse(textBoxVik1.Text);
                        age2 = nowYear1 - float.Parse(textBoxVik2.Text);
                        labelCommand.Content = $"{labelCommand.Content} `t_vik`>={age2} AND `t_vik`<={age1} ";
                    }
                    else
                    {
                        MessageBox.Show("В полях повинні бути числа");
                        return;
                    }
                }
                if ((textBoxVik1.Text != "" && textBoxVik2.Text == "") || (textBoxVik1.Text == "" && textBoxVik2.Text != "") || (textBoxVik1.Text == "" && textBoxVik2.Text == ""))
                {
                    MessageBox.Show("Ви не заповнили повністю фільтр. \nЗаповність фільтр повністю та повторіть спробу");
                    return;
                }
            }
            //----------------------------------------------------------------------------------------------------------------------------
            if ((bool)radioButtonStan1.IsChecked == true)
            {
                if (((bool)radioButton1.IsChecked == true || (bool)radioButton2.IsChecked == true) || ((bool)radioButtonVik1.IsChecked == true || (bool)radioButtonVik2.IsChecked == true))
                    labelCommand.Content = $"{labelCommand.Content} AND";
                if (textBoxStan1.Text != "")
                {
                    string Str = textBoxStan1.Text;
                    int checkINT;
                    bool isNum = int.TryParse(Str, out checkINT);
                    if (isNum)
                    {
                        labelCommand.Content = $"{labelCommand.Content} `t_stan`={textBoxStan1.Text}";
                    }
                    else
                    {
                        MessageBox.Show("В полі повинне бути число");
                        return;
                    }
                }
                if (textBoxStan1.Text == "")
                {
                    MessageBox.Show("Ви не заповнили повністю фільтр. \nЗаповність фільтр повністю та повторіть спробу");
                    return;
                }
            }

            if ((bool)radioButtonStan2.IsChecked == true)
            {
                if (((bool)radioButton1.IsChecked == true || (bool)radioButton2.IsChecked == true) || ((bool)radioButtonVik1.IsChecked == true || (bool)radioButtonVik2.IsChecked == true))
                    labelCommand.Content = $"{labelCommand.Content} AND";
                if (textBoxStan1.Text != "" && textBoxStan2.Text != "")
                {
                    string Str = textBoxStan1.Text;
                    int checkINT1;
                    bool isNum1 = int.TryParse(Str, out checkINT1);
                    Str = textBoxStan2.Text;
                    int checkINT2;
                    bool isNum2 = int.TryParse(Str, out checkINT2);
                    if (isNum1 && isNum2)
                    {
                        labelCommand.Content = $"{labelCommand.Content} `t_stan`>={textBoxStan1.Text} AND `t_stan`<={textBoxStan2.Text} ";
                    }
                    else
                    {
                        MessageBox.Show("В полях повинні бути числа");
                        return;
                    }
                }
                if ((textBoxStan1.Text != "" && textBoxStan2.Text == "") || (textBoxStan1.Text == "" && textBoxStan2.Text != "") || (textBoxStan1.Text == "" && textBoxStan2.Text == ""))
                {
                    MessageBox.Show("Ви не заповнили повністю фільтр. \nЗаповність фільтр повністю та повторіть спробу");
                    return;
                }
            }
            //----------------------------------------------------------------------------------------------------------------------------
            if ((bool)radioButtonPoroda1.IsChecked == true)
            {
                if (((bool)radioButton1.IsChecked == true || (bool)radioButton2.IsChecked == true) || ((bool)radioButtonVik1.IsChecked == true || (bool)radioButtonVik2.IsChecked == true) || ((bool)radioButtonStan2.IsChecked == true || (bool)radioButtonStan2.IsChecked == true))
                    labelCommand.Content = $"{labelCommand.Content} AND";
                if (textBoxPoroda.Text != "")
                    labelCommand.Content = $"{labelCommand.Content} `t_poroda`='{textBoxPoroda.Text}'";
                if (textBoxPoroda.Text == "")
                {
                    MessageBox.Show("Ви не заповнили повністю фільтр. \nЗаповність фільтр повністю та повторіть спробу");
                    return;
                }
            }
            //----------------------------------------------------------------------------------------------------------------------------
            if ((bool)radioButtonPlodu1.IsChecked == true)
            {
                if (((bool)radioButton1.IsChecked == true || (bool)radioButton2.IsChecked == true) || ((bool)radioButtonVik1.IsChecked == true || (bool)radioButtonVik2.IsChecked == true) || ((bool)radioButtonStan2.IsChecked == true || (bool)radioButtonStan2.IsChecked == true) || (bool)radioButtonPoroda1.IsChecked == true)
                    labelCommand.Content = $"{labelCommand.Content} AND";
                if (textBoxPlodu.Text != "")
                    labelCommand.Content = $"{labelCommand.Content} `t_plodu`='{textBoxPlodu.Text}'";
                if (textBoxPlodu.Text == "")
                {
                    MessageBox.Show("Ви не заповнили повністю фільтр. \nЗаповність фільтр повністю та повторіть спробу");
                    return;
                }
            }
            //----------------------------------------------------------------------------------------------------------------------------
            if ((bool)radioButtonNe1.IsChecked)
            {
                if (((bool)radioButton1.IsChecked == true || (bool)radioButton2.IsChecked == true) || ((bool)radioButtonVik1.IsChecked == true || (bool)radioButtonVik2.IsChecked == true) || ((bool)radioButtonStan2.IsChecked == true || (bool)radioButtonStan2.IsChecked == true) || ((bool)radioButtonPoroda1.IsChecked == true || (bool)radioButtonPlodu1.IsChecked == true))
                    labelCommand.Content = $"{labelCommand.Content} AND";
                if (textBoxNe1.Text != "" && textBoxNe2.Text != "")
                    labelCommand.Content = $"{labelCommand.Content} `t_positionN`='{textBoxNe1.Text}' AND ";
                    labelCommand.Content = $"{labelCommand.Content} `t_positionE`='{textBoxNe2.Text}'";
                if (textBoxNe1.Text == "" || textBoxNe2.Text == "")
                {
                    MessageBox.Show("Ви не заповнили повністю фільтр. \nЗаповність фільтр повністю та повторіть спробу");
                    return;
                }
            }
            //----------------------------------------------------------------------------------------------------------------------------
            if ((bool)radioButtonInfo1.IsChecked)
            {
                if (((bool)radioButton1.IsChecked == true || (bool)radioButton2.IsChecked == true) || ((bool)radioButtonVik1.IsChecked == true || (bool)radioButtonVik2.IsChecked == true) || ((bool)radioButtonStan2.IsChecked == true || (bool)radioButtonStan2.IsChecked == true) || ((bool)radioButtonPoroda1.IsChecked == true || (bool)radioButtonPlodu1.IsChecked == true))
                    labelCommand.Content = $"{labelCommand.Content} AND";
                if (textBoxInfo.Text != "")
                    labelCommand.Content = $"{labelCommand.Content} `t_info`='{textBoxInfo.Text}'";
                if (textBoxInfo.Text == "")
                {
                    MessageBox.Show("Ви не заповнили повністю фільтр. \nЗаповність фільтр повністю та повторіть спробу");
                    return;
                }
            }
            //----------------------------------------------------------------------------------------------------------------------------
            if ((bool)radioButton3.IsChecked == true && (bool)radioButtonVik3.IsChecked == true && (bool)radioButtonStan3.IsChecked == true && (bool)radioButtonPoroda2.IsChecked == true && (bool)radioButtonPlodu2.IsChecked == true && (bool)radioButtonNe2.IsChecked == true && (bool)radioButtonInfo2.IsChecked == true)
            {
                labelCommand.Content = "SELECT * FROM `trees` ";
            }

            InitializeComponent();

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand($"{labelCommand.Content}", db.GetConnection());
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

        private void radioButton1_Click(object sender, RoutedEventArgs e)
        {
            labelN.Content = "Напишіть  число";
            labelN.Visibility = Visibility.Visible;
            textBoxN1.Text = "";
            textBoxN2.Text = "";
            textBoxN1.Visibility = Visibility.Visible;
            textBoxN2.Visibility = Visibility.Hidden;
        }

        private void radioButton2_Click(object sender, RoutedEventArgs e)
        {
            labelN.Content = "Оберіть проміжок від             до";
            labelN.Visibility = Visibility.Visible;
            textBoxN1.Text = "";
            textBoxN2.Text = "";
            textBoxN1.Visibility = Visibility.Visible;
            textBoxN2.Visibility = Visibility.Visible;
        }

        private void radioButton3_Click(object sender, RoutedEventArgs e)
        {
            labelN.Content = "Оберіть проміжок від             до";
            labelN.Visibility = Visibility.Hidden;
            textBoxN1.Text = "";
            textBoxN2.Text = "";
            textBoxN1.Visibility = Visibility.Hidden;
            textBoxN2.Visibility = Visibility.Hidden;
        }

        private void radioButtonVik1_Click(object sender, RoutedEventArgs e)
        {
            labelVik.Content = "Напишіть  число";
            labelVik.Visibility = Visibility.Visible;
            textBoxVik1.Text = "";
            textBoxVik2.Text = "";
            textBoxVik1.Visibility = Visibility.Visible;
            textBoxVik2.Visibility = Visibility.Hidden;
        }

        private void radioButtonVik2_Click(object sender, RoutedEventArgs e)
        {
            labelVik.Content = "Оберіть проміжок від             до";
            labelVik.Visibility = Visibility.Visible;
            textBoxVik1.Text = "";
            textBoxVik2.Text = "";
            textBoxVik1.Visibility = Visibility.Visible;
            textBoxVik2.Visibility = Visibility.Visible;
        }

        private void radioButtonVik3_Click(object sender, RoutedEventArgs e)
        {
            labelVik.Content = "Оберіть проміжок від             до";
            labelVik.Visibility = Visibility.Hidden;
            textBoxVik1.Text = "";
            textBoxVik2.Text = "";
            textBoxVik1.Visibility = Visibility.Hidden;
            textBoxVik2.Visibility = Visibility.Hidden;
        }

        private void radioButtonStan1_Click(object sender, RoutedEventArgs e)
        {
            labelStan.Content = "Напишіть  число";
            labelStan.Visibility = Visibility.Visible;
            textBoxStan1.Text = "";
            textBoxStan2.Text = "";
            textBoxStan1.Visibility = Visibility.Visible;
            textBoxStan2.Visibility = Visibility.Hidden;
        }

        private void radioButtonStan2_Click(object sender, RoutedEventArgs e)
        {
            labelStan.Content = "Оберіть проміжок від             до";
            labelStan.Visibility = Visibility.Visible;
            textBoxStan1.Text = "";
            textBoxStan2.Text = "";
            textBoxStan1.Visibility = Visibility.Visible;
            textBoxStan2.Visibility = Visibility.Visible;
        }

        private void radioButtonStan3_Click(object sender, RoutedEventArgs e)
        {
            labelStan.Content = "Оберіть проміжок від             до";
            labelStan.Visibility = Visibility.Hidden;
            textBoxStan1.Text = "";
            textBoxStan2.Text = "";
            textBoxStan1.Visibility = Visibility.Hidden;
            textBoxStan2.Visibility = Visibility.Hidden;
        }

        private void radioButtonPoroda1_Click(object sender, RoutedEventArgs e)
        {
            labelPoroda.Content = "Напишіть назву породи";
            labelPoroda.Visibility = Visibility.Visible;
            textBoxPoroda.Text = "";
            textBoxPoroda.Visibility = Visibility.Visible;
        }

        private void radioButtonPoroda2_Click(object sender, RoutedEventArgs e)
        {
            labelPoroda.Visibility = Visibility.Hidden;
            textBoxPoroda.Text = "";
            textBoxPoroda.Visibility = Visibility.Hidden;
        }

        private void radioButtonPlodu1_Click(object sender, RoutedEventArgs e)
        {
            labelPlodu.Content = "Напишіть назву плодів";
            labelPlodu.Visibility = Visibility.Visible;
            textBoxPlodu.Text = "";
            textBoxPlodu.Visibility = Visibility.Visible;
        }

        private void radioButtonPlodu2_Click(object sender, RoutedEventArgs e)
        {
            labelPlodu.Visibility = Visibility.Hidden;
            textBoxPlodu.Text = "";
            textBoxPlodu.Visibility = Visibility.Hidden;
        }

        private void radioButtonNe1_Click(object sender, RoutedEventArgs e)
        {
            labelNe.Content = "Напишіть координати";
            labelNe.Visibility = Visibility.Visible;
            textBoxNe1.Text = "";
            textBoxNe1.Visibility = Visibility.Visible;
            textBoxNe2.Text = "";
            textBoxNe2.Visibility = Visibility.Visible;
        }

        private void radioButtonNe2_Click(object sender, RoutedEventArgs e)
        {
            labelNe.Visibility = Visibility.Hidden;
            textBoxNe1.Text = "";
            textBoxNe1.Visibility = Visibility.Hidden;
            textBoxNe2.Text = "";
            textBoxNe2.Visibility = Visibility.Hidden;
        }

        private void radioButtonInfo1_Click(object sender, RoutedEventArgs e)
        {
            labelInfo.Content = "Напишіть додаткову інформацію";
            labelInfo.Visibility = Visibility.Visible;
            textBoxInfo.Text = "";
            textBoxInfo.Visibility = Visibility.Visible;
        }

        private void radioButtonInfo2_Click(object sender, RoutedEventArgs e)
        {
            labelInfo.Visibility = Visibility.Hidden;
            textBoxInfo.Text = "";
            textBoxInfo.Visibility = Visibility.Hidden;
        }


    }
}

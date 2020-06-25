using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для SecurityCheck.xaml
    /// </summary>
    public partial class SecurityCheck : Window
    {
        public SecurityCheck()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(passBox.Password=="04052001")
            {
                MessageBox.Show("Пароль введено вірно, ви можете провести реєстрацію користувача");
                Registration reg = new Registration();
                reg.Show();
                Close();
            }
            MessageBox.Show("Пароль введено невірно, попробуйте ще раз");
            return;
        }
    }
}

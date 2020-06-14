using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        private void SetBrowserFeatureControlKey(string feature, string appName, uint value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(
                String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
                RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
            }
        }

        private void SetBrowserFeatureControl()
        {
            // http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx

            // FeatureControl settings are per-process
            var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

            // make the control is not running inside Visual Studio Designer
            if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
                return;

            SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, GetBrowserEmulationMode()); // Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode.
            SetBrowserFeatureControlKey("FEATURE_AJAX_CONNECTIONEVENTS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_MANAGE_SCRIPT_CIRCULAR_REFS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_DOMSTORAGE ", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_GPU_RENDERING ", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_IVIEWOBJECTDRAW_DMLT9_WITH_GDI  ", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_LEGACY_COMPRESSION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_LOCALMACHINE_LOCKDOWN", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_OBJECT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_SCRIPT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_NAVIGATION_SOUNDS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_SCRIPTURL_MITIGATION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_SPELLCHECKING", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_STATUS_BAR_THROTTLING", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_TABBED_BROWSING", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_VALIDATE_NAVIGATE_URL", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_DOCUMENT_ZOOM", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_POPUPMANAGEMENT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_MOVESIZECHILD", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_ADDON_MANAGEMENT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_WEBSOCKET", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WINDOW_RESTRICTIONS ", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_XMLHTTP", fileName, 1);
        }

        private UInt32 GetBrowserEmulationMode()
        {
            int browserVersion = 7;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }

            UInt32 mode = 11000; // Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode. Default value for Internet Explorer 11.
            switch (browserVersion)
            {
                case 7:
                    mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control.
                    break;
                case 8:
                    mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8
                    break;
                case 9:
                    mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.
                    break;
                case 10:
                    mode = 10000; // Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 mode. Default value for Internet Explorer 10.
                    break;
                default:
                    // use IE11 mode by default
                    break;
            }

            return mode;
        }
        public TreeAdd()
        {
            SetBrowserFeatureControl();

            InitializeComponent();
            

            labelTreeCountUpdate();

            if ((bool)GoogleMapsCB.IsChecked == false)
            {
                GoogleMapsWB.Visibility = Visibility.Hidden;
            }

            GoogleMapsWB.Navigate("https://www.google.com.ua/maps/place/%D0%9A%D0%BE%D0%BB%D0%BE%D0%BC%D1%8B%D1%8F,+%D0%98%D0%B2%D0%B0%D0%BD%D0%BE-%D0%A4%D1%80%D0%B0%D0%BD%D0%BA%D0%BE%D0%B2%D1%81%D0%BA%D0%B0%D1%8F+%D0%BE%D0%B1%D0%BB%D0%B0%D1%81%D1%82%D1%8C,+78200/@48.5660049,24.9500774,33477m/");


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

            if (textBoxMapE.Text == "Місцезнаходження")
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
            MySqlCommand command = new MySqlCommand("INSERT INTO `trees` (`t_vik`, `t_stan`, `t_poroda`, `t_plodu`, `t_positionN`, `t_positionE`, `t_info`) VALUES (@t_rik, @t_stan, @t_poroda, @t_plodu, @t_positionN, @t_positionE, @t_info)", db.GetConnection());
            command.Parameters.Add("@t_rik", MySqlDbType.Int32).Value = age;
            command.Parameters.Add("@t_stan", MySqlDbType.VarChar).Value = textBoxStan.Text;
            command.Parameters.Add("@t_poroda", MySqlDbType.VarChar).Value = textBoxPoroda.Text;
            command.Parameters.Add("@t_plodu", MySqlDbType.VarChar).Value = textBoxPlody.Text;
            command.Parameters.Add("@t_positionN", MySqlDbType.VarChar).Value = textBoxMap.Text;
            command.Parameters.Add("@t_positionE", MySqlDbType.VarChar).Value = textBoxMapE.Text;
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
        private void textBoxMapE_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxMapE.Text == "Місцезнаходження")
            {
                textBoxMapE.Text = "";
                textBoxMapE.Foreground = Brushes.Black;
            }
        }

        private void textBoxMapE_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxMapE.Text == "")
            {
                textBoxMapE.Text = "Місцезнаходження";
                textBoxMapE.Foreground = Brushes.LightGray;
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

        private void GoogleMapsCB_Checked(object sender, RoutedEventArgs e)
        {
            GoogleMapsWB.Visibility = Visibility.Visible;
        }

        private void GoogleMapsCB_Unchecked(object sender, RoutedEventArgs e)
        {
            GoogleMapsWB.Visibility = Visibility.Hidden;
        }
    }
}

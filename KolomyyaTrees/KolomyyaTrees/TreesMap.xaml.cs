using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Win32;
using System.Diagnostics;

namespace KolomyyaTrees
{
    /// <summary>
    /// Логика взаимодействия для TreesMap.xaml
    /// </summary>
    public partial class TreesMap : Window
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
        String sURL = AppDomain.CurrentDomain.BaseDirectory + "html/map.html"; // Способ 2 як відкрити хтмл файл (нема помилкі скрипта)
        public TreesMap()
        {
            InitializeComponent();

            labelTreeCountUpdate();

            /* Способ 1 як відкрити хтмл файл
            string curDir = Directory.GetCurrentDirectory();
            //dimaweb.Silent = true;
            this.dimaweb.Navigate(new Uri(String.Format("file:///{0}/html/dimatest.html", curDir)));
            */

            string curDir = Directory.GetCurrentDirectory(); // Способ 2 як відкрити хтмл файл (нема помилкі скрипта)
            Uri uri = new Uri(sURL);                         // Способ 2 як відкрити хтмл файл (нема помилкі скрипта)
            TreesMapWB.Navigate(uri);                           // Способ 2 як відкрити хтмл файл (нема помилкі скрипта)
            /*
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
            */
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

        private void BtnAllTrees_Click(object sender, RoutedEventArgs e)
        {
            
            Uri uri = new Uri(sURL);                         // Способ 2 як відкрити хтмл файл (нема помилкі скрипта)
            TreesMapWB.Navigate(uri);
            MessageBox.Show("Загружаю мапу з всіма деревами...");

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT t_id, t_vik, t_stan, t_poroda, t_plodu, t_positionN, t_positionE, t_info FROM `trees` ORDER BY t_id", db.GetConnection());
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

            MySqlCommand command = new MySqlCommand("SELECT t_id, t_vik, t_stan, t_poroda, t_plodu, t_positionN, t_positionE, t_info FROM `trees` WHERE t_info = 'Немає' ORDER BY t_id", db.GetConnection());
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

            MySqlCommand command = new MySqlCommand("SELECT t_id, t_vik, t_stan, t_poroda, t_plodu, t_positionN, t_positionE, t_info FROM `trees` WHERE t_info != 'Немає' ORDER BY t_id", db.GetConnection());
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
    // Object used for communication from JS -> WPF
    //[System.Runtime.InteropServices.ComVisibleAttribute(true)]
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolomyyaTrees
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server=141.8.192.31; port=3306;username=a0446855_dimalenser; password=dimatreesadmin; database=a0446855_treesbase;charset=utf8");
        //server=localhost; port=3306;username=root;password=;database=treesbase;charset=utf8 локалка
        //server=141.8.192.31; port=3306;username=a0446855_dimalenser; password=dimatreesadmin; database=a0446855_treesbase;charset=utf8 сервер

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FromTund
{
    class SQLConnection
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=s9gNu7Kp;database=formdb"); //Данные на подключение к БД

        public void open() //Метод на открытие соеденения
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }
        public void close() //Метод на закрытие соеденения
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        public MySqlConnection GetConnection() //метод для получения данных которые используються для подключения к БД
        {
            return conn;
        }
        
        public List<string[]> Select(string select) //Метод для выборки всех 6 строк
        {
            MySqlCommand command = new MySqlCommand(select, conn);
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[6]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
            }
            reader.Close();
            return data;
        }

        public List<string[]> SelectOne(string selectOne) //Метод для выборки одной строки
        {
            MySqlCommand command = new MySqlCommand(selectOne, conn);
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[1]);
                data[data.Count - 1][0] = reader[0].ToString();
            }
            reader.Close();
            return data;
        }
    }
}
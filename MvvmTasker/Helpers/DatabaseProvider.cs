using System.Data.SQLite;
using System.Collections.Generic;
using System;
using System.Windows;

namespace MvvmTasker.Helpers
{
    public class DatabaseProvider
    {
        SQLiteConnection _conn;

        public DatabaseProvider(string filePath)
        {
            _conn = new SQLiteConnection("URI=file:" + filePath);
        }

        /// <summary>
        /// Returns true or false depends if insert data is succes
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool InsertData(string columns, string values, string table)
        {
            _conn.Open();
            if (_conn.State != System.Data.ConnectionState.Open)
                return false;

            SQLiteCommand cmd = new SQLiteCommand(_conn);
            cmd.CommandText = $"INSERT INTO {table}({columns}) VALUES({values})";

            if (cmd.ExecuteNonQuery() > 0)
            {
                _conn.Close();
                return true;
            }
            _conn.Close();
            return false;
        }

        /// <summary>
        /// Delete data by column name (string value)
        /// </summary>
        /// <param name="nameColumn"></param>
        /// <param name="value"></param>
        /// <param name="table"></param>
        public void DeleteData(string nameColumn, string value, string table)
        {
            _conn.Open();
            if (_conn.State != System.Data.ConnectionState.Open)
                return;

            SQLiteCommand cmd = new SQLiteCommand(_conn);
            cmd.CommandText = $"DELETE FROM {table} WHERE {nameColumn}='{value}'";

            if (cmd.ExecuteNonQuery() > 0)
            {
                _conn.Close();
                return;
            }
            _conn.Close();
            return;
        }

        /// <summary>
        /// Delete data by column name (int value)
        /// </summary>
        /// <param name="nameColumn"></param>
        /// <param name="value"></param>
        /// <param name="table"></param>
        public void DeleteData(string nameColumn, int value, string table)
        {
            _conn.Open();
            if (_conn.State != System.Data.ConnectionState.Open)
                return;

            SQLiteCommand cmd = new SQLiteCommand(_conn);
            cmd.CommandText = $"DELETE FROM {table} WHERE {nameColumn}={value}";

            if (cmd.ExecuteNonQuery() > 0)
            {
                _conn.Close();
                return;
            }
            _conn.Close();
            return;
        }

        /// <summary>
        /// Load all data from table
        /// </summary>
        /// <param name="column"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public string[] GetAllData(string columns, string table)
        {
            _conn.Open();
            if (_conn.State != System.Data.ConnectionState.Open)
                return null;

            SQLiteCommand cmd = new SQLiteCommand(_conn);
            cmd.CommandText = $"SELECT {columns} FROM {table}";

            if (cmd.ExecuteNonQuery() == 0)
            {
                _conn.Close();
                return null;
            }

            List<string> res = new List<string>();
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string data = string.Empty;
                for(int i = 0; i < reader.FieldCount; i++)
                {
                    var type = reader.GetFieldType(i);

                    if(type == typeof(string))
                        data += reader.GetString(i) + ',';
                    else if(type == typeof(int))
                        data += reader.GetString(i) + ',';
                    else if(type == typeof(DateTime))
                        data += reader.GetString(i) + ',';
                }
                res.Add(data);
            }

            _conn.Close();
            return res.ToArray();          
        }
    }
}

using Caliburn.Micro;
using MvvmTasker.Helpers;
using System;
using System.Windows;
using System.Data.SQLite;

namespace MvvmTasker.ViewModels
{
    public class CreatorNewTaskViewModel : Screen
    {
        private string _title;
        private string _description;

        public string Title
        {
            get => _title;
            set { _title = value; }
        }

        public string Description
        {
            get => _description;
            set { _description = value; }
        }

        public void ReturnTaskData()
        {
            if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Description))
            {
                MessageBox.Show("Uzupełnij pola!");
                return;
            }

            DatabaseProvider database = new DatabaseProvider("C:/Users/50kos/Music/db.db");

            var res = database.InsertData("Title, Description, CreationData", $"'{Title}','{Description}', '{DateTime.Now}'", "Tasks");

            if (res)
                MessageBox.Show("Stworzono zadanie!");
            else
                MessageBox.Show("Nie udało się utworzyć zadania!");
            var n = Parent as MainViewModel;
            n.OpenTasks();
        }
    }
}

using Caliburn.Micro;
using MvvmTasker.Helpers;
using System;
using System.Windows;
using System.Data.SQLite;

namespace MvvmTasker.ViewModels
{
    public class CreatorNewTaskViewModel : Screen
    {
        private static string _filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TaskerData";
        private const string _fileName = "Tasker.db";

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

            DatabaseProvider database = new DatabaseProvider(_filePath, _fileName);

            var res = database.InsertData("Title, Description, CreationDate", $"'{Title}','{Description}', '{DateTime.Now}'", "Tasks");
            var n = Parent as MainViewModel;
            n.OpenTasks();

            if (res)
                MessageBox.Show("Stworzono zadanie!");
            else
                MessageBox.Show("Nie udało się utworzyć zadania!");      
        }
    }
}

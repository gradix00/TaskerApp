using Caliburn.Micro;
using MvvmTasker.Helpers;
using System;
using System.Windows;
using Message = MvvmTasker.Helpers.Message;

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
                MessageBox.Show(InfoMessage.GetMessage[Message.FieldsEmpty]);
                return;
            }

            DatabaseProvider database = new DatabaseProvider(_filePath, _fileName);

            var res = database.InsertData("Title, Description, CreationDate", $"'{Title}','{Description}', '{DateTime.Now}'", "Tasks");
            var n = Parent as MainViewModel;
            n.OpenTasks();

            if (res)
                MessageBox.Show(InfoMessage.GetMessage[Message.SuccesAddTask]);
            else
                MessageBox.Show(InfoMessage.GetMessage[Message.FailedAddTask]);
        }
    }
}

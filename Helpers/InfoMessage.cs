using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTasker.Helpers
{
    public enum Message
    {
        FailedAddTask,
        SuccesAddTask,
        NoSelectedTasks,
        NoTasks,
        FieldsEmpty
    }

    public static class InfoMessage
    {
        public static Dictionary<Message, string> GetMessage = new Dictionary<Message, string>()
        {
            { Message.FailedAddTask, "Nie udało się dodać tasku..." },
            { Message.SuccesAddTask, "Dodano nowy task!" },
            { Message.NoSelectedTasks, "Nie wybrano żadnego tasku" },
            { Message.NoTasks, "Brak tasków do wyświetlenia" },
            { Message.FieldsEmpty, "Pola są puste!" }
        };
    }
}

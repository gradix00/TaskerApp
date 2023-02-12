using System;

namespace ewads_mvvm.Model.Helpers
{
    public struct MessageData
    {
        public int ID { get; set; }
        public string Autor { get; set; }

        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}

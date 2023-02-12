using System.Collections.Generic;

namespace ewads_mvvm.Model.Helpers
{
    internal class GetStatus
    {
        public Dictionary<string, Status> status = new Dictionary<string, Status>
        {
            {"Admin", Status.admin },
            {"User", Status.user },
            {"Banned", Status.banned }
        };

        public Dictionary<string, Gender> gender = new Dictionary<string, Gender>
        {
            {"Unidentified", Gender.Unidentified },
            {"Woman", Gender.Woman },
            {"Man", Gender.Man }
        };

        public Dictionary<int, string> Months = new Dictionary<int, string>
        {
            { 1, "Styczeń"},
            { 2, "Luty"},
            { 3, "Marzec"},
            { 4, "Kwiecień"},
            { 5, "Maj"},
            { 6, "Czerwiec"},
            { 7, "Lipiec"},
            { 8, "Sierpień"},
            { 9, "Wrzesień"},
            { 10, "Październik"},
            { 11, "Listopad"},
            { 12, "Grudzień"},
        };
    }
}

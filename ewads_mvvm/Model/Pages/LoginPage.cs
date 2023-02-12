using System.Windows;
using System.Windows.Input;

namespace ewads_mvvm.Model.Pages
{
    public class LoginPage
    {
        public string PageTitle { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand Login { get; set; }

        public async void LoginToService()
        {
            System.Console.WriteLine(Email);
            var auth = new Authentication();
            if (await auth.InitiateLogin(Email, Password))
            {
                MessageBox.Show("logged in!", "Succes!");
            }
            else
                MessageBox.Show("Wrong login or password!", "Failed to login!");
        }
    }
}

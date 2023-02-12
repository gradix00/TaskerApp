using ewads_mvvm.Model;
using ewads_mvvm.Model.Helpers;
using ewads_mvvm.Model.Pages;
using System.Windows.Input;

namespace ewads_mvvm
{
    public class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel(LoginPage model)
        {
            this.Model = model;
            Model.Login = new RelayCommand(Model.LoginToService);
        }

        public LoginPage Model { get; private set; }

        public string PageTitle
        {
            get
            {
                return this.Model.PageTitle;
            }
            set
            {
                this.Model.PageTitle = value;
                this.OnPropertyChanged(nameof(PageTitle));
            }
        }
        
        public string Email 
        {
            get { return this.Model.Email; }
            set
            {
                this.Model.Email = value;
                this.OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get { return this.Model.Password; }
            set
            {
                this.Model.Password = value;
                this.OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand Login
        {
            get { return Model.Login; }
            set
            {
                this.Model.Login = value;
                this.OnPropertyChanged(nameof(Login));
            }
        }
    }
}

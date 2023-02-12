using ewads_mvvm.Model.Pages;

namespace ewads_mvvm
{
    public class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel _currentView;
        private string _pageTitle;

        public BaseViewModel CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                this.OnPropertyChanged(nameof(CurrentView));
            }
        }

        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                _pageTitle = value;
                this.OnPropertyChanged(nameof(PageTitle));
            }
        }

        public MainWindowViewModel()
        {
            this.LoadLoginPage();
        }

        private void LoadLoginPage()
        {
            var loginPage = new LoginPageViewModel(new LoginPage())
            {
                PageTitle = "Login to eWads"
            };
            PageTitle = loginPage.PageTitle;
            CurrentView = loginPage;
        }
    }
}

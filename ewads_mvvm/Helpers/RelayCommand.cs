using System;
using System.Windows.Input;

namespace ewads_mvvm.Model.Helpers
{
    public class RelayCommand : ICommand
    {
        private Action method;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action method)
        {
            this.method = method;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            method();
        }
    }
}

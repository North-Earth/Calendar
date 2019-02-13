using Calendar.Service.Helper.Binding;
using System;
using System.Windows.Input;

namespace Calendar.Service.Helper.Commands
{
    public class DelegateCommand : ObservableObject, ICommand
    {
        #region Fields

        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        #endregion

        #region Constructors

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region Methods

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;

            return _canExecute(parameter);
        }

        public void Execute(object parameter) => _execute(parameter);

        #endregion


    }
}

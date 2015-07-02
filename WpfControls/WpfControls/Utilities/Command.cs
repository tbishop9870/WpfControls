using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfControls.Utilities
{
    public class Command : ICommand
    {
        private Action _execute;
        private Func<bool> _canExecute; 
        public Command(Action action)
        {
            _execute = action;
        }

        public Command(Action action, Func<bool> canExecute)
            :this(action)
        {
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged;
    }
}

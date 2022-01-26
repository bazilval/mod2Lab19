using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mod2Lab19
{
    class RelyCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelyCommand(Action<object> Execute, Func<object,bool> CanExecute = null)
        {
            this.execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            this.canExecute = CanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            execute(parameter);            
        }
    }
}

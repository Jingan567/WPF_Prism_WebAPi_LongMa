using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfForPrism.CustomCommands
{
    class DoCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private event Action<string> ExecuteA;

        public bool CanExecute(object? parameter)
        {
            if (parameter is string)
            {
                return true;
            }
            return false;
        }

        public DoCommand(Action<string> action) 
        {
            ExecuteA = action;
        }
        public void Execute(object? parameter)
        {
            ExecuteA?.Invoke((string)parameter);
        }
    }
}

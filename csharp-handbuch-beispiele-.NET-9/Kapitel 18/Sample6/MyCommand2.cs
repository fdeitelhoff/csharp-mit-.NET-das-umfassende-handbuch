using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sample6
{
    public class MyCommand2 : ICommand
    {
        public bool CanExecute(object parameter)
        {
            Debug.WriteLine("COMMAND 2 ... CanExecute");
            return true;
        }

        public event EventHandler CanExecuteChanged;
        //{
        //    add { CommandManager.RequerySuggested += value; }
        //    remove { CommandManager.RequerySuggested -= value; }
        //}


        public void Execute(object parameter)
        {
            Debug.WriteLine("COMMAND 2 ... Execute");
        }
    }
}

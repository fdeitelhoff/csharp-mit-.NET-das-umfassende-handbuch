using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sample5
{
    public class MyCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            Debug.WriteLine("MyCommand ... CanExecute");
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Debug.WriteLine("MyCommand ... Execute");
        }
    }
}

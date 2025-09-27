using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sample6
{
    public class MyCommand1 : ICommand
    {
        public bool CanExecute(object parameter)
        {
            Debug.WriteLine("COMMAND 1 ... CanExecute");
            if (parameter != null)
            {
                TextBox txtBox = parameter as TextBox;
                if (txtBox != null)
                    return txtBox.Text != "";
            }
            return false;
        }

        public event EventHandler CanExecuteChanged;
        //{
        //    add { CommandManager.RequerySuggested += value; }
        //    remove { CommandManager.RequerySuggested -= value; }
        //}


        public void Execute(object parameter)
        {
            Debug.WriteLine("COMMAND 1 ... Execute");
        }
    }
}

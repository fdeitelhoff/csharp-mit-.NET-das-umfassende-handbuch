using MVVM_Sample.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM_Sample
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = (MainViewModel)this.TryFindResource("vm");
            if (vm != null)
            {
                this.CommandBindings.Add(vm.NewCommandBinding);
                this.CommandBindings.Add(vm.DeleteCommandBinding);
                this.CommandBindings.Add(vm.SaveCommandBinding);
                this.CommandBindings.Add(vm.UndoCommandBinding);
                vm.ConfirmDeleting += vm_ConfirmDeleting;
            }
            this.Closing += MainWindow_Closing;
        }

        private void vm_ConfirmDeleting(object sender, CancelEventArgs e)
        {
            string message = "Wollen Sie wirklich löschen?";
            string caption = "MVVM_Sample";
            if (MessageBoxResult.Yes == MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No))
            {
                e.Cancel = false;
                return;
            }
            e.Cancel = true;
        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            vm.CancelViewClosing();
        }
    }
}

using MVVM_Sample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel vm = (MainViewModel)this.TryFindResource("vm");
            if (vm != null)
            {
                this.CommandBindings.Add(vm.NewCommandBinding);
                this.CommandBindings.Add(vm.DeleteCommandBinding);
                this.CommandBindings.Add(vm.SaveCommandBinding);
                this.CommandBindings.Add(vm.UndoCommandBinding);
            }
        }
    }
}

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

namespace Sample1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Print_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtContent != null)
                e.CanExecute = txtContent.Text != "";
        }

        private void Print_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Dokument wird gedruckt.", "Drucken");
        }
    }
}

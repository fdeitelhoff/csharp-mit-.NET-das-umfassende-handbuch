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

namespace RepeatButton_Sample
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

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            lblNumber.Content = Convert.ToInt32(lblNumber.Content.ToString()) + 1;
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            lblNumber.Content = Convert.ToInt32(lblNumber.Content.ToString()) - 1;
        }
    }
}

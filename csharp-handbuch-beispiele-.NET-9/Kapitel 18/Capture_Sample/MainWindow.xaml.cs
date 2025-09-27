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

namespace Capture_Sample
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

        private void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse item = sender as Ellipse;
            if(item != null && item.CaptureMouse())
                item.Fill = Brushes.Blue;
        }

        private void ellipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Ellipse item = sender as Ellipse;
            if (item != null)
            {
                item.Fill = Brushes.Beige;
                if (item.IsMouseCaptured)
                    item.ReleaseMouseCapture();
            }
        }
    }
}

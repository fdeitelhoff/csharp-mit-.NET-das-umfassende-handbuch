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

namespace ScrollViewer_Sample
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

        private void ButtonHandler(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            switch (btn.Name)
            {
                case "btnLineUp":
                    scrViewer.LineUp();
                    break;
                case "btnLineDown":
                    scrViewer.LineDown();
                    break;
                case "btnLineRight":
                    scrViewer.LineRight();
                    break;
                case "btnLineLeft":
                    scrViewer.LineLeft();
                    break;
                case "btnPageUp":
                    scrViewer.PageUp();
                    break;
                case "btnPageDown":
                    scrViewer.PageDown();
                    break;
                case "btnPageRight":
                    scrViewer.PageRight();
                    break;
                case "btnPageLeft":
                    scrViewer.PageLeft();
                    break;
                case "btnTop":
                    scrViewer.ScrollToTop();
                    break;
                case "btnBottom":
                    scrViewer.ScrollToBottom();
                    break;
            }
        }
    }
}

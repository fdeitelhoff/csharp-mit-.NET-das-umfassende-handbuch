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

namespace WPFTests;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        Button btnButton1 = new Button();
        btnButton1.FontSize = 18;
        btnButton1.Background = new SolidColorBrush(Colors.LightGray);
        btnButton1.Content = "Der erste Button";
        Grid1.Children.Add(btnButton1);

    }
}
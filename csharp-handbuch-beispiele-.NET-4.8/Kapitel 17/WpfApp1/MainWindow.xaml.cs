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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StackPanel stackPanel = new StackPanel();
            Button btnOK = new Button();
            btnOK.Content = "OK";
            Button btnUebernehmen = new Button();
            btnUebernehmen.Content = "Übernehmen";
            Button btnAbbrechen = new Button();
            btnAbbrechen.Content = "Abbrechen";
            stackPanel.Children.Add(btnOK);
            stackPanel.Children.Add(btnUebernehmen);
            stackPanel.Children.Add(btnAbbrechen);
            this.AddChild(stackPanel);
        }
    }
}
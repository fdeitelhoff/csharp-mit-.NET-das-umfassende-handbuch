using System;
using System.Collections.Generic;
using System.IO;
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

namespace Converter_Sample2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string imgDirectory = Directory.GetCurrentDirectory() + @"\Images\";
            string[] liste = Directory.GetFileSystemEntries(imgDirectory);
            foreach (var item in liste)
            {
                if (item != imgDirectory + "Thumbs.db")
                    lstDestinations.Items.Add(System.IO.Path.GetFileNameWithoutExtension(item));
            }
            lstDestinations.SelectedIndex = 0;
        }
    }
}

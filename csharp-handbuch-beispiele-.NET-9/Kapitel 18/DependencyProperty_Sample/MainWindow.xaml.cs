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

namespace DependencyProperty_Sample
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Circle k = new Circle(12);
            try
            {
                k.Radius = -12;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class Circle : DependencyObject
    {
        // Ereignis
        public event EventHandler RadiusChanged;

        // Eigenschaft
        public int Maximum { get; set; }

        // Dependency Property
        public static readonly DependencyProperty RadiusProperty;

        // Konstruktor
        public Circle(int maximum) => Maximum = maximum;

        // statischer Konstruktor
        static Circle()
        {
            FrameworkPropertyMetadata meta = new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault);
            meta.CoerceValueCallback = CoerceRadius;
            meta.PropertyChangedCallback = OnRadiusChanged;
            RadiusProperty = DependencyProperty.Register("Radius", typeof(int), typeof(Circle), meta, IsRadiusValid);
        }

        // Überprüfen, ob der objektspezifische Maximalwert überschritten wird
        private static object CoerceRadius(DependencyObject d, object value)
        {
            Circle item = d as Circle;
            if (item.Maximum >= (int)value)
                return value;
            return item.Maximum;
        }

        // bedient den Delegaten 'PropertyChangedCallback'
        public static void OnRadiusChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Circle kreis = sender as Circle;
            if (kreis != null)
                kreis.RadiusChanged?.Invoke(kreis, new EventArgs());
        }

        // Eigenschaftswrapper
        public int Radius
        {
            set => SetValue(RadiusProperty, value); 
            get => (int)GetValue(RadiusProperty); 
        }

        // ValidateValueCallback
        private static bool IsRadiusValid(object value) => (int)value >= 0;
    }

}

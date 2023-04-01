using System.Windows;
using System.Windows.Media;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for WPFResources.xaml
    /// </summary>
    public partial class WPFResources : Window
    {
        public WPFResources()
        {
            InitializeComponent();
        }

        private bool isRed = true;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            string s1 = s.ToUpper();

            var obj = Application.Current.FindResource("DynamicColorBrush");
            obj = FindResource("text1");
            obj = stackPanel.FindResource("text2");

            //if (isRed)
            //{
            //    brush.Color=Colors.Green;
            //}
            //else
            //{
            //    brush.Color=Colors.Red;
            //}
            Color color = isRed ? Colors.Green : Colors.Red;
            SolidColorBrush solid = new SolidColorBrush(color);
            Application.Current.Resources["DynamicColorBrush"] = solid;
            isRed = !isRed;
        }
    }
}

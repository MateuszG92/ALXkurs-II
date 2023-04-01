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
using System.Windows.Shapes;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for ButtonText.xaml
    /// </summary>
    public partial class ButtonText : Window
    {
        public ButtonText()
        {
            InitializeComponent();
            testButton.Content = "ABCD";
            testButton.Click += testButton2_Click;
        }

        private void testButton2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("click2");
        }

        private void testButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("click");
        }
    }
}

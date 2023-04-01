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
    /// Interaction logic for TextBlockExample.xaml
    /// </summary>
    public partial class TextBlockExample : Window
    {
        public TextBlockExample()
        {
            InitializeComponent();
            textBlockFormat.Inlines.Clear();
            textBlockFormat.Inlines.Add("aaa ");
            textBlockFormat.Inlines.Add(new Run("BBB ")
            {
                FontSize = 20,
                FontWeight = FontWeights.Bold
            });
            textBlockFormat.Inlines.Add(new Run("CCC")
            {
                Foreground = Brushes.Aquamarine,
                TextDecorations = TextDecorations.Strikethrough
            });
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }

    }
}

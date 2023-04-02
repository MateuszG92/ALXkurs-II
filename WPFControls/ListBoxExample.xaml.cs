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

namespace WPFControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ListBoxExample : Window
    {
        public ListBoxExample()
        {
            InitializeComponent();
            List<TaskProgress> items = new List<TaskProgress>
            {
                new TaskProgress() { Title = "Zadanie 1", Progress = 30 },
                new TaskProgress() { Title = "Zadanie 2", Progress = 20 },
                new TaskProgress() { Title = "Zadanie 3", Progress = 40 },
                new TaskProgress() { Title = "Zadanie 4", Progress = 50 }
            };
            lbTasks.ItemsSource = items;
        }
    }

    public class TaskProgress
    {
        public string Title { get; set; }  
        public int Progress { get; set; }
    }
}

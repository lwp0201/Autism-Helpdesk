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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for game.xaml
    /// </summary>
    public partial class game : Window
    {
        public game()
        {
            InitializeComponent();
        }

        private void Window_Loaded(Object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleanimation = new DoubleAnimation(0, 1200, new Duration(TimeSpan.FromSeconds(5)));
            label1.BeginAnimation(WidthProperty, doubleanimation);
            doubleanimation.EasingFunction = new QuarticEase();
            

        }

        private void notnotbtn_Click(object sender, RoutedEventArgs e)
        {
            not dashboard = new not();
            dashboard.Show();
            this.Close();
        }
    }
}

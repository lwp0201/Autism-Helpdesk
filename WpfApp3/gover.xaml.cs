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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for gover.xaml
    /// </summary>
    public partial class gover : Window
    {
        public gover()
        {
            InitializeComponent();
        }

        public void setScore(int score) {
            scorebox.Text = "Score:"+score.ToString();
        }

        private void namebox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (namebox.Text.Equals("Enter your name here.."))
                namebox.Text = "";
        }

        private void donebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

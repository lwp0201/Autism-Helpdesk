using LoginPage;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Class1 timerclass = new Class1();
            timerclass.timer.Start();
            scheduler_dock.IsEnabled = false;
            video_dock.IsEnabled = false;
            game_dock.IsEnabled = false;
            logoutBtn.Visibility = Visibility.Hidden;
            logoutBtn.IsEnabled = false;
        }

        public void showmain() {
            this.Show();

        }

        public void logincheck(String uname) {

            scheduler_dock.IsEnabled = true;
            video_dock.IsEnabled = true;
            game_dock.IsEnabled = true;
            logoutBtn.Visibility = Visibility.Visible;
            logoutBtn.IsEnabled = true;

            usernamebox.Text = uname;
            logbtn.IsEnabled = false;
            logbtn.Visibility = Visibility.Hidden;
            signbtn.IsEnabled = false;
            signbtn.Visibility = Visibility.Hidden;


        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            scheduler_dock.IsEnabled = false;
            video_dock.IsEnabled = false;
            game_dock.IsEnabled = false;
            logoutBtn.Visibility = Visibility.Hidden;
            logoutBtn.IsEnabled = false;

            usernamebox.Text = "";
            logbtn.IsEnabled = true;
            logbtn.Visibility = Visibility.Visible;
            signbtn.IsEnabled = true;
            signbtn.Visibility = Visibility.Visible;
        }

        private void signbtn_Click(object sender, RoutedEventArgs e)
        {
            Window1 dashboard = new Window1();
            dashboard.Show();
            this.Close();
            
        }

        private void logbtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow dashboard = new LoginWindow();
            dashboard.Show();
            this.Close();
        }

        private void info_dock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            info dashboard = new info();
            dashboard.Show();
            //this.Hide();
            this.WindowState = WindowState.Minimized;

        }

        private void symptom_dock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void about_dock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            about dashboard = new about();
            dashboard.Show();
            //this.Hide();
            this.WindowState = WindowState.Minimized;
        }

        private void howtouse_dock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            howtouse dashboard = new howtouse();
            dashboard.Show();
            //this.Hide();
            this.WindowState = WindowState.Minimized;
        }

        private void scheduler_dock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            schedule dashboard = new schedule();
            dashboard.Show();
            //this.Hide();
            this.WindowState = WindowState.Minimized;
        }

        private void video_dock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void game_dock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            game dashboard = new game();
            dashboard.Show();
            //this.Hide();
            this.WindowState = WindowState.Minimized;
        }
    }
}

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
using System.Timers;
using System.Windows.Threading;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for not.xaml
    /// </summary>
    public partial class not : Window
    {
        string[] dirarr = new string[12];
        int rannum;
        int score = 0;
        Random rnd = new Random();
        int over;
        DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };

        public not()
        {
            InitializeComponent();
            dirarr[0] = "LEFT";
            dirarr[1] = "RIGHT";
            dirarr[2] = "UP";
            dirarr[3] = "DOWN";
            dirarr[4] = "NOT\nLEFT";
            dirarr[5] = "NOT\nRIGHT";
            dirarr[6] = "NOT\nUP";
            dirarr[7] = "NOT\nDOWN";
            dirarr[8] = "YELLOW";
            dirarr[9] = "BLUE";
            dirarr[10] = "GREEN";
            dirarr[11] = "RED";
            

        }
        private void Window_Loaded(Object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleanimation = new DoubleAnimation(.2,.9, new Duration(TimeSpan.FromSeconds(5)));
            doubleanimation.AutoReverse = true;
            doubleanimation.RepeatBehavior = RepeatBehavior.Forever;
            grid1.BeginAnimation(OpacityProperty, doubleanimation);
            doubleanimation.EasingFunction = new QuarticEase();

            this.PreviewKeyDown += GameScreen_PreviewKeyDown;
            this.Focusable = true;
            this.Focus();
        }

        void GameScreen_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            /*if(e.Key==Key.Right)
            MessageBox.Show("it works!");*/
            if (e.Key == Key.Right) {
                if (directionbox.Text.Equals("RIGHT") || directionbox.Text.Equals("NOT\nLEFT") || directionbox.Text.Equals("GREEN"))
                {
                    rannum = rnd.Next(0, 11);
                    directionbox.Text = dirarr[rannum].ToString();
                    score++;
                    scorebox.Text = score.ToString();
                    over = 0;
                }
                else {
                    timer.Stop();
                    gotoover();
                    this.Close();
                    //MessageBox.Show("Game Over!Score:" + score);
                }
            }
            else if (e.Key == Key.Left)
            {
                if (directionbox.Text.Equals("LEFT") || directionbox.Text.Equals("NOT\nRIGHT") || directionbox.Text.Equals("YELLOW"))
                {
                    rannum = rnd.Next(0, 11);
                    directionbox.Text = dirarr[rannum].ToString();
                    score++;
                    scorebox.Text = score.ToString();
                    over = 0;
                }
                else
                {
                    timer.Stop();
                    gotoover();
                    this.Close();
                    //MessageBox.Show("Game Over!Score:" + score);
                }
            }
            else if (e.Key == Key.Up)
            {
                if (directionbox.Text.Equals("UP") || directionbox.Text.Equals("NOT\nDOWN") || directionbox.Text.Equals("BLUE"))
                {
                    rannum = rnd.Next(0, 11);
                    directionbox.Text = dirarr[rannum].ToString();
                    score++;
                    scorebox.Text = score.ToString();
                    over = 0;
                }
                else
                {
                    timer.Stop();
                    gotoover();
                    this.Close();
                    //MessageBox.Show("Game Over!Score:" + score);
                }
            }
            else if (e.Key == Key.Down)
            {
                if (directionbox.Text.Equals("DOWN") || directionbox.Text.Equals("NOT\nUP") || directionbox.Text.Equals("RED"))
                {
                    rannum = rnd.Next(0, 11);
                    directionbox.Text = dirarr[rannum].ToString();
                    score++;
                    scorebox.Text = score.ToString();
                    over = 0;
                }
                else
                {
                    timer.Stop();
                    gotoover();
                    this.Close();
                    //MessageBox.Show("Game Over!Score:" + score);
                }
            }

            
        }

        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            this.timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            rannum = rnd.Next(0, 11);
            directionbox.Text = dirarr[rannum].ToString();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            over++;
            if (over == 5) {
                timer.Stop();
                gover dashboard = new gover();
                dashboard.setScore(score);
                dashboard.Show();
                this.Close();
                //MessageBox.Show("Game Over!Score:"+score);
                
            }
        }

        private void gotoover() {
            gover dashboard = new gover();
            dashboard.setScore(score);
            dashboard.Show();
        }
    }
}

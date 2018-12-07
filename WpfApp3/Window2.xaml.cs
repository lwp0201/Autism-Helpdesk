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
using System.Timers;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Timer timer;
        String description;
        String id;

        public Window2()
        {
            InitializeComponent();
            setalarm();
        }

        private void setalarm() {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elaspsed;
        }

        private void Timer_Elaspsed(object sender, ElapsedEventArgs e) {

            DateTime cuurenttime = DateTime.Now;
            SqlConnection sqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AutismHelpdesk;Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    string sqlquery = "SELECT * FROM Scheduler WHERE date = @date AND time = @time";

                    SqlCommand command = new SqlCommand(sqlquery, sqlCon);
                    SqlDataReader sReader;

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@time", DateTime.Now.ToString("HH:mm:ss"));
                    sReader = command.ExecuteReader();

                    while (sReader.Read())
                    {

                        //infos.Append(sReader["name"].ToString()).Append("\n");

                        description = sReader["description"].ToString();
                        id= sReader["serial"].ToString();

                    }

                    timer.Stop();
                    try
                    {
                        MediaPlayer Sound1 = new MediaPlayer();
                        Sound1.Open(new Uri(@"D:\Study\3.2\SD\Sound\Sound1.wav"));
                        Sound1.Play();

                    }
                    catch(Exception ex) {

                        MessageBox.Show(ex.Message);
                    }

                    //sReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}

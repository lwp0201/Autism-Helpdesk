using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WpfApp3
{
    class Class1
    {
        public Timer timer;
        String description;
        String id;

        public Class1() {
            setalarm();
        }
        private void setalarm()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elaspsed;
        }
        private void Timer_Elaspsed(object sender, ElapsedEventArgs e)
        {

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
                        id = sReader["serial"].ToString();

                    }
                    if (id != null) {
                        timer.Stop();
                        Console.WriteLine("DING DING!");
                    }
                    

                    //sReader.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                Console.WriteLine("Error!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}

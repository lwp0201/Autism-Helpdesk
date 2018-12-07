using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for schedule.xaml
    /// </summary>
    public partial class schedule : Window
    {
        public schedule()
        {
            InitializeComponent();
            
        }

        private void setbtn_Click(object sender, RoutedEventArgs e)
        {
            char[] arr = new char[5];
            

            arr = timebox.Text.ToCharArray();

            if (timebox.Text.Length!=5 || arr[2]!=':' || (arr[0]!='0' && arr[0] != '1') || (Convert.ToInt16(arr[1])<48 || Convert.ToInt16(arr[1]) > 57) || (Convert.ToInt16(arr[3]) < 48 || Convert.ToInt16(arr[3]) > 53) || (Convert.ToInt16(arr[4]) < 48 || Convert.ToInt16(arr[4]) > 57)) {

                MessageBox.Show("wrong format!Please keep the time format as hh:mm and in 12 hour format.");
                return;
            }


            if (ambox.IsChecked == true)
            {
                if (arr[0] == '1' && arr[1] == '2')
                {
                    arr[0] = '0';
                    arr[1] = '0';
                }
            }
            else {
                if (arr[0] == '1' && arr[1] == '2')
                {
                    arr[0] = '1';
                    arr[1] = '2';
                }
                else if (arr[0] == '1' && arr[1] == '1')
                {
                    arr[0] = '2';
                    arr[1] = '3';
                }
                else if (arr[0] == '1' && arr[1] == '0')
                {
                    arr[0] = '2';
                    arr[1] = '2';
                }
                else if (arr[0] == '0' && arr[1] == '9')
                {
                    arr[0] = '2';
                    arr[1] = '1';
                }
                else if (arr[0] == '0' && arr[1] == '8')
                {
                    arr[0] = '2';
                    arr[1] = '0';
                }
                else {
                    arr[0] = Convert.ToChar(Convert.ToInt16(arr[0]) + 1);
                    arr[1] = Convert.ToChar(Convert.ToInt16(arr[1]) + 2);
                } 

            }

            string timest = new string(arr);

            char[] arr2 = new char[10];
            char[] arr3 = new char[10];
            arr2 = datebox.ToString().ToCharArray();

            if (arr2[1] == '/' && arr2[3] == '/')
            {
                arr3[0] = arr2[4];
                arr3[1] = arr2[5];
                arr3[2] = arr2[6];
                arr3[3] = arr2[7];
                arr3[4] = '-';
                arr3[5] = '0';
                arr3[6] = arr2[0];
                arr3[7] = '-';
                arr3[8] = '0';
                arr3[9] = arr2[2];
            }
            else if (arr2[2] == '/' && arr2[5] == '/')
            {
                arr3[0] = arr2[6];
                arr3[1] = arr2[7];
                arr3[2] = arr2[8];
                arr3[3] = arr2[9];
                arr3[4] = '-';
                arr3[5] = arr2[0];
                arr3[6] = arr2[1];
                arr3[7] = '-';
                arr3[8] = arr2[3];
                arr3[9] = arr2[4];
            }
            else if (arr2[1] == '/' && arr2[4] == '/')
            {
                arr3[0] = arr2[5];
                arr3[1] = arr2[6];
                arr3[2] = arr2[7];
                arr3[3] = arr2[8];
                arr3[4] = '-';
                arr3[5] = '0';
                arr3[6] = arr2[0];
                arr3[7] = '-';
                arr3[8] = arr2[2];
                arr3[9] = arr2[3];
            }
            else if (arr2[2] == '/' && arr2[4] == '/')
            {
                arr3[0] = arr2[5];
                arr3[1] = arr2[6];
                arr3[2] = arr2[7];
                arr3[3] = arr2[8];
                arr3[4] = '-';
                arr3[5] = arr2[0];
                arr3[6] = arr2[1];
                arr3[7] = '-';
                arr3[8] = '0';
                arr3[9] = arr2[3];
            }
           

            string datest = new string(arr3);
            //MessageBox.Show(datest);

            TextRange trange = new TextRange(
                descripbox.Document.ContentStart,
                descripbox.Document.ContentEnd
                );

            //MessageBox.Show(trange.Text);

            SqlConnection sqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AutismHelpdesk;Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    //MessageBox.Show("Success!");
                    String query = "INSERT INTO Scheduler (time, date, description) VALUES(@time, @date, @description)";

                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@time", timest);
                    sqlCmd.Parameters.AddWithValue("@date", datest);
                    sqlCmd.Parameters.AddWithValue("@description", trange.Text);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    // MessageBox.Show(count.ToString());
                    /*if (count == 1)
                    {
                        MessageBox.Show(query);

                    }
                    else
                    {
                        MessageBox.Show("Wrong!");
                    }*/

                }
                MessageBox.Show("Schedular Set!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Username Already Taken!");
            }
            finally
            {
                sqlCon.Close();
            }

            

        }
    
        

        private void ambox_Checked(object sender, RoutedEventArgs e)
        {
            pmbox.IsChecked = false;
        }

        private void pmbox_Checked(object sender, RoutedEventArgs e)
        {
            ambox.IsChecked = false;
        }

       
    }
}

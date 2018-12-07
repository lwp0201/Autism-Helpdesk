using LoginPage;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow dashboard = new LoginWindow();
            dashboard.Show();
            this.Close();
        }

        private void signBtn_Click(object sender, RoutedEventArgs e)
        {

            if (uname.Text == "" || fname.Text == "" || phone.Text == "" || pass.Text == "" || pass2.Text == "" || cname.Text == "" || age.Text == "" || location.Text == "") {
                MessageBox.Show("One or More fields are empty!");
                return;
            }

            if (!pass.Text.Equals(pass2.Text)) {
                MessageBox.Show("Passwords are not matched!");
                return;
            }

            //MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd"));

            SqlConnection sqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AutismHelpdesk;Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    //MessageBox.Show("Success!");
                    String query = "INSERT INTO tblUser (username, password, date) VALUES(@username, @password, @date)";

                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@username", uname.Text);
                    sqlCmd.Parameters.AddWithValue("@password", pass.Text);
                    sqlCmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
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

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Username Already Taken!");
            }
            finally
            {
                sqlCon.Close();
            }

            String uid="";

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    string sqlquery = "SELECT * FROM tblUser WHERE username = @uname";

                    SqlCommand command = new SqlCommand(sqlquery, sqlCon);
                    SqlDataReader sReader;

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@uname", uname.Text);
                    sReader = command.ExecuteReader();

                    while (sReader.Read())
                    {
                        //MessageBox.Show(sReader["id"].ToString());
                        uid = sReader["id"].ToString();

                    }

                    sReader.Close();

                    String query = "INSERT INTO Supervisor (id, name, phone, address, email) VALUES(@uid, @fname, @phone, @add, @mail)";

                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@uid", Convert.ToInt32(uid));
                    sqlCmd.Parameters.AddWithValue("@fname", fname.Text);
                    sqlCmd.Parameters.AddWithValue("@phone", phone.Text);
                    sqlCmd.Parameters.AddWithValue("@add", location.Text);
                    sqlCmd.Parameters.AddWithValue("@mail", "");

                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

                    String query2 = "INSERT INTO Child (user_id, name, gender, age) VALUES(@uid, @cname, @gen, @age)";

                    SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                    sqlCmd2.CommandType = CommandType.Text;
                    sqlCmd2.Parameters.AddWithValue("@uid", Convert.ToInt32(uid));
                    sqlCmd2.Parameters.AddWithValue("@cname", cname.Text);

                    if(malebtn.IsChecked==true)
                    {
                        sqlCmd2.Parameters.AddWithValue("@gen", "male");
                    }else if (febtn.IsChecked == true)
                    {
                        sqlCmd2.Parameters.AddWithValue("@gen", "female");
                    }
                    else if (otherbtn.IsChecked == true)
                    {
                        sqlCmd2.Parameters.AddWithValue("@gen", "other");
                    }

                    sqlCmd2.Parameters.AddWithValue("@age", Convert.ToInt32(age.Text));

                    int count2 = Convert.ToInt32(sqlCmd2.ExecuteScalar());

                    MessageBox.Show("Done!");

                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    this.Close();
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

        private void tb_GotFocus(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show("Yeeet");
            if (uname.IsFocused && uname.Text == "User Name")
                uname.Text = "";
            else if (fname.IsFocused && fname.Text == "Full Name")
                fname.Text = "";
            else if (phone.IsFocused && phone.Text == "Phone")
                phone.Text = "";
            else if (pass.IsFocused && pass.Text == "Password")
                pass.Text = "";
            else if (pass2.IsFocused && pass2.Text == "Re-type password")
                pass2.Text = "";
            else if (cname.IsFocused && cname.Text == "Child Name")
                cname.Text = "";
            else if (age.IsFocused && age.Text == "Child Age")
                age.Text = "";
            else if (location.IsFocused && location.Text == "Location")
                location.Text = "";
        }
    }
}

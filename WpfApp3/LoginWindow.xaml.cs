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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3;

namespace LoginPage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(usernameBox.Text+passBox.Text);
            SqlConnection sqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AutismHelpdesk;Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed) {
                    sqlCon.Open();
                    //MessageBox.Show("Success!");
                    String query = "SELECT COUNT(1) FROM tblUser WHERE username=@username AND password=@password";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@username", usernameBox.Text);
                    sqlCmd.Parameters.AddWithValue("@password", passBox.Text);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (count == 1)
                    {
                        //MessageBox.Show("User found!");

                       
                        MainWindow dashboard = new MainWindow();
                        dashboard.logincheck(usernameBox.Text);
                        dashboard.Show();
                        this.Close();


                        String query2 = "INSERT INTO tblUser (loggedin) VALUES (@login) WHERE username=@username";
                        SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                        sqlCmd2.CommandType = CommandType.Text;
                        sqlCmd2.Parameters.AddWithValue("@username", usernameBox.Text);
                        sqlCmd2.Parameters.AddWithValue("@login", 1);
                        int count2 = Convert.ToInt32(sqlCmd.ExecuteScalar());

                    }
                    else {
                        MessageBox.Show("Wrong!");
                    }
                }
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                sqlCon.Close();
            }
        }
    }
}

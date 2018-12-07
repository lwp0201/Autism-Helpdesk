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
    /// Interaction logic for info.xaml
    /// </summary>
    public partial class info : Window
    {
        public info()
        {
            InitializeComponent();
        }

        string[] dhakadis = new string[] { "Dhaka", "Gazipur", "Kisoreganj", "Manikganj", "Munsiganj", "Narayanganj", "Narsingdi", "Tangail" ,"Faridpur", "Gopalganj","Madaripur","Rajbari", "Shariatpur",  };
        string[] dhakaarea = new string[] { "Gulshan", "Panthopoth", "Dhanmondi", "Mirpur", "Uttara", "Malibagh", "Khilgaon", "Kotwali", "Tejgaon", "Mohakhali", "Banani", "Mohammadpur", "Gabtoli", "Badda", "Baridhara", "Farmgate", "Pallabi", "Nikunja" };
        System.Text.StringBuilder infos = new System.Text.StringBuilder();
        System.Text.StringBuilder infos2 = new System.Text.StringBuilder();
        StringBuilder locationde = new StringBuilder();
        String test;

        private void divbox_DropDownClosed(object sender, EventArgs e)
        {
            //MessageBox.Show(divbox.SelectionBoxItem.ToString());
            if (divbox.SelectionBoxItem.ToString().Equals("Dhaka")) {
                disbox.ItemsSource = dhakadis;
                disbox.SelectedIndex = 0;
            }
                
            
        }
        private void disbox_DropDownClosed(object sender, EventArgs e)
        {
            if (disbox.SelectionBoxItem.ToString().Equals("Dhaka"))
            {
                areabox.ItemsSource = dhakaarea;
                areabox.SelectedIndex = 0;
            }
        }

        private void areabox_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void searchbtn_Click(object sender, RoutedEventArgs e)
        {
            if (searchbox.Text.Equals("Search") || searchbox.Text.Equals("")) {
                MessageBox.Show("Invalid Input!Try Again.");
                return;
            }

            SqlConnection sqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AutismHelpdesk;Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    string sqlquery = "SELECT * FROM ins_info WHERE name LIKE '%"+searchbox.Text+"%'";

                    SqlCommand command = new SqlCommand(sqlquery, sqlCon);
                    SqlDataReader sReader;

                    //command.Parameters.Clear();
                    //command.Parameters.AddWithValue("@searchtxt", searchbox.Text);
                    sReader = command.ExecuteReader();

                    while (sReader.Read())
                    {
                       
                        infos.Append(sReader["name"].ToString()).Append("\n");
                        infos.Append(sReader["location"].ToString()).Append("\n");
                        infos.Append(sReader["phone"].ToString()).Append("\n");
                        if(!sReader["mail"].ToString().Equals(""))
                            infos.Append(sReader["mail"].ToString()).Append("\n");
                        if (!sReader["inCharge"].ToString().Equals(""))
                            infos.Append(sReader["inCharge"].ToString()).Append("\n\n");
                            
                        //test= sReader["name"].ToString();

                    }


                    MessageBox.Show(infos.ToString());

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

        private void searhbox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (searchbox.Text.Equals("Search"))
                searchbox.Text = "";
        }

        private void searhbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (searchbox.Text.Equals(""))
                searchbox.Text = "Search";
        }

        private void schoolbtn_Click(object sender, RoutedEventArgs e)
        {
            if (divbox.SelectedIndex < 0 || disbox.SelectedIndex < 0 || areabox.SelectedIndex < 0) {
                MessageBox.Show("One or more fields are not specified!");
                return;
            }

            getinfo("School");

        }

        private void ngobtn_Click(object sender, RoutedEventArgs e)
        {
            if (divbox.SelectedIndex < 0 || disbox.SelectedIndex < 0 || areabox.SelectedIndex < 0)
            {
                MessageBox.Show("One or more fields are not specified!");
                return;
            }

            getinfo("Ngo");
        }

        private void hospitalbtn_Click(object sender, RoutedEventArgs e)
        {
            if (divbox.SelectedIndex < 0 || disbox.SelectedIndex < 0 || areabox.SelectedIndex < 0)
            {
                MessageBox.Show("One or more fields are not specified!");
                return;
            }

            getinfo("Hospital");
        }

        private void getinfo(String instype) {

            int insid = 0;
            locationde.Append(areabox.SelectionBoxItem.ToString());
            locationde.Append(disbox.SelectionBoxItem.ToString());
            locationde.Append(divbox.SelectionBoxItem.ToString());


            SqlConnection sqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AutismHelpdesk;Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    string sqlquery = "SELECT * FROM ins_type WHERE name= @instype";

                    SqlCommand command = new SqlCommand(sqlquery, sqlCon);
                    SqlDataReader sReader;

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@instype", instype);
                    sReader = command.ExecuteReader();

                    while (sReader.Read())
                    {
                        //MessageBox.Show(sReader["id"].ToString());
                        insid = Convert.ToInt32(sReader["id"].ToString());
                    }

                    sReader.Close();

                    string sqlquery2 = "SELECT * FROM ins_info WHERE id=@insid AND location=@location";

                    SqlCommand command2 = new SqlCommand(sqlquery2, sqlCon);
                    //SqlDataReader sReader;

                    command2.Parameters.Clear();
                    command2.Parameters.AddWithValue("@insid", insid);
                    command2.Parameters.AddWithValue("@location", locationde.ToString());
                    sReader = command2.ExecuteReader();

                    while (sReader.Read())
                    {

                        infos2.Append(sReader["name"].ToString()).Append("\n");
                        infos2.Append(sReader["phone"].ToString()).Append("\n");
                        if (!sReader["mail"].ToString().Equals(""))
                            infos2.Append(sReader["mail"].ToString()).Append("\n");
                        if (!sReader["inCharge"].ToString().Equals(""))
                            infos2.Append(sReader["inCharge"].ToString()).Append("\n\n");

                        //test= sReader["name"].ToString();

                    }


                    MessageBox.Show(infos2.ToString());


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

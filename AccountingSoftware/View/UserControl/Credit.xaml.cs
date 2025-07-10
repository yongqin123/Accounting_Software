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
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace AccountingSoftware.View.UserControl
{
    /// <summary>
    /// Interaction logic for Credit.xaml
    /// </summary>
    public partial class Credit : System.Windows.Controls.UserControl
    {
        public Credit()
        {
            InitializeComponent();
            string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            List<string> accounts = new List<string> { };
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT name FROM Account";

                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        String result = reader.GetString(0);
                        accounts.Add(result);

                    }
                }
                string[] accountsArray = accounts.ToArray();
                account.ItemsSource = accountsArray;
                conn.Close();



            }
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            amount.Text = "";
            account.Text = "";
            entry.Children.Clear();
        }


    }
}
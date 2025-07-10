using System;
using System.Collections.Generic;
using System.Data;
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
//using Microsoft.Data.SqlClient; // Or System.Data.SqlClient for .NET Framework
using System.Configuration;
//using System.Data; // Required for DataTable


namespace AccountingSoftware.View
{
    /// <summary>
    /// Interaction logic for ShowAccounts.xaml
    /// </summary>
    public partial class ShowAccounts : Page
    {
        private Frame _mainFrame;
        public ShowAccounts(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;

            //Add Stack Color
            SolidColorBrush color1 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#222D32"));
            stackLeft.Background = color1;

            //Admin Panel
            SolidColorBrush color2 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1A2226"));
            stackRight.Background = color2;

            grid.Background = color2;

            string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
           // connStr = connStr.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT Id, name, type, amount FROM Account";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    UserDataGrid.ItemsSource = dt.DefaultView;
                }
            }
        }
        private void addAccount_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AddAccount(_mainFrame));
        }

        private void viewAccount_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ShowAccounts(_mainFrame));
        }

        private void journalEntry_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new View.JournalEntry(_mainFrame));
        }
        private void home_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Home(_mainFrame));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            // No row selected no delete....
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            // Prepare the command text with the parameter placeholder
            string sql = "DELETE FROM Account WHERE Id = @rowID";

            // Create the connection and the command inside a using block
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            using (SqlCommand deleteRecord = new SqlCommand(sql, myConnection))
            {
                myConnection.Open();

                int selectedIndex = UserDataGrid.SelectedIndex;

                // gets the RowID from the first column in the grid

                DataRowView data = UserDataGrid.SelectedItem as DataRowView;


                var rowID = data["Id"].ToString();
                //Console.WriteLine(UserDataGrid.SelectedItem.ToString());
                // Add the parameter to the command collection
                deleteRecord.Parameters.Add("@rowID", SqlDbType.Int).Value = rowID;
                deleteRecord.ExecuteNonQuery();

                _mainFrame.Navigate(new Home(_mainFrame));
            }
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = UserDataGrid.SelectedIndex;

            // gets the RowID from the first column in the grid

            DataRowView data = UserDataGrid.SelectedItem as DataRowView;


            int id = int.Parse(data["Id"].ToString());
            var name = data["name"].ToString();
            var type = data["type"].ToString();
            double amount = double.Parse(data["amount"].ToString());
            Account account = new Account(id, name, type, amount);
            _mainFrame.Navigate(new EditAccount(_mainFrame, account));

        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Login(_mainFrame));
        }

        private void sfp_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new SFP(_mainFrame));
        }

        private void sci_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new SCI(_mainFrame));
        }
    }
}

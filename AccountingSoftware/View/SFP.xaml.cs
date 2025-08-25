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

using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace AccountingSoftware.View
{
    /// <summary>
    /// Interaction logic for SFP.xaml
    /// </summary>
    public partial class SFP : Page
    {
        private Frame _mainFrame;
        public SFP(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            DateTime today = DateTime.Today;
            string formattedDate = today.ToString("dd/MM/yyyy");
            
            //SolidColorBrush color1 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            title.Text = $"Statement Of Financial Position As at {formattedDate}";
            //title.Foreground = color1;
            
            title.FontSize = 30;
            
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AccountingDatabase.mdf;Integrated Security=True";
            double total_assets = 0;
            double total_liability = 0;
            double total_equity = 0;
            double total_revenue = 0;
            double total_expense = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string selectQuesry = "SELECT name,amount FROM Account WHERE type='Revenue'";

                using (SqlCommand cmd = new SqlCommand(selectQuesry, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {                      
                        total_revenue += Double.Parse(reader[1].ToString());
                    }                 
                    reader.Close();
                }
                string selectQuery = "SELECT name,amount FROM Account WHERE type='Expense'";

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {                        
                        total_expense += Double.Parse(reader[1].ToString());
                    }
                    reader.Close();
                }


                string selectQuery3 = "SELECT name,amount FROM Account WHERE type='Asset'";
                
                using (SqlCommand cmd = new SqlCommand(selectQuery3, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        TextBlock account = new TextBlock();
                        TextBlock amount = new TextBlock();
                        account.FontSize = 30;
                        amount.FontSize = 30;
                        account.Text = reader[0].ToString();
                        total_assets += Double.Parse(reader[1].ToString());
                        amount.Text = reader[1].ToString();
                        assetAccount.Children.Add(account);
                        assetAmount.Children.Add(amount);
                    }
                    TextBlock totalAccount = new TextBlock();
                    TextBlock totalAmount = new TextBlock();
                    totalAccount.Text = "Total Asset";
                    totalAccount.FontSize = 30;
                    totalAmount.FontSize = 30;
                    totalAmount.Text = total_assets.ToString();
                    assetAccount.Children.Add(totalAccount);
                    assetAmount.Children.Add(totalAmount);
                    reader.Close();
                }
                string selectQuery4 = "SELECT name,amount FROM Account WHERE type='Liability'";

                using (SqlCommand cmd = new SqlCommand(selectQuery4, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TextBlock account = new TextBlock();
                        TextBlock amount = new TextBlock();
                        account.Text = reader[0].ToString();
                        amount.Text = reader[1].ToString();
                        account.FontSize = 30;
                        amount.FontSize = 30;
                        total_liability += Double.Parse(reader[1].ToString());
                        liabilityAccount.Children.Add(account);
                        liabilityAmount.Children.Add(amount);
                    }
                    TextBlock totalAccount = new TextBlock();
                    TextBlock totalAmount = new TextBlock();
                    totalAccount.Text = "Total Liability";
                    totalAccount.FontSize = 30;
                    totalAmount.FontSize = 30;
                    totalAmount.Text = total_liability.ToString();
                    liabilityAccount.Children.Add(totalAccount);
                    liabilityAmount.Children.Add(totalAmount);
                    reader.Close();
                }

                string selectQuery2 = "SELECT name,amount FROM Account WHERE type='Equity'";

                using (SqlCommand cmd = new SqlCommand(selectQuery2, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TextBlock account = new TextBlock();
                        TextBlock amount = new TextBlock();
                        account.FontSize = 30;
                        amount.FontSize = 30;
                        account.Text = reader[0].ToString();
                        amount.Text = reader[1].ToString();
                        total_equity += Double.Parse(reader[1].ToString());
                        equityAccount.Children.Add(account);
                        equityAmount.Children.Add(amount);
                    }
                    reader.Close();
                    TextBlock retainedEarningsLabel = new TextBlock();
                    TextBlock retainedEarnings = new TextBlock();
                    retainedEarnings.FontSize = 30;
                    retainedEarningsLabel.FontSize = 30;
                    retainedEarnings.Text = (total_revenue-total_expense).ToString();
                    retainedEarningsLabel.Text = "Retained Earnings";
                    equityAccount.Children.Add(retainedEarningsLabel);
                    equityAmount.Children.Add(retainedEarnings);
                    total_equity += (total_revenue - total_expense);

                    TextBlock totalAccount = new TextBlock();
                    TextBlock totalAmount = new TextBlock();
                    totalAccount.Text = "Total Equity";
                    totalAccount.FontSize = 30;
                    totalAmount.FontSize = 30;
                    totalAmount.Text = total_equity.ToString();
                    equityAccount.Children.Add(totalAccount);
                    equityAmount.Children.Add(totalAmount);
                }

            }

        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Home(_mainFrame));
        }
    }
}

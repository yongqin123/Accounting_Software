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

namespace AccountingSoftware.View
{
    /// <summary>
    /// Interaction logic for SCI.xaml
    /// </summary>
    public partial class SCI : Page
    {
        private Frame _mainFrame;
        public SCI(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            DateTime today = DateTime.Today;
            string formattedDate = today.ToString("dd/MM/yyyy");

            //SolidColorBrush color1 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            title.Text = $"Statement Of Comprehensive Income As at {formattedDate}";
            //title.Foreground = color1;

            title.FontSize = 30;

            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AccountingDatabase.mdf;Integrated Security=True";
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
                        TextBlock account = new TextBlock();
                        TextBlock amount = new TextBlock();
                        account.FontSize = 30;
                        amount.FontSize = 30;
                        account.Text = reader[0].ToString();
                        total_revenue += Double.Parse(reader[1].ToString());
                        amount.Text = reader[1].ToString();
                        revenueAccount.Children.Add(account);
                        revenueAmount.Children.Add(amount);
                    }
                    TextBlock totalRevenueTB = new TextBlock();
                    TextBlock totalRevenueLabelTB = new TextBlock();
                    totalRevenueLabelTB.FontSize = 30;
                    totalRevenueTB.FontSize = 30;
                    totalRevenueTB.Text = total_revenue.ToString();
                    totalRevenueLabelTB.Text = "Total Revenue";
                    revenueAccount.Children.Add(totalRevenueLabelTB);
                    revenueAmount.Children.Add(totalRevenueTB);
                    reader.Close();
                }
                string selectQuery = "SELECT name,amount FROM Account WHERE type='Expense'";

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
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
                        total_expense += Double.Parse(reader[1].ToString());
                        expenseAccount.Children.Add(account);
                        expenseAmount.Children.Add(amount);
                    }
                    TextBlock totalExpenseTB = new TextBlock();
                    TextBlock totalExpenseLabelTB = new TextBlock();
                    totalExpenseLabelTB.FontSize = 30;
                    totalExpenseTB.FontSize = 30;
                    totalExpenseTB.Text = total_expense.ToString();
                    totalExpenseLabelTB.Text = "Total Expense";
                    expenseAccount.Children.Add(totalExpenseLabelTB);
                    expenseAmount.Children.Add(totalExpenseTB);
                    reader.Close();
                }

            }

            double totalNetAmount = total_revenue - total_expense;
            netAmount.Text = totalNetAmount.ToString();

        }
        private void home_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Home(_mainFrame));
        }
    }
}

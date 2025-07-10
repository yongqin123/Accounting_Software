using System;
using System.Collections;
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
using System.Configuration;

using AccountingSoftware.View;
using Microsoft.Data.SqlClient;
using ScottPlot;

namespace AccountingSoftware
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private Frame _mainFrame;
        public Home(Frame mainFrame)
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

            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AccountingDatabase.mdf;Integrated Security=True";
            List<string> typesList = new List<string>();
            List<double> amountList = new List<double>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string selectQuesry = "SELECT type, SUM(amount) AS TotalAmount FROM Account WHERE type IN ('Asset', 'Liability', 'Equity', 'Revenue', 'Expense', 'Dividends') GROUP BY type;";
                
                using (SqlCommand cmd = new SqlCommand(selectQuesry, conn))
                {
                    
                    //object value = cmd.ExecuteScalar();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read()) {
                        typesList.Add(reader[0].ToString());
                        amountList.Add(Double.Parse(reader[1].ToString()));
                    
                    }
                }

            }





            double[] values = amountList.ToArray();
            string[] types = typesList.ToArray();
            var pie = WpfPlot1.Plot.Add.Pie(values);
            pie.ExplodeFraction = 0.1;
            pie.SliceLabelDistance = 0.5;

            // set different labels for slices and legend
            double total = pie.Slices.Select(x => x.Value).Sum();
            for (int i = 0; i < pie.Slices.Count; i++)
            {
                pie.Slices[i].LabelFontColor = ScottPlot.Colors.White;
                pie.Slices[i].LabelFontSize = 20;
                pie.Slices[i].Label = $"{pie.Slices[i].Value}";
                pie.Slices[i].LegendText = $"{types[i]} " +
                    $"({pie.Slices[i].Value / total:p1})";
            }
            WpfPlot1.Plot.FigureBackground.Color = ScottPlot.Colors.Transparent;
            // hide unnecessary plot components
            WpfPlot1.Plot.Axes.Frameless();
            WpfPlot1.Plot.HideGrid();
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

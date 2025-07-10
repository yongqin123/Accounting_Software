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
using System.Configuration;
using Microsoft.Data.SqlClient;
namespace AccountingSoftware
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private Frame _mainFrame;
        public Login(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            //Add Background Color
            SolidColorBrush color1 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#222D32"));
            login.Background = color1;

            //Admin Panel
            SolidColorBrush color2 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ECF0F5"));
            admin.Foreground = color2;

            //Add Stack Color
            SolidColorBrush color3 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1A2226"));
            stack.Background = color3;

            //Username Label
            SolidColorBrush color4 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6C6C6C"));
            usernameLabel.Foreground = color4;

            //Username Textbox
            SolidColorBrush color5 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ECF0F5"));
            username.Foreground = color5;

            //Username Label
            SolidColorBrush color6 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6C6C6C"));
            pwLabel.Foreground = color4;

            //Username Textbox
            SolidColorBrush color7 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ECF0F5"));
            pasword.Foreground = color5;

        }

      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AccountingDatabase.mdf;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string selectQuesry = "SELECT COUNT(*) FROM Users WHERE username = @username AND password = @password";
                double amount = 0;
                using (SqlCommand cmd = new SqlCommand(selectQuesry, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username.Text);
                    cmd.Parameters.AddWithValue("@password", pasword.Password);

                    //object value = cmd.ExecuteScalar();

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        _mainFrame.Navigate(new Home(_mainFrame));
                    }
                    else {
                        MessageBoxResult mb = MessageBox.Show("Wrong Password", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);

                        
                    }
                }
                
            }
        }
    }
}

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
using AccountingSoftware.View.UserControl;
using Microsoft.Data.SqlClient;
//using Microsoft.Data.SqlClient; // Or System.Data.SqlClient for .NET Framework
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace AccountingSoftware.View
{
    /// <summary>
    /// Interaction logic for JournalEntry.xaml
    /// </summary>
    

    public partial class JournalEntry : Page
    {
        private int debit_counter = 0;
        private int credit_counter = 0;

        private Frame _mainFrame;
        public JournalEntry(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            //Add Stack Color
            SolidColorBrush color1 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#222D32"));
            stackLeft.Background = color1;

            //Admin Panel
            SolidColorBrush color2 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1A2226"));
            stackRight.Background = color2;

            gridd.Background = color2;
        }

        private void addDebit_Click(object sender, RoutedEventArgs e)
        {
            Debit debit = new Debit();
            debit.Name = $"debit{debit_counter}";
            RegisterName($"debit{debit_counter++}", debit);
            Grid.SetRow(debit, 1);
            debitStack.Children.Add(debit);
        }

        private void addCredit_Click(object sender, RoutedEventArgs e)
        {
            Credit credit = new Credit();
            credit.Name = $"credit{credit_counter}";
            RegisterName($"credit{credit_counter++}", credit);
            Grid.SetRow(credit, 1);
            creditStack.Children.Add(credit);
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AccountingDatabase.mdf;Integrated Security=True";
            bool isEmpty = true;
            double debitTotal = 0;
            double creditTotal = 0;
            for (int k = 0; k < debit_counter; k++)
            {
                var control2 = (Debit)this.FindName($"debit{k}");
                if (control2 != null)
                {
                    if (control2.account.Text == "" | control2.amount.Text == "")
                    {
                        isEmpty = false;
                        MessageBoxResult mb = MessageBox.Show("Included NULL values", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                        _mainFrame.Navigate(new JournalEntry(_mainFrame));
                        break;
                    }
                    else
                    {
                        debitTotal += Double.Parse(control2.amount.Text);
                    }

                }
            }   
            for (int j = 0; j < credit_counter; j++)
            {
                var control3 = (Credit)this.FindName($"credit{j}");
                if (control3 != null)
                {
                    if (control3.account.Text == "" | control3.amount.Text == "")
                    {
                        isEmpty = false;
                        MessageBoxResult mb = MessageBox.Show("Included NULL values", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                        _mainFrame.Navigate(new JournalEntry(_mainFrame));
                        break;
                    }
                        else
                        {
                            creditTotal += Double.Parse(control3.amount.Text);
                        }
                    }
                
            }
            if (debitTotal != creditTotal) {
                isEmpty = false;
                MessageBoxResult mb = MessageBox.Show("Debit and Credit is Not Balanced", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                _mainFrame.Navigate(new JournalEntry(_mainFrame));
                
            }

            if (isEmpty)
                {

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        //Debit Stack Journal Entries
                        
                        for (int i = 0; i < debit_counter; i++)
                        {
                            var control = (Debit)this.FindName($"debit{i}");
                            if (control != null)
                            {

                                //Insert into JournalEntries table
                                string insertQuery = "INSERT INTO JournalEntries ( name, nature, amount) VALUES ( @name, @nature, @amount)";
                                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@name", control.account.Text);
                                    cmd.Parameters.AddWithValue("@nature", "debit");
                                    cmd.Parameters.AddWithValue("@amount", control.amount.Text);

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                }

                                //Get the amount of the account
                                string selectQuesry = "SELECT amount FROM Account WHERE name = @name";
                                double amount = 0;
                                using (SqlCommand cmd = new SqlCommand(selectQuesry, conn))
                                {
                                    cmd.Parameters.AddWithValue("@name", control.account.Text);

                                    object value = cmd.ExecuteScalar();

                                    amount = Convert.ToDouble(value);


                                }
                                //Get the nature of account
                                string selectQuery = "SELECT nature FROM Account WHERE name = @name";
                                string nature = "";
                                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@name", control.account.Text);
                                    object value = cmd.ExecuteScalar();
                                    nature = value.ToString();
                                }
                                Debug.WriteLine($"User name: {nature}");
                                //Update the amount of the account
                                string updateQuery = "UPDATE Account SET amount=@amount WHERE name = @account";
                                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                                {
                                    if (nature == "debit")
                                    {
                                        cmd.Parameters.AddWithValue("@amount", double.Parse(control.amount.Text) + amount);
                                        cmd.Parameters.AddWithValue("@account", control.account.Text);

                                        int rowsAffected = cmd.ExecuteNonQuery();
                                    }
                                    if (nature == "credit")
                                    {
                                        cmd.Parameters.AddWithValue("@amount", (double.Parse(control.amount.Text) * -1) + amount);
                                        cmd.Parameters.AddWithValue("@account", control.account.Text);

                                        int rowsAffected = cmd.ExecuteNonQuery();
                                    }


                                }
                            }
                        }

                        //Loop through credit stack 
                        for (int i = 0; i < credit_counter; i++)
                        {
                            var control = (Credit)this.FindName($"credit{i}");

                            if (control != null)
                            {

                                //insert entry
                                string insertQuery = "INSERT INTO JournalEntries ( name, nature, amount) VALUES ( @name, @nature, @amount)";
                                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@name", control.account.Text);
                                    cmd.Parameters.AddWithValue("@nature", "debit");
                                    cmd.Parameters.AddWithValue("@amount", control.amount.Text);

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                }



                                string selectQuesry = "SELECT amount FROM Account WHERE name = @name";
                                double amount = 0;
                                using (SqlCommand cmd = new SqlCommand(selectQuesry, conn))
                                {
                                    cmd.Parameters.AddWithValue("@name", control.account.Text);

                                    object value = cmd.ExecuteScalar();

                                    amount = Convert.ToDouble(value);

                                }

                                string selectQuery = "SELECT nature FROM Account WHERE name = @name";
                                string nature;
                                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@name", control.account.Text);
                                    object value = cmd.ExecuteScalar();

                                    nature = value.ToString();

                                }


                                string updateQuery = "UPDATE Account SET amount=@amount WHERE name = @account";
                                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                                {
                                    if (nature == "credit")
                                    {
                                        cmd.Parameters.AddWithValue("@amount", double.Parse(control.amount.Text) + amount);
                                        cmd.Parameters.AddWithValue("@account", control.account.Text);

                                        int rowsAffected = cmd.ExecuteNonQuery();

                                    }
                                    if (nature == "debit")
                                    {
                                        cmd.Parameters.AddWithValue("@amount", (double.Parse(control.amount.Text) * -1) + amount);
                                        cmd.Parameters.AddWithValue("@account", control.account.Text);

                                        int rowsAffected = cmd.ExecuteNonQuery();
                                    }


                                }
                            }
                        }
                    }
                }
            
            _mainFrame.Navigate(new Home(_mainFrame));
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

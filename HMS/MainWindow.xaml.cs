using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace HMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _decryption;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FadeIn(object sender, EventArgs e)
        {
            var fadeAnimation = new DoubleAnimation {From = 0, Duration = new Duration(TimeSpan.FromSeconds(3))};
            MailTextBox.BeginAnimation(OpacityProperty, fadeAnimation);
            PasswordBox.BeginAnimation(OpacityProperty, fadeAnimation);
            EmailTextBlock.BeginAnimation(OpacityProperty, fadeAnimation);
            PasswordTextBlock.BeginAnimation(OpacityProperty, fadeAnimation);
            logButton.BeginAnimation(OpacityProperty, fadeAnimation);
            RecLoginLabel.BeginAnimation(OpacityProperty, fadeAnimation);
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password.Length == 0)
            {
                PasswordTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordTextBlock.Visibility = Visibility.Collapsed;
            }
        }

        private void LogButton_OnClick(object sender, RoutedEventArgs e)
        {
            string email = MailTextBox.Text;
            string password = PasswordBox.Password;

            using (var conn = new SqlConnection())
            {
                conn.ConnectionString =
                    @"Data Source = R3831-3NVY\SQLEXPRESS; Initial Catalog = hms; Integrated Security = True;";

                var comm = new SqlCommand("SELECT [email], [password] FROM [dbo].[Receptionist] WHERE [email] = @mail;", conn);
                comm.Parameters.AddWithValue("@mail", email);

                try
                {
                    conn.Open();
                    using (var reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} | {reader[1]}");
                            byte[] passBytes = reader[1] as byte[];
                            Console.WriteLine(Encoding.UTF8.GetString(passBytes));
                            _decryption = crypto.Decrypt(Encoding.UTF8.GetString(passBytes), password);
                            Console.WriteLine(password);
                        }
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            if (PasswordBox.Password == "" && MailTextBox.Text == "")
            {
                var message = new CustomMessage("Please enter your email and password!");
                message.Owner = this;
                message.Show();
            }
            else if (MailTextBox.Text == "")
            {
                var message = new CustomMessage("Please enter your email!");
                message.Owner = this;
                message.Show();
            }
            else if (PasswordBox.Password == "")
            {
                var message = new CustomMessage("Please enter your password!");
                message.Owner = this;
                message.Show();
            }
            else if (password.Equals(_decryption))
            {
                Console.WriteLine("Valid User!");
                var addReceptionist = new AddReceptionist();
                addReceptionist.Show();
                Close();
            }
            else
            {
                var message = new CustomMessage("Invalid email or password!");
                message.Owner = this;
                message.Show();
            }
        }
    }
}
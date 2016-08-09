using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;

namespace HMS
{
    /// <summary>
    /// Interaction logic for AddReceptionist.xaml
    /// </summary>
    public partial class AddReceptionist : Window
    {
        public AddReceptionist()
        {
            InitializeComponent();
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        private void FadeIn(object sender, EventArgs e)
        {
            var fadeAnimation = new DoubleAnimation { From = 0, Duration = new Duration(TimeSpan.FromSeconds(2.5)) };
            label.BeginAnimation(OpacityProperty, fadeAnimation);
            label1.BeginAnimation(OpacityProperty, fadeAnimation);
            label1_Copy.BeginAnimation(OpacityProperty, fadeAnimation);
            label1_Copy1.BeginAnimation(OpacityProperty, fadeAnimation);
            label1_Copy2.BeginAnimation(OpacityProperty, fadeAnimation);
            label1_Copy3.BeginAnimation(OpacityProperty, fadeAnimation);
            label1_Copy4.BeginAnimation(OpacityProperty, fadeAnimation);
            label1_Copy5.BeginAnimation(OpacityProperty, fadeAnimation);
            label1_Copy6.BeginAnimation(OpacityProperty, fadeAnimation);
            label1_Copy7.BeginAnimation(OpacityProperty, fadeAnimation);
            GenderCombo.BeginAnimation(OpacityProperty, fadeAnimation);
            Emailtxt.BeginAnimation(OpacityProperty, fadeAnimation);
            SignUpBtn.BeginAnimation(OpacityProperty, fadeAnimation);
            addresstxt.BeginAnimation(OpacityProperty, fadeAnimation);
            fNametxt.BeginAnimation(OpacityProperty, fadeAnimation);
            lNametxt.BeginAnimation(OpacityProperty, fadeAnimation);
            pwordtxt.BeginAnimation(OpacityProperty, fadeAnimation);
            pwordtxt2.BeginAnimation(OpacityProperty, fadeAnimation);
            phonetxt.BeginAnimation(OpacityProperty, fadeAnimation);
            nictxt.BeginAnimation(OpacityProperty, fadeAnimation);
        }

        private void SignUpBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (fNametxt.Text == "" || lNametxt.Text == "" || nictxt.Text == "" || pwordtxt.Password == "" ||
                pwordtxt2.Password == "" || Emailtxt.Text == "")
            {
                var message = new CustomMessage("Please fill in all required fields!");
                message.Owner = this;
                message.Show();
                return;
            }

            if (!pwordtxt.Password.Equals(pwordtxt2.Password))
            {
                var message = new CustomMessage("Passwords do not match!");
                message.Owner = this;
                message.Show();
                return;
            }

            if (nictxt.Text.Length < 10)
            {
                var message = new CustomMessage("NIC has to be a 10 characters long!");
                message.Owner = this;
                message.Show();
                return;
            }

            if (phonetxt.Text.Length < 10 || !IsDigitsOnly(phonetxt.Text))
            {
                var message = new CustomMessage("Phone number has to be at least 10 digits long!");
                message.Owner = this;
                message.Show();
                return;
            }

            var fName = fNametxt.Text;
            var lName = lNametxt.Text;
            var email = Emailtxt.Text;
            var address = addresstxt.Text;
            string gender;
            var nic = nictxt.Text;
            var phone = phonetxt.Text;
            var pword = HMS.crypto.Encrypt(pwordtxt2.Password, pwordtxt.Password);

            if (GenderCombo.Text == "Male")
                gender = "m";
            else
                gender = "f";
            Console.WriteLine(gender);

            Console.WriteLine(pword);

            string crypto = HMS.crypto.Decrypt(pword, pwordtxt.Password);
            Console.WriteLine(crypto);

            using (var conn = new SqlConnection())
            {
                conn.ConnectionString =
                    @"Data Source = R3831-3NVY\SQLEXPRESS; Initial Catalog = hms; Integrated Security = True;";

                var comm = new SqlCommand("INSERT INTO [dbo].[Receptionist]([fName], [lName], [nic], [gender], [email], [phone], [address], [password]) VALUES(@fname, @lname, @nic, @gender, @email, @phone, @address, @password);", conn);

                comm.Parameters.AddWithValue("@fname", fName);
                comm.Parameters.AddWithValue("@lname", lName);
                comm.Parameters.AddWithValue("@email", email);
                comm.Parameters.AddWithValue("@address", address);
                comm.Parameters.AddWithValue("@gender", gender);
                comm.Parameters.AddWithValue("@nic", nic);
                comm.Parameters.AddWithValue("@phone", phone);
                comm.Parameters.Add("@password", SqlDbType.VarBinary);
                comm.Parameters["@password"].Value = Encoding.UTF8.GetBytes(pword);

                try
                {
                    conn.Open();
                    var rowsAffected = comm.ExecuteNonQuery();
                    Console.WriteLine(@"Rows Affected: {0}", rowsAffected);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
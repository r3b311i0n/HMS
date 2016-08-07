using System;
using System.Data.SqlClient;
using System.IO;
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
            Emailtxt.BeginAnimation(OpacityProperty,fadeAnimation);
            SignUpBtn.BeginAnimation(OpacityProperty,fadeAnimation);
            addresstxt.BeginAnimation(OpacityProperty,fadeAnimation);
            fNametxt.BeginAnimation(OpacityProperty,fadeAnimation);
            lNametxt.BeginAnimation(OpacityProperty,fadeAnimation);
            pwordtxt.BeginAnimation(OpacityProperty,fadeAnimation);
            pwordtxt2.BeginAnimation(OpacityProperty, fadeAnimation);
            phonetxt.BeginAnimation(OpacityProperty, fadeAnimation);
            nictxt.BeginAnimation(OpacityProperty, fadeAnimation);
        }

        private void SignUpBtn_OnClick(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                    @"Data Source = R3831-3NVY\SQLEXPRESS; Initial Catalog = hms; Integrated Security = True;";
                conn.Open();

                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Receptionist", conn);

                try
                {



                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        Console.WriteLine("FirstColumn\tSecond Column\t\tThird Column\t\tForth Column\t");
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} \t | {reader[1]} \t | {reader[2]} \t | {reader[3]}");
                        }
                    }
                    Console.WriteLine("Data displayed! Now press enter to move to the next section!");
                    Console.ReadLine();
                    Console.Clear();
                }
                catch (IOException exception)
                {
                }

            }
        }
    }
}
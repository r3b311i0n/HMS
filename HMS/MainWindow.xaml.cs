using System;
using System.CodeDom;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FadeIn(object sender, EventArgs e)
        {
            var fadeAnimation = new DoubleAnimation { From = 0, Duration = new Duration(TimeSpan.FromSeconds(3)) };
            MailTextBox.BeginAnimation(OpacityProperty, fadeAnimation);
            PasswordBox.BeginAnimation(OpacityProperty, fadeAnimation);
            UnameTextBlock.BeginAnimation(OpacityProperty, fadeAnimation);
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
            var addReceptionist = new AddReceptionist();
            addReceptionist.Show();
            Close();
        }
    }
}
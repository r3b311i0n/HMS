using System;
using System.ComponentModel;
using System.Timers;
using System.Windows;
using System.Windows.Media.Animation;

namespace HMS
{
    /// <summary>
    /// Interaction logic for CustomMessage.xaml
    /// </summary>
    public partial class CustomMessage : Window
    {
        public CustomMessage(string message)
        {
            InitializeComponent();
            MessageLabel.Content = message;
        }

        private void Confirm_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FadeIn(object sender, EventArgs e)
        {
            var fadeAnimation = new DoubleAnimation { From = 0, Duration = new Duration(TimeSpan.FromSeconds(1)) };
            Confirm.BeginAnimation(OpacityProperty, fadeAnimation);
            MessageLabel.BeginAnimation(OpacityProperty, fadeAnimation);
        }
    }
}
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Telerik.Windows;
using Telerik.Windows.Controls;

namespace HMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RadWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowInTaskbar(this, "Reception Login");
            //            this.Icon = new Image()
            //            {
            //                Source = new BitmapImage(new Uri("pack://application:,,,/hms.png"))
            //            };
        }

        private void FadeIn(object sender, EventArgs e)
        {
            var fadeAnimation = new DoubleAnimation { From = 0, Duration = new Duration(TimeSpan.FromSeconds(3)) };
            //            var unravelAnimation = new DoubleAnimation {From = 0, Duration = new Duration(TimeSpan.FromSeconds(2.5))};
            //            EmailLabel.BeginAnimation(WidthProperty, unravelAnimation);
            //            PwordLabel.BeginAnimation(WidthProperty, unravelAnimation);
            MailTextBox.BeginAnimation(OpacityProperty, fadeAnimation);
            PasswordBox.BeginAnimation(OpacityProperty, fadeAnimation);
            UnameTextBlock.BeginAnimation(OpacityProperty, fadeAnimation);
            PasswordTextBlock.BeginAnimation(OpacityProperty, fadeAnimation);
            logButton.BeginAnimation(OpacityProperty, fadeAnimation);
        }

        public static void ShowInTaskbar(RadWindow control, string title)
        {
            control.Show();
            var window = control.ParentOfType<Window>();
            window.ShowInTaskbar = true;
            window.Title = title;
            var uri = new Uri("pack://application:,,,/hms.png");
            window.Icon = BitmapFrame.Create(uri);
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

        private void LogButton_OnActivate(object sender, RadRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
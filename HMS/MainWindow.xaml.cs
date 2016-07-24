using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;
using Telerik.Windows.Controls.TransitionControl;

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
            var fadeAnimation = new DoubleAnimation {From = 0, Duration = new Duration(TimeSpan.FromSeconds(2.5))};
            var unravelAnimation = new DoubleAnimation {From = 0, Duration = new Duration(TimeSpan.FromSeconds(2.5))};
            EmailLabel.BeginAnimation(WidthProperty, unravelAnimation);
            PwordLabel.BeginAnimation(WidthProperty, unravelAnimation);
            EmailLabel.BeginAnimation(OpacityProperty, fadeAnimation);
            PwordLabel.BeginAnimation(OpacityProperty, fadeAnimation);
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
    }

}

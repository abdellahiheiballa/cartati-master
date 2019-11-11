using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

namespace Cartati
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        rfidManipulation manipulation = new rfidManipulation();

        public MainWindow()
        {
            InitializeComponent();
            logoPanel.Height = 530;
            FormPanel.Visibility = Visibility.Hidden;
            ThicknessAnimation myThicknessAnimation = new ThicknessAnimation();
            myThicknessAnimation.Duration = TimeSpan.FromSeconds(1.0);
            myThicknessAnimation.FillBehavior = FillBehavior.HoldEnd;
            myThicknessAnimation.From = new Thickness(102, 172, 0, 0);
            myThicknessAnimation.To = new Thickness(102, 10, 0, 0);
            LogoImage.BeginAnimation(Image.MarginProperty, myThicknessAnimation);
            FormPanel.Visibility = Visibility.Visible;


        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            manipulation.selectTag1();
            manipulation.auth_methode2();
            manipulation.auth_methode1();
            if (String.IsNullOrEmpty(Username.Text) || String.IsNullOrEmpty(Password.Password)) {
                UsernameEmpty.Visibility = Visibility.Visible;
                PasswordEmpty.Visibility = Visibility.Visible;
            }else
            {
                try
                {
                if (Username.Text.CompareTo(manipulation.read_bloc1()) == 0
                                                && Password.Password.CompareTo(manipulation.read_bloc2()) == 0)
                                            {

                                                Home home = new Home();
                                                home.Show();
                                                this.Hide();
                                            }
                                            else
                                            {
                                    
                                                 IncorrectPasswordText.Visibility = Visibility.Visible;
                                            }
                }
                catch (System.IO.IOException) {
                    InsertTagText.Visibility = Visibility.Visible;
                }
                
            }


        }
        
    }
}

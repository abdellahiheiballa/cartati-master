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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cartati
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        ColorAnimation myColorAnimation = new ColorAnimation();
        rfidManipulation manipulation = new rfidManipulation();

        public Home()
        {
            InitializeComponent();
            this.Width = 1261;
            manipulation.selectTag1();
            manipulation.auth_methode3();
            soldeTextBox.Text = "Your solde is " + manipulation.read_value();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            myColorAnimation.Duration = TimeSpan.FromSeconds(0.5);
            ThicknessAnimation myThicknessAnimation = new ThicknessAnimation();
            myThicknessAnimation.Duration = TimeSpan.FromSeconds(0.5);
            myThicknessAnimation.FillBehavior = FillBehavior.HoldEnd;
            myThicknessAnimation.From = new Thickness(371, 236, 0, 0);
            myThicknessAnimation.To = new Thickness(371, 236, 0, 0);
            passwordPanel.BeginAnimation(Grid.MarginProperty, myThicknessAnimation);
            soldeRect.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Gainsboro"));
            soldeRect.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
            passwordRect.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF673AB7"));
            passwordRect.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
            passwordPanel.Visibility = Visibility.Visible;


        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            myColorAnimation.Duration = TimeSpan.FromSeconds(0.5);
            ThicknessAnimation myThicknessAnimation = new ThicknessAnimation();
            myThicknessAnimation.Duration = TimeSpan.FromSeconds(0.5);
            myThicknessAnimation.FillBehavior = FillBehavior.HoldEnd;
            myThicknessAnimation.From = new Thickness(371, 236, 0, 0);
            myThicknessAnimation.To = new Thickness(371, 236, 0, 0);
            passwordPanel.BeginAnimation(Grid.MarginProperty, myThicknessAnimation);
            soldeRect.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF673AB7"));
            soldeRect.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
            passwordRect.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Gainsboro"));
            passwordRect.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
            passwordPanel.Visibility = Visibility.Hidden;
        }

        private void SoldeRect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            myColorAnimation.Duration = TimeSpan.FromSeconds(0.5);
            ThicknessAnimation myThicknessAnimation = new ThicknessAnimation();
            myThicknessAnimation.Duration = TimeSpan.FromSeconds(0.5);
            myThicknessAnimation.FillBehavior = FillBehavior.HoldEnd;
            myThicknessAnimation.From = new Thickness(371, 236, 0, 0);
            myThicknessAnimation.To = new Thickness(371, 236, 0, 0);
            passwordPanel.BeginAnimation(Grid.MarginProperty, myThicknessAnimation);
            soldeRect.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF673AB7"));
            soldeRect.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
            passwordRect.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Gainsboro"));
            passwordRect.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
            passwordPanel.Visibility = Visibility.Hidden;
        }

        private void PasswordRect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            myColorAnimation.Duration = TimeSpan.FromSeconds(0.5);
            ThicknessAnimation myThicknessAnimation = new ThicknessAnimation();
            myThicknessAnimation.Duration = TimeSpan.FromSeconds(0.5);
            myThicknessAnimation.FillBehavior = FillBehavior.HoldEnd;
            myThicknessAnimation.From = new Thickness(371, 236, 0, 0);
            myThicknessAnimation.To = new Thickness(371, 236, 0, 0);
            passwordPanel.BeginAnimation(Grid.MarginProperty, myThicknessAnimation);
            soldeRect.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Gainsboro"));
            soldeRect.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
            passwordRect.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF673AB7"));
            passwordRect.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
            passwordPanel.Visibility = Visibility.Visible;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            #region NewSoldeTraitement
                int newSoldeParsedValue;
                if (!String.IsNullOrEmpty(newSoldeTextBox.Text)) {
                 if (int.TryParse(newSoldeTextBox.Text, out newSoldeParsedValue))
                        {
                            manipulation.selectTag1();
                            manipulation.auth_methode3();
                            manipulation.inc(newSoldeTextBox.Text);
                            soldeTextBox.Text = "Your solde is " + manipulation.read_value();
                            ErrorTextBlock.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            ErrorTextBlock.Visibility = Visibility.Visible;
                        }
                newSoldeTextBox.Text = "";
                }
               
            #endregion

            #region CreditTraitement
                int creditParsedvalue;
                if (!String.IsNullOrEmpty(creditTextBox.Text)) {
                    if (int.TryParse(creditTextBox.Text, out creditParsedvalue))
                        {
                            manipulation.selectTag1();
                            manipulation.auth_methode3();
                            manipulation.dec(creditTextBox.Text);
                            soldeTextBox.Text = "Your solde is " + manipulation.read_value();
                            ErrorTextBlock.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            ErrorTextBlock.Visibility = Visibility.Visible;
                        }
                     creditTextBox.Text = "";
                }          
            #endregion

            #region debitTraitement
                int debitParsedValue;
                if (!String.IsNullOrEmpty(debitTextBox.Text))
                {
                    if (int.TryParse(debitTextBox.Text, out debitParsedValue))
                        {
                            manipulation.selectTag1();
                            manipulation.auth_methode3();
                            int debit = Int32.Parse(debitTextBox.Text);
                            int solde = Int32.Parse(manipulation.read_value());
                            if (debit != 0)
                            {
                            
                                float final = solde + debit;
                                manipulation.write_value(final.ToString());
                                soldeTextBox.Text = "Your solde is " + manipulation.read_value();
                                DevisionError.Visibility = Visibility.Hidden;
                                ErrorTextBlock.Visibility = Visibility.Hidden;
                    }
                            else
                            {
                                DevisionError.Visibility = Visibility.Visible;
                            }
                                
                        }
                        else
                        {
                                  ErrorTextBlock.Visibility = Visibility.Visible;
                                  
                        }
                debitTextBox.Text = "";
                }
                
            #endregion

        }

        private void ValidePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                manipulation.selectTag1();
                manipulation.auth_methode1();
                if (String.IsNullOrEmpty(oldPasswordBox.Password) || String.IsNullOrEmpty(newPasswordBox.Password) || String.IsNullOrEmpty(repeatPasswordBox.Password))
                {
                    changingPasswordErrorTextBlock.Text = "All fields are required";
                    changingPasswordErrorTextBlock.Visibility = Visibility.Visible;
                }
                else if (oldPasswordBox.Password.CompareTo(manipulation.read_bloc2()) == 0 && newPasswordBox.Password.CompareTo(repeatPasswordBox.Password) == 0)
                {
                    manipulation.write_bloc2(newPasswordBox.Password);
                    SuccessfulyTextBlock.Visibility = Visibility.Visible;
                }
                else {
                    changingPasswordErrorTextBlock.Text = "Failed";
                    changingPasswordErrorTextBlock.Visibility = Visibility.Visible;

                }
                  
            }
            catch (System.IO.IOException)
            {
                changingPasswordErrorTextBlock.Text = "Insert Tag";
                changingPasswordErrorTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            newSoldeTextBox.Text = "";
            creditTextBox.Text = "";
            debitTextBox.Text = "";

        }

        private void AboutUsButton_Click(object sender, RoutedEventArgs e)
        {
            aboutUs aboutus = new aboutUs();
            aboutus.Show();
        }
    }
}

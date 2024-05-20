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
using System.Windows.Shapes;

namespace Kursach_Luzin_Patrakov_321
{
    /// <summary>
    /// Interaction logic for AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Window
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        //Текст Имени и фамилии
        private new void GotFocus(TextBox textBox, string placeholderText, string replacementText)
        {
            if (textBox != null && textBox.Text == placeholderText)
            {
                textBox.Text = replacementText;
               // textBox.Foreground = Brushes.Black;
            }
        }

        private new void LostFocus(TextBox textBox, string replacementText, string placeholderText)
        {
            if (textBox != null && textBox.Text == placeholderText)
            {
                textBox.Text = replacementText;
               // textBox.Foreground = Brushes.Gray;
            }
        }

        //Пропадющий текст

        private void SecondtextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            GotFocus(textBox, "Введите логин", "");
        }
        private void SecondtextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            LostFocus(textBox, "Введите логин", "");
        }

        private void thirdtextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PassBox.Password != "" && PassBox.Password == "fvfvfvffvfvfvfvfvfvfvfvfvfvfvfvvfvvf")
            {
                PassBox.Password = "";
                // textBox.Foreground = Brushes.Black;
            }
        }
        private void thirdtextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PassBox.Password != "" && PassBox.Password == "fvfvfvffvfvfvfvfvfvfvfvfvfvfvfvvfvvf")
            {
                PassBox.Password = "fvfvfvffvfvfvfvfvfvfvfvfvfvfvfvvfvvf";
                // textBox.Foreground = Brushes.Black;
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            RegPage reg = new RegPage();
            //FrameManager.MainFrame.Navigate(reg);
            MainFrame.Content = reg;

            MainFrame.Visibility = Visibility.Visible;
            
        }

        public bool isAdmin(string UserLogin, string UserPassword)
        {
            Kursach_Luzin_Patrakov_321Entities db = new Kursach_Luzin_Patrakov_321Entities();

            // Проверяем, существует ли пользователь с таким логином и паролем
            Users user = db.Users.AsNoTracking().FirstOrDefault(u => u.Login == UserLogin && u.Password == UserPassword);

            return user != null && user.Role == "Admin";
        }

        public bool isVendor(string UserLogin, string UserPassword)
        {
            Kursach_Luzin_Patrakov_321Entities db = new Kursach_Luzin_Patrakov_321Entities();

            // Проверяем, существует ли пользователь с таким логином и паролем
            Users user = db.Users.AsNoTracking().FirstOrDefault(u => u.Login == UserLogin && u.Password == UserPassword);

            return user != null && user.Role == "Vendor";
        }



        public bool Auth(string UserLogin, string UserPassword)
        {
            Kursach_Luzin_Patrakov_321Entities db = new Kursach_Luzin_Patrakov_321Entities();

            Users userObject = new Users()
            {
                Login = UserLogin,
                Password = UserPassword,
            };

            Users users = db.Users.AsNoTracking().FirstOrDefault(u => u.Login == UserLogin && u.Password == UserPassword);
            if (users != null)
            {
                MessageBox.Show("Авторизация прошла успешно");
                AuthPage page = new AuthPage();
                this.Close();

                App.Current.Resources["FstResourse"] = LoginTextBox.Text;
                App.Current.Resources["SndResourse"] = PassBox.Password;
                App.Current.Resources["UserID"] = users.UserID;


                if (isAdmin(UserLogin, UserPassword))
                {
                    App.Current.Resources["isAdmin"] = "true";
                }
                if (isVendor(UserLogin, UserPassword))
                {
                    App.Current.Resources["isVendor"] = "true";
                    if ((string)App.Current.Resources["FstResourse"] == "Vendor_1")
                    {
                        App.Current.Resources["Vendorid"] = 1;
                    }
                    if ((string)App.Current.Resources["FstResourse"] == "Vendor_2")
                    {
                        App.Current.Resources["Vendorid"] = 2;
                    }
                    if ((string)App.Current.Resources["FstResourse"] == "Vendor_3")
                    {
                        App.Current.Resources["Vendorid"] = 3;
                    }
                }
            }
            else
            {
                MessageBox.Show("Данный пользователь отсутствует");
            }

            return true;
        }
        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            Auth(LoginTextBox.Text, PassBox.Password);
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursach_Luzin_Patrakov_321
{
    /// <summary>
    /// Interaction logic for RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent(); 
        }

        private void GotFocus(TextBox textBox, string placeholderText, string replacementText)
        {
            if (textBox != null && textBox.Text == placeholderText)
            {
                textBox.Text = replacementText;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void LostFocus(TextBox textBox, string placeholderText, string replacementText)
        {
            if (textBox != null && textBox.Text == placeholderText)
            {
                textBox.Text = replacementText;
                textBox.Foreground = Brushes.Gray;
            }
        }

        //Логин

        private void LoginTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            GotFocus(textBox, "Введите логин...", "");
        }

        private void LoginTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            LostFocus(textBox, "", "Введите логин...");
        }

        //Имя

        private void FirstTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            GotFocus(textBox, "Введите имя...", "");
        }

        private void FirstTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            LostFocus(textBox, "", "Введите имя...");
        }

        //Фамилия

        private void SecondTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            GotFocus(textBox, "Введите фамилию...", "");
        }

        private void SecondTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            LostFocus(textBox, "", "Введите фамилию...");
        }

        //конец пропадающего текста

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (Registration(TextBoxUsername.Text, PasswordBox.Password, TextBoxFirstName.Text, TextBoxLastName.Text, ComboBoxGender.Text, "User"))
            {
                MessageBox.Show("Регистрация прошла успешно");
                this.NavigationService.RemoveBackEntry();

            }
        }

        public bool Registration(string UserLogin, string UserPassword, string UserFName, string UserLName, string UserGender, string UserRole)
        {
            if (string.IsNullOrEmpty(UserLogin) || UserLogin == "Введите логин...")
            {
                MessageBox.Show("Введите логин");
                return false;
            }
            else if (string.IsNullOrEmpty(UserPassword))
            {
                MessageBox.Show("Введите пароль");
                return false;
            }
            else if (PasswordBox.Password == null)
            {
                MessageBox.Show("Введите пароль");
                return false;
            }
            else if (string.IsNullOrEmpty(UserFName) || UserFName == "Введите имя...")
            {
                MessageBox.Show("Введите имя");
                return false;
            }
            else if (string.IsNullOrEmpty(UserLName) || UserLName == "Введите фамилю...")
            {
                MessageBox.Show("Введите фамилию");
                return false;
            }
            else if (string.IsNullOrEmpty(UserGender))
            {
                MessageBox.Show("Выберите пол");
                return false;
            }

            Kursach_Luzin_Patrakov_321Entities db = new Kursach_Luzin_Patrakov_321Entities();

            Users userObject = new Users()
            {
                Login = UserLogin,
                Password = UserPassword,
                LastName = UserLName,
                FirstName = UserFName,
                Gender = UserGender,
                Role = "User",
            };

            Users users = db.Users.AsNoTracking().FirstOrDefault(u => u.Login == UserLogin);
            if (users != null)
            {
                MessageBox.Show("Данный пользователь уже существует");
                TextBoxUsername.Clear();
                
                return false;
            }

            db.Users.Add(userObject);
            db.SaveChanges();
            
            AuthPage authPage = new AuthPage();
            authPage.close();
            return true;
        }
    }
}

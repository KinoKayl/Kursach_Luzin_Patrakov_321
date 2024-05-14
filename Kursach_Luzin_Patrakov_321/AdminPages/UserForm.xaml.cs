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

namespace Kursach_Luzin_Patrakov_321.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для UserForm.xaml
    /// </summary>
    public partial class UserForm : Window
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string Gender { get; private set; }
        public string Role { get; private set; }

        public UserForm()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            // Сохранение данных из полей ввода в свойства
            Login = LoginTextBox.Text;
            Password = PasswordTextBox.Password; // Используйте PasswordBox для пароля
            LastName = LastNameTextBox.Text;
            FirstName = FirstNameTextBox.Text;
            Gender = GenderComboBox.Text; // Предполагается, что это ComboBox с выбором пола
            Role = RoleComboBox.Text; // Предполагается, что это ComboBox с выбором роли

            // Закрытие диалогового окна с результатом DialogResult.OK
            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Закрытие диалогового окна с результатом DialogResult.Cancel
            this.DialogResult = false;
            this.Close();
        }
    }
}

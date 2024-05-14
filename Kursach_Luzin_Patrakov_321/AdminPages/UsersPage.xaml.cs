using System;
using System.Collections.Generic;
using System.Data;
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

namespace Kursach_Luzin_Patrakov_321.AdminPages
{
    /// <summary>
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        Kursach_Luzin_Patrakov_321Entities1 db = new Kursach_Luzin_Patrakov_321Entities1();
        public UsersPage()
        {
            InitializeComponent();
            AddButton.Click += AddButton_Click;
            DeleteButton.Click += DeleteButton_Click;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Отображение формы для ввода данных нового пользователя
            var userForm = new UserForm(); // Предполагается, что у вас есть окно или форма для ввода данных пользователя
            userForm.ShowDialog();

            if (userForm.DialogResult.HasValue && userForm.DialogResult.Value)
            {
                // Создание нового пользователя с данными из формы
                var newUser = new Users
                {
                    Login = userForm.Login,
                    Password = userForm.Password, // В реальном приложении пароль должен быть захеширован
                    LastName = userForm.LastName,
                    FirstName = userForm.FirstName,
                    Gender = userForm.Gender,
                    Role = userForm.Role
                };

                // Добавление нового пользователя в базу данных
                db.Users.Add(newUser);
                try
                {
                    db.SaveChanges();
                    RefreshDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении пользователя: " + ex.Message);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem != null)
            {
                var userToDelete = (UserViewModel)UsersDataGrid.SelectedItem;
                var user = db.Users.Find(userToDelete.UserID);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    RefreshDataGrid();
                }
            }
        }

        public class UserViewModel
        {
            public int UserID { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Gender { get; set; }
            public string Role { get; set; }

        }

        private void RefreshDataGrid()
        {
            var query = from user in db.Users
                        select new UserViewModel
                        {
                            UserID = user.UserID,
                            Login = user.Login,
                            Password = user.Password,
                            LastName = user.LastName,
                            FirstName = user.FirstName,
                            Gender = user.Gender,
                            Role = user.Role,

                        };
            UsersDataGrid.ItemsSource = query.ToList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {    
            db.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Kursach_Luzin_Patrakov_321.AdminPages
{
    public partial class UsersPage : Page
    {
        Kursach_Luzin_Patrakov_321Entities db = new Kursach_Luzin_Patrakov_321Entities();

        public UsersPage()
        {
            InitializeComponent();
            AddButton.Click += AddButton_Click;
            DeleteButton.Click += DeleteButton_Click;
            SaveButton.Click += SaveButton_Click;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var userForm = new UserForm();
            userForm.ShowDialog();

            if (userForm.DialogResult.HasValue && userForm.DialogResult.Value)
            {
                var newUser = new Users
                {
                    Login = userForm.Login,
                    Password = userForm.Password,
                    LastName = userForm.LastName,
                    FirstName = userForm.FirstName,
                    Gender = userForm.Gender,
                    Role = userForm.Role
                };

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
                            Role = user.Role
                        };
            UsersDataGrid.ItemsSource = query.ToList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in UsersDataGrid.ItemsSource)
            {
                var userViewModel = item as UserViewModel;
                if (userViewModel != null)
                {
                    var user = db.Users.Find(userViewModel.UserID);
                    if (user != null)
                    {
                        user.Login = userViewModel.Login;
                        user.Password = userViewModel.Password;
                        user.LastName = userViewModel.LastName;
                        user.FirstName = userViewModel.FirstName;
                        user.Gender = userViewModel.Gender;
                        user.Role = userViewModel.Role;
                    }
                }
            }

            try
            {
                db.SaveChanges();
                MessageBox.Show("Изменения сохранены успешно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message);
            }
        }
    }
}


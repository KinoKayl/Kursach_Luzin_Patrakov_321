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
        public UsersPage()
        {
            InitializeComponent();
            foreach (DataGridColumn column in UsersDataGrid.Columns)
            {
                column.Width = new DataGridLength(100);
            }

            // Создание источника данных для DataGrid
            DataTable dt = new DataTable();
            dt.Columns.Add("UserID", typeof(int));
            dt.Columns.Add("Login", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("Gender", typeof(string));
            dt.Columns.Add("Role", typeof(string));

            //Заполняем лист
            List<Users_ADMIN> users = new List<Users_ADMIN>
            {
             new Users_ADMIN(1, "Maxutka", "qwerty123", "Максбетов", "Макс", "Мужской", "Admin"),
             new Users_ADMIN(2, "ZXC_1v1MID_Ghoul", "qazwsxedc", "Лузин", "Теодор", "Женский", "User"),
             new Users_ADMIN(3, "HoI_4k_hours", "qaz123zaq", "Патраков", "Данила", "Женский", "User"),
             new Users_ADMIN(4, "PeckleRick", "qwert1234567", "Сафонов", "Илья", "Мужской", "User"),
             new Users_ADMIN(5, "Dempsi", "ytrewq98765", "Загитова", "Ульяна", "Женский", "User"),
             new Users_ADMIN(6, "Crokoroko", "crokoroko078","Афонасьевич", "Кирил",  "Мужской", "User"),
             new Users_ADMIN(7, "AkiChan", "aki_080808_chan", "Православная", "Катя", "Женский", "Admin"),
        };


            // Заполнение источника данных
            foreach (var item in users)
            {
                dt.Rows.Add(item.UserID, item.Login, item.Password, item.FirstName, item.LastName, item.Gender, item.Role);
            }

            // Привязка источника данных к DataGrid
            UsersDataGrid.ItemsSource = dt.DefaultView;
        }
    }
}

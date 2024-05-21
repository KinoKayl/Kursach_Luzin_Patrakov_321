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
using System.Diagnostics;

namespace Kursach_Luzin_Patrakov_321
{
    /// <summary>
    /// Логика взаимодействия для AboutUsWindow.xaml
    /// </summary>
    public partial class AboutUsWindow : Window
    {
        Kursach_Luzin_Patrakov_321Entities db = new Kursach_Luzin_Patrakov_321Entities();
        public AboutUsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
                var query = from review in db.Reviews
                            join user in db.Users on review.UserID equals user.UserID
                            join location in db.Locations on review.LocationID equals location.LocationID                          
                            select new
                            {
                                review.ReviewID,
                                User = user.Login, 
                                Location = location.Name,
                                review.Review,
                                review.Rating
                            };
                ReviewsDataGrid.ItemsSource = query.ToList();

            
        }

        private void UrlButton1_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://vk.com/lo4d1ng"; // Замените на нужный вам URL
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void UrlButton2_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://web.telegram.org/k/#@Just_Danya_xD"; // Замените на нужный вам URL
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}

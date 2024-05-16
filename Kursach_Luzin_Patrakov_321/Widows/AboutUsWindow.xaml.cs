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
            var query = from Reviews in db.Reviews select new { Reviews.ReviewID, Reviews.UserID, Reviews.LocationID, Reviews.Review, Reviews.Rating };
            ReviewsDataGrid.ItemsSource = query.ToList();
        }
    }
}

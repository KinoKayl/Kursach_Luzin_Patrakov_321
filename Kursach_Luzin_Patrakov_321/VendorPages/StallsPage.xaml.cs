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

namespace Kursach_Luzin_Patrakov_321.VendorPages
{
    /// <summary>
    /// Логика взаимодействия для StallsPage.xaml
    /// </summary>
    public partial class StallsPage : Page
    {
        Kursach_Luzin_Patrakov_321Entities db = new Kursach_Luzin_Patrakov_321Entities();
        public StallsPage()
        {
            InitializeComponent();
        }


        public class StallsViewModel
        {
            public int StallID { get; set; }
            public Nullable<int> LocationID { get; set; }
            public Nullable<int> VendorID { get; set; }
            public string StallName { get; set; }
            public string Description { get; set; }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from Stalls in db.Stalls
                        select new StallsViewModel
                        {
                            StallID = Stalls.StallID,
                            LocationID = Stalls.LocationID,
                            VendorID = Stalls.VendorID,
                            StallName = Stalls.StallName,
                            Description = Stalls.Description
                        };
            StallsPageDataGrid.ItemsSource = query.ToList();
        }
    }
}

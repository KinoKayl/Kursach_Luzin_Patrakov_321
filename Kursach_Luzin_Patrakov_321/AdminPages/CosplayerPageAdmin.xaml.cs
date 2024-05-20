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

namespace Kursach_Luzin_Patrakov_321.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для CosplayerPageAdmin.xaml
    /// </summary>
    public partial class CosplayerPageAdmin : Page
    {
        Kursach_Luzin_Patrakov_321Entities db = new Kursach_Luzin_Patrakov_321Entities();
        public CosplayerPageAdmin()
        {
            InitializeComponent();
        }

        public class CosplayersViewModel
        {
            public int CosplayerID { get; set; }
            public Nullable<int> UserID { get; set; }
            public Nullable<int> LocationID { get; set; }
            public string Costume { get; set; }
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from Cosplayers in db.Cosplayers
                        select new CosplayersViewModel
                        {
                            CosplayerID = Cosplayers.CosplayerID,
                            UserID = Cosplayers.UserID,
                            LocationID = Cosplayers.LocationID,
                            Costume = Cosplayers.Costume
                        };
            CosplayersDataGrid.ItemsSource = query.ToList();
        }
    }
}

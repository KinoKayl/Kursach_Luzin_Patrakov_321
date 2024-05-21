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

namespace Kursach_Luzin_Patrakov_321.Widows
{
    /// <summary>
    /// Логика взаимодействия для TicketWindow.xaml
    /// </summary>
    public partial class TicketWindow : Window
    {
        Kursach_Luzin_Patrakov_321Entities db = new Kursach_Luzin_Patrakov_321Entities();
        public TicketWindow()
        {
            InitializeComponent();
        }

        public class TicketViewModel
        {
            public int TicketID { get; set; }
            public Nullable<int> LocationID { get; set; }
            public string TicketType { get; set; }
            public Nullable<decimal> Price { get; set; }
            public string PurchaseDate { get; set; }
            public Nullable<int> UserID { get; set; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int userID = (int)App.Current.Resources["UserID"];
            var ticketData = from ticket in db.Tickets
                             where ticket.UserID == userID
                             select new TicketViewModel
                             {
                                 TicketID = ticket.TicketID,
                                 LocationID = ticket.LocationID,
                                 TicketType = ticket.TicketType,
                                 Price = ticket.Price,
                                 PurchaseDate = ticket.PurchaseDate.ToString(),
                                 UserID = ticket.UserID
                             };

            TicketDataGrid.ItemsSource = ticketData.ToList();

        }
    }
}

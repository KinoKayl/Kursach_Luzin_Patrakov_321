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
    /// Логика взаимодействия для PurchasedItemsPage.xaml
    /// </summary>
    public partial class PurchasedItemsPage : Page
    {
        Kursach_Luzin_Patrakov_321Entities db = new Kursach_Luzin_Patrakov_321Entities();
        public PurchasedItemsPage()
        {
            InitializeComponent();
            
        }

        public class PurchasedItemsViewModel
        {
            public int PurchaseID { get; set; }
            public Nullable<int> UserID { get; set; }
            public string Item { get; set; }
            public Nullable<int> Quantity { get; set; }
            public Nullable<decimal> Amount { get; set; }
            public string PurchaseDate { get; set; }
            public int Stall { get; set; }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var vendorId = (int)App.Current.Resources["Vendorid"];
            var query = from purchasedItem in db.PurchasedItems
                        where purchasedItem.Stall == vendorId
                        select new PurchasedItemsViewModel
                        {
                            PurchaseID = purchasedItem.PurchaseID,
                            UserID = purchasedItem.UserID,
                            Item = purchasedItem.Item,
                            Quantity = purchasedItem.Quantity,
                            Amount = purchasedItem.Amount,
                            PurchaseDate = purchasedItem.PurchaseDate,
                            Stall = purchasedItem.Stall
                        };
            PurchasedItemsDataGrid.ItemsSource = query.ToList();
        }

        private void SalesReportButton_Click(object sender, RoutedEventArgs e)
        {
            SalesTextBox.Visibility = Visibility.Visible;
            SalesTextBox_text.Visibility = Visibility.Visible;

            var vendorId = (int)App.Current.Resources["Vendorid"];

            // Вычисляем сумму перемноженных значений Quantity и Amount
            var totalAmount = db.PurchasedItems
                                .Where(purchasedItem => purchasedItem.Stall == vendorId)
                                .Sum(purchasedItem => purchasedItem.Quantity * purchasedItem.Amount);

            SalesTextBox.Text = totalAmount.ToString();
        }
    }
}

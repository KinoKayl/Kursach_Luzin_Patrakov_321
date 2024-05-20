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
    /// Interaction logic for SalesPage.xaml
    /// </summary>
    public partial class SalesPage : Page
    {
        Kursach_Luzin_Patrakov_321Entities db = new Kursach_Luzin_Patrakov_321Entities();
        public SalesPage()
        {
             InitializeComponent();
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SalesDataGrid.SelectedItem != null)
            {
                var salesToDelete = (SalesViewModel)SalesDataGrid.SelectedItem;
                var sales = db.Sales.Find(salesToDelete.SaleID);
                if (sales != null)
                {
                    db.Sales.Remove(sales);
                    db.SaveChanges();
                    RefreshDataGrid();
                }
            }
        }


        public class SalesViewModel
        {
            public int SaleID { get; set; }
            public Nullable<int> UserID { get; set; }
            public Nullable<decimal> Amount { get; set; }
            public string SaleDate { get; set; }

        }

        private void RefreshDataGrid()
        {
            var query = from sales in db.Sales
                        select new SalesViewModel
                        {
                            SaleID = sales.SaleID,
                            UserID = sales.UserID,
                            Amount = sales.Amount,
                            SaleDate = sales.SaleDate,

                        };
            SalesDataGrid.ItemsSource = query.ToList();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from sales in db.Sales
                        select new SalesViewModel
                        {
                            SaleID = sales.SaleID,
                            UserID = sales.UserID,
                            Amount = sales.Amount,
                            SaleDate = sales.SaleDate,

                        };
            SalesDataGrid.ItemsSource = query.ToList();
        }
    }
}

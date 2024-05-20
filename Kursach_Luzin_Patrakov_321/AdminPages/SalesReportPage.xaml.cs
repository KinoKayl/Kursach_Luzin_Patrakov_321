using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Kursach_Luzin_Patrakov_321.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для SalesReportPage.xaml
    /// </summary>
    public partial class SalesReportPage : Page
    {
        Kursach_Luzin_Patrakov_321Entities db = new Kursach_Luzin_Patrakov_321Entities();
        public SalesReportPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var totalSalesCount = db.Sales.Count();

            var totalAmountEarned = db.Sales.Sum(sale => sale.Amount) ?? 0;

            string report = $"Количество проданных билетов: {totalSalesCount}\n" +
                            $"Общая сумма заработка: {totalAmountEarned:C}";

            SalesReportText.Text = report;
        }
    }
}
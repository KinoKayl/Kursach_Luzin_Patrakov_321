using Kursach_Luzin_Patrakov_321.VendorPages;
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
    /// Логика взаимодействия для VendorWindow.xaml
    /// </summary>
    public partial class VendorWindow : Window
    {

        public VendorWindow()
        {
            InitializeComponent();
        }

        private void StallsButton_Click(object sender, RoutedEventArgs e)
        {
            StallsPage stallPage = new StallsPage();
            PageFrame.Content = stallPage;
        }

        private void PurchasedItemsButton_Click(object sender, RoutedEventArgs e)
        {
            PurchasedItemsPage purchasedItemsPage = new PurchasedItemsPage();
            PageFrame.Content = purchasedItemsPage;
        }
    }
}

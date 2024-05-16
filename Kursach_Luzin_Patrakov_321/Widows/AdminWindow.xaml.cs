using Kursach_Luzin_Patrakov_321.AdminPages;
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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            UsersPage usersPage = new UsersPage(); 
            PageFrame.Content = usersPage;
        }

        private void SalesButton_Click(object sender, RoutedEventArgs e)
        {
            SalesPage salesPage = new SalesPage();
            PageFrame.Content = salesPage;
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            ReportPage reportPage = new ReportPage();   
            PageFrame.Content = reportPage;
        }

        private void StallsButton_Click(object sender, RoutedEventArgs e)
        {
            StallsPage stallsPage = new StallsPage();
            PageFrame.Content = stallsPage;
        }

        private void CosplayersButton_Click(object sender, RoutedEventArgs e)
        {
            CosplayerPageAdmin cospayersPageAdmin = new CosplayerPageAdmin();
            PageFrame.Content = cospayersPageAdmin;
        }
    }
}

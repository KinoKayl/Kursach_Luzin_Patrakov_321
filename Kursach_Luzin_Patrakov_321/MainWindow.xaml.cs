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

namespace Kursach_Luzin_Patrakov_321
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            AuthPage auth = new AuthPage();
            auth.Show();
        }


        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            Boolean WindowOpened = false;

            if (!WindowOpened)
            {
                BuyWindow buyWindow = new BuyWindow();
                buyWindow.Show();
                WindowOpened = true;
            }
            
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
        }

        private void EventsButton_Click(object sender, RoutedEventArgs e)
        {
            IventsWindow iventsWindow = new IventsWindow();
            iventsWindow.Show();
        }

        private void AboutUsButton_Click(object sender, RoutedEventArgs e)
        {
            AboutUsWindow AuWindow = new AboutUsWindow();
            AuWindow.Show();
        }
    }
}

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
    /// Логика взаимодействия для BuyWindow.xaml
    /// </summary>
    public partial class BuyWindow : Window

    {
        Kursach_Luzin_Patrakov_321Entities db = new Kursach_Luzin_Patrakov_321Entities();
        public BuyWindow()
        {
            InitializeComponent();
        }

        // Радиобаттоны адресов
        private void BersenevButton_Checked(object sender, RoutedEventArgs e)
        {
            FirstDateButton.Content = "6 Июля";
            SecondDateButton.Content = "7 Июля";

            App.Current.Resources["Location"] = 1;
        }

        private void GlagolButton_Checked(object sender, RoutedEventArgs e)
        {
            FirstDateButton.Content = "10 Августа";
            SecondDateButton.Content = "11 Августа";

            App.Current.Resources["Location"] = 2;
        }

        private void EnergButton_Checked(object sender, RoutedEventArgs e)
        {
            FirstDateButton.Content = "13 Июля";
            SecondDateButton.Content = "14 Июля";

            App.Current.Resources["Location"] = 3;
        }

        private void SpartButton_Checked(object sender, RoutedEventArgs e)
        {
            FirstDateButton.Content = "27 Июля";
            SecondDateButton.Content = "28 Июля";

            App.Current.Resources["Location"] = 4;
        }

       

        //Радиобаттоны типов билета
        private void GuestButton_Checked(object sender, RoutedEventArgs e)
        {
            TicketPriceTextBlock.Text = "850 руб.";
            App.Current.Resources["TicketType"] = "Guest";
            App.Current.Resources["Price"] = 850m;
            //decimal count = (decimal)App.Current.Resources["Price"];
        }

        private void CosButton_Checked(object sender, RoutedEventArgs e)
        {
            TicketPriceTextBlock.Text = "750 руб.";
            App.Current.Resources["TicketType"] = "Cosplayer";
            App.Current.Resources["Price"] = 750m;
            //decimal count = (decimal)App.Current.Resources["Price"];
        }

        private void VIPButton_Checked(object sender, RoutedEventArgs e)
        {
            TicketPriceTextBlock.Text = "1200 руб.";
            App.Current.Resources["TicketType"] = "VIP";
            App.Current.Resources["Price"] = 1200m;
        }

        public bool Buy(int locationId, string ticketType, decimal price, string purchaseDate, int userId)
        {
            if (BersenevButton.IsChecked != true && EnergButton.IsChecked != true && SpartButton.IsChecked != true && GlagolButton.IsChecked != true) //Проверка выбора адреса
            {
                MessageBox.Show("Выберите адрес фестиваля который хотите посетить");
                return false;

            }
            else if (FirstDateButton.IsChecked != true && SecondDateButton.IsChecked != true) //Проверка выбора даты
            {
                MessageBox.Show("Выберите дату посещения");
                return false;
            }
            else if (FirstDateButton.IsChecked != true && SecondDateButton.IsChecked != true) //Проверка выбора типа билета
            {
                MessageBox.Show("Выберите тип билета");
                return false;

            }
            else
            {
                //Вывод страницы заполнения анкеты косплеера
                if (CosButton.IsChecked == true)
                {
                    CospayersPage cospayers = new CospayersPage();
                    cospayers.ShowDialog();
                    CosName_memory.Text = (string)App.Current.Resources["CosName"];
                }

                //Функционал кнопки

                Tickets newTicket = new Tickets
                {
                    LocationID = locationId,
                    TicketType = ticketType,
                    Price = price,
                    PurchaseDate = purchaseDate,
                    UserID = userId
                };

                Sales sales = new Sales
                {
                    UserID = userId,
                    Amount = price,
                    SaleDate = purchaseDate,
                };



                db.Tickets.Add(newTicket);
                db.Sales.Add(sales);
                // Сохранение изменений в базе данных
                db.SaveChanges();

                MessageBox.Show("Билет оформлен");
                this.Close();

                return true;
            }
            
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine($"Location Type: {App.Current.Resources["Location"]?.GetType()} - Value: {App.Current.Resources["Location"]}");
            Console.WriteLine($"TicketType Type: {App.Current.Resources["TicketType"]?.GetType()} - Value: {App.Current.Resources["TicketType"]}");
            Console.WriteLine($"Price Type: {App.Current.Resources["Price"]?.GetType()} - Value: {App.Current.Resources["Price"]}");
            Console.WriteLine($"Date Type: {App.Current.Resources["Date"]?.GetType()} - Value: {App.Current.Resources["Date"]}");
            Console.WriteLine($"UserID Type: {App.Current.Resources["UserID"]?.GetType()} - Value: {App.Current.Resources["UserID"]}");





            if (Buy((int)App.Current.Resources["Location"], (string)App.Current.Resources["TicketType"], (decimal)App.Current.Resources["Price"], (string)App.Current.Resources["Date"], (int)App.Current.Resources["UserID"]))
            {
                //FrameManager.MainFrame.Navigate(new AuthPage());

            }
        }

        private void FirstTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FirstDateButton_Checked(object sender, RoutedEventArgs e)
        {
            App.Current.Resources["Date"] = SecondDateButton.Content;
        }

        private void SecondDateButton_Checked(object sender, RoutedEventArgs e)
        {
            App.Current.Resources["Date"] = SecondDateButton.Content;
        }
    }
}

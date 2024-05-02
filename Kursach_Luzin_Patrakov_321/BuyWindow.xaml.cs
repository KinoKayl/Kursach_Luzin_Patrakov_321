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
        public BuyWindow()
        {
            InitializeComponent();
        }

        //Текст Имени и фамилии
        private void GotFocus(TextBox textBox, string placeholderText, string replacementText)
        {
            if (textBox != null && textBox.Text == placeholderText)
            {
                textBox.Text = replacementText;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void LostFocus(TextBox textBox, string replacementText, string placeholderText)
        {
            if (textBox != null && textBox.Text == placeholderText)
            {
                textBox.Text = replacementText;
                textBox.Foreground = Brushes.Gray;
            }
        }

        //Пропадющий текст
        private void FirsttextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            GotFocus(textBox, "Введите Имя", "");
        }
        private void FirsttextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            LostFocus(textBox, "Введите Имя", "");
        }

        private void SecondtextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            GotFocus(textBox, "Введите Фамилию", "");
        }
        private void SecondtextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            LostFocus(textBox, "Введите Фамилию", "");
        }


        // Радиобаттоны адресов
        private void BersenevButton_Checked(object sender, RoutedEventArgs e)
        {
            FirstDateButton.Content = "6 Июля";
            SecondDateButton.Content = "7 Июля";
        }

        private void EnergButton_Checked(object sender, RoutedEventArgs e)
        {
            FirstDateButton.Content = "13 Июля";
            SecondDateButton.Content = "14 Июля";
        }

        private void SpartButton_Checked(object sender, RoutedEventArgs e)
        {
            FirstDateButton.Content = "27 Июля";
            SecondDateButton.Content = "28 Июля";
        }

        private void GlagolButton_Checked(object sender, RoutedEventArgs e)
        {
            FirstDateButton.Content = "10 Августа";
            SecondDateButton.Content = "11 Августа";
        }

        //Радиобаттоны типов билета
        private void GuestButton_Checked(object sender, RoutedEventArgs e)
        {
            TicketPriceTextBlock.Text = "850 руб.";
        }

        private void CosButton_Checked(object sender, RoutedEventArgs e)
        {
            TicketPriceTextBlock.Text = "950 руб.";
        }

        private void VIPButton_Checked(object sender, RoutedEventArgs e)
        {
            TicketPriceTextBlock.Text = "1200 руб.";
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstTextBox.Text == "" || FirstTextBox.Text == "Введите Имя")
            {
                MessageBox.Show("Выберите Имя участника");
            }
            if (SecondTextBox.Text == "" || SecondTextBox.Text == "Введите Фамилию")
            {
                MessageBox.Show("Выберите Фамилию участника");
            }
            if (BersenevButton.IsChecked != true && EnergButton.IsChecked != true && SpartButton.IsChecked != true  && GlagolButton.IsChecked != true) //Проверка выбора адреса
            {
                MessageBox.Show("Выберите адрес фестиваля который хотите посетить");
                
            }
            else if (FirstDateButton.IsChecked != true && SecondDateButton.IsChecked != true) //Проверка выбора даты
            {
                MessageBox.Show("Выберите дату посещения");

            }
            else if (FirstDateButton.IsChecked != true && SecondDateButton.IsChecked != true) //Проверка выбора типа билета
            {
                MessageBox.Show("Выберите тип билета");

            }
            else
            {
                //Функционал кнопки

                //Внесение пармаетров билета в бд

                //Вывод страницы заполнения анкеты косплеера
                if (CosButton.IsChecked == true) 
                {
                    CospayersPage cospayers = new CospayersPage();
                    cospayers.Show();

                }
            }
            
            
            
            
        }
    }
}

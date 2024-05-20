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
    /// Логика взаимодействия для CospayersPage.xaml
    /// </summary>
    public partial class CospayersPage : Window
    {
        Kursach_Luzin_Patrakov_321Entities db = new Kursach_Luzin_Patrakov_321Entities();
        public CospayersPage()
        {
            InitializeComponent();
        }

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

        private void AnimeTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            GotFocus(textBox, "Введите название аниме...", "");
        }

        private void AnimeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            LostFocus(textBox, "Введите название аниме...", "");
        }

        private void CharTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            GotFocus(textBox, "Введите имя персонажа...", "");
        }

        private void CharTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            LostFocus(textBox, "Введите имя персонажа...", "");
        }


        private void AnimeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AnimeTextBox != null && CharacterTextBox != null)
            {
                CostumeNameTextBlock.Text = $"Тайтл: {AnimeTextBox.Text}\nПерсонаж: {CharacterTextBox.Text}"; //Для отображения
            }
            if (AnimeTextBox != null && CharacterTextBox != null)
            {
                CostumeNameTextBlock_memory.Text = $"Тайтл: {AnimeTextBox.Text} Персонаж: {CharacterTextBox.Text}"; //Для бд
            }

        }

        private void CharacterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AnimeTextBox != null && CharacterTextBox != null && CostumeNameTextBlock != null && CostumeNameTextBlock_memory != null)
            {
                CostumeNameTextBlock.Text = $"Тайтл: {AnimeTextBox.Text}\nПерсонаж: {CharacterTextBox.Text}"; //For display
                CostumeNameTextBlock_memory.Text = $"Тайтл: {AnimeTextBox.Text} Персонаж: {CharacterTextBox.Text}"; //For database
            }
        }

        private void FormButton_Click(object sender, RoutedEventArgs e)
        {
            //Проверка
            if (AnimeTextBox.Text == "" || AnimeTextBox.Text == "Введите название аниме...") 
            {
                MessageBox.Show("Введите название аниме");

            }
            else if (CharacterTextBox.Text == "" || CharacterTextBox.Text == "Введите имя персонажа...")
            {
                MessageBox.Show("Введите имя персонажа");

            }
            else
            {
                //Функционал
                App.Current.Resources["CosName"] = CostumeNameTextBlock_memory.Text;
                CospayersPage cospayersPage = new CospayersPage();
                this.Close();

            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
    }
}

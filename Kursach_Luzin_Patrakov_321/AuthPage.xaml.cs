﻿using System;
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
    /// Interaction logic for AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Window
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        //Текст Имени и фамилии
        private void GotFocus(TextBox textBox, string placeholderText, string replacementText)
        {
            if (textBox != null && textBox.Text == placeholderText)
            {
                textBox.Text = replacementText;
               // textBox.Foreground = Brushes.Black;
            }
        }

        private void LostFocus(TextBox textBox, string replacementText, string placeholderText)
        {
            if (textBox != null && textBox.Text == placeholderText)
            {
                textBox.Text = replacementText;
               // textBox.Foreground = Brushes.Gray;
            }
        }

        //Пропадющий текст

        private void SecondtextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            GotFocus(textBox, "Введите логин", "");
        }
        private void SecondtextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            LostFocus(textBox, "Введите логин", "");
        }

        private void thirdtextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PassBox.Password != "" && PassBox.Password == "fvfvfvffvfvfvfvfvfvfvfvfvfvfvfvvfvvf")
            {
                PassBox.Password = "";
                // textBox.Foreground = Brushes.Black;
            }
        }
        private void thirdtextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PassBox.Password != "" && PassBox.Password == "fvfvfvffvfvfvfvfvfvfvfvfvfvfvfvvfvvf")
            {
                PassBox.Password = "fvfvfvffvfvfvfvfvfvfvfvfvfvfvfvvfvvf";
                // textBox.Foreground = Brushes.Black;
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            RegPage reg = new RegPage();
            RegFrame.Content = reg;

            RegFrame.Visibility = Visibility.Visible;
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
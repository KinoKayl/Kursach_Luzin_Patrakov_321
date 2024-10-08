﻿using Kursach_Luzin_Patrakov_321.Widows;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        Kursach_Luzin_Patrakov_321Entities db = new Kursach_Luzin_Patrakov_321Entities();
        public InfoWindow()
        {
            InitializeComponent();
            if (App.Current.Resources.Contains("isAdmin") && App.Current.Resources["isAdmin"] == "true")
            {
                Add_News_Button.Visibility = Visibility.Visible;
                Delete_News_Button.Visibility = Visibility.Visible;
            }
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var newsForm = new NewsForm();
            newsForm.ShowDialog();

            if (newsForm.DialogResult.HasValue && newsForm.DialogResult.Value)
            {
                var newNews = new News
                {
                    Newsdate = newsForm.Newsdate,
                    title = newsForm.title
                };

                db.News.Add(newNews);
                try
                {
                    db.SaveChanges();
                    RefreshDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении новости: " + ex.Message);                  
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }


        public class NewsViewModel
        {
            public int NewsID { get; set; }
            public string Newsdate { get; set; }
            public string title { get; set; }
        }

        private void RefreshDataGrid()
        {
            var query = from news in db.News
                        select new NewsViewModel
                        {
                            NewsID = news.NewsID,
                            Newsdate = news.Newsdate,
                            title = news.title
                        };
            InfoDataGrid.ItemsSource = query.ToList();
        }


        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (InfoDataGrid.SelectedItem != null)
            {
                var newsToDelete = (NewsViewModel)InfoDataGrid.SelectedItem;
                var news = db.News.Find(newsToDelete.NewsID);
                if (news != null)
                {
                    db.News.Remove(news);
                    db.SaveChanges();
                    RefreshDataGrid();
                }
            }
        }
    }
}

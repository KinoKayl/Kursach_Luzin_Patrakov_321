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
        public InfoWindow()
        {
            InitializeComponent();
            foreach (DataGridColumn column in InfoDataGrid.Columns)
            {
                column.Width = new DataGridLength(100);
            }

            List<AnimeFestivalNews> news = new List<AnimeFestivalNews>
{
             new AnimeFestivalNews("2023-03-15", "Анонс фестиваля аниме ESCAPE FROM NANBA 2024"),
             new AnimeFestivalNews("2023-03-23", "Открытие регистрации на ESCAPE FROM NANBA 2024"),
             new AnimeFestivalNews("2023-04-05", "Объявление списка гостей ESCAPE FROM NANBA 2024"),
             new AnimeFestivalNews("2023-04-07", "Анонс расписания мероприятий ESCAPE FROM NANBA 2024"),
             new AnimeFestivalNews("2023-04-15", "Запуск продаж билетов на ESCAPE FROM NANBA 2024"),
             new AnimeFestivalNews("2023-06-15", "Публикация списка участников конкурса косплея ESCAPE FROM NANBA 2024"),
             new AnimeFestivalNews("2023-07-05", "Начало проведения фестиваля ESCAPE FROM NANBA 2024"),
             new AnimeFestivalNews("2023-07-06", "Второй день фестиваля ESCAPE FROM NANBA 2024"),
             new AnimeFestivalNews("2023-07-07", "Заключительный день фестиваля ESCAPE FROM NANBA 2024"),
             new AnimeFestivalNews("2023-07-08", "Фотоотчет с фестиваля ESCAPE FROM NANBA 2024"),
             new AnimeFestivalNews("2023-07-08", "Интервью с организаторами фестиваля ESCAPE FROM NANBA 2024"),
             new AnimeFestivalNews("2023-07-08", "Подготовка к проведению следующего аниме-фестиваля"),
};

            // Создание источника данных для DataGrid
            DataTable dt = new DataTable();
            dt.Columns.Add("Дата", typeof(string));
            dt.Columns.Add("Новости", typeof(string));

            // Заполнение источника данных
            foreach (var item in news)
            {
                dt.Rows.Add(item.Date, item.News);
            }

            // Привязка источника данных к DataGrid
            InfoDataGrid.ItemsSource = dt.DefaultView;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Rows.Add("2023-07-08", "Новая новость");
            
        }
    }
}

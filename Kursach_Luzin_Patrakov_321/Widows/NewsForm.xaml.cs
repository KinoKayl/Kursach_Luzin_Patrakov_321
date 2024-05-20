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
    /// Логика взаимодействия для NewsForm.xaml
    /// </summary>
    public partial class NewsForm : Window
    {
        public string Newsdate { get; private set; }
        public string title { get; private set; }
        public NewsForm()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Newsdate = NewsDataTextBox.Text;
            title = NewsTitleTextBox.Text;

            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}

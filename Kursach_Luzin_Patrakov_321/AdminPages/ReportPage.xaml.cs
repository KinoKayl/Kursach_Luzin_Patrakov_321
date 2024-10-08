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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursach_Luzin_Patrakov_321.AdminPages
{
    /// <summary>
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        public ReportPage()
        {
            InitializeComponent();
        }

        private void SalesButton_Click(object sender, RoutedEventArgs e)
        {
            SalesReportPage salesReportPage = new SalesReportPage();
            ReportFrame.Content = salesReportPage;
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            UserReportPage userReportPage = new UserReportPage();
            ReportFrame.Content = userReportPage;
        }
    }
}

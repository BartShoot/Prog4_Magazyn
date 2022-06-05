using FastMember;
using Magazyn.Models;
using Magazyn.Views;
using System;
using System.Data;
using System.Windows;

namespace Magazyn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Databases"));
            InitializeComponent();
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            /*
            using (MagazynDBContext context = _contextFactory.Create())
            {
                DataTable dt = new();
                using (var reader = ObjectReader.Create(context.Zawiasy))
                {
                    dt.Load(reader);
                }
                DataGridZawiasy.DataContext = dt;
                dt = new();
                using (var reader = ObjectReader.Create(context.Uchwyty))
                {
                    dt.Load(reader);
                }
                DataGridUchwyty.DataContext = dt;
                dt = new();
                using (var reader = ObjectReader.Create(context.Prowadnice))
                {
                    dt.Load(reader);
                }
                DataGridProwadnice.DataContext = dt;
                dt = new();
                using (var reader = ObjectReader.Create(context.Akcesoria))
                {
                    dt.Load(reader);
                }
                DataGridAkcesoria.DataContext = dt;
                dt = new();
                using (var reader = ObjectReader.Create(context.Plyty))
                {
                    dt.Load(reader);
                }
                DataGridPlyty.DataContext = dt;
            }
            */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var test = new ZawiasAdd();
            var container = new Window();
            container.Content = test;
            container.Show();
        }
    }
}

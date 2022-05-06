using FastMember;
using Magazyn.CRUD;
using Magazyn.Models;
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
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Databases"));
            InitializeComponent();
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            DataTable dt = new();

            dt = ZawiasyCRUD.Instance.GetAll();
            DataGridZawiasy.DataContext = dt;

            using (var context = new MagazynDBContext())
            {
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
        }

        private void ZawiasyInsert(object sender, RoutedEventArgs e)
        {
            ZawiasyCRUD.Instance.Insert();
        }
    }
}

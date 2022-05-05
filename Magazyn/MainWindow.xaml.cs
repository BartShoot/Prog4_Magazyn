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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FastMember;
using Magazyn.Models;

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
            DataTable dt = new DataTable();
            using (var context = new MagazynDBContext())
            {
                using (var reader = ObjectReader.Create(context.Zawiasy))
                {
                    dt.Load(reader);
                }
                using (var reader = ObjectReader.Create(context.Prowadnice))
                {
                    dt.Load(reader);
                }
                using (var reader = ObjectReader.Create(context.Uchwyty))
                {
                    dt.Load(reader);
                }
                using (var reader = ObjectReader.Create(context.Plyty))
                {
                    dt.Load(reader);
                }
                using (var reader = ObjectReader.Create(context.Akcesoria))
                {
                    dt.Load(reader);
                }
                DataGrid1.DataContext = dt;
            }
        }
    }
}

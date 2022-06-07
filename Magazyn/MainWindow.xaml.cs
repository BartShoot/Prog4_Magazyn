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
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var test = new ZawiasAdd();
            var container = new Window();
            //container.Content = test;
            container.Show();
        }
    }
}

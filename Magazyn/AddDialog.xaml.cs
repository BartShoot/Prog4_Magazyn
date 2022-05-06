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

namespace Magazyn
{
    /// <summary>
    /// Interaction logic for AddDialog.xaml
    /// </summary>
    public partial class AddDialog : Window
    {
        public AddDialog()
        {
            InitializeComponent();
        }

        public void AddTextBox(string title)
        {
            Label l = new();
            l.Content = title;
            AddStackPanel.Children.Add(l);
            TextBox textBox = new();
            AddStackPanel.Children.Add(textBox);
        }
    }
}

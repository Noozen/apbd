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

namespace Cwiczenia3
{
    /// <summary>
    /// Interaction logic for Zadanie2.xaml
    /// </summary>
    public partial class Zadanie2 : Window
    {
        public Zadanie2()
        {
            InitializeComponent();
            ComboBoxStudent.Items.Add("Student");
            ComboBoxStudent.Items.Add("Skreślony");
            ComboBoxStudent.Items.Add("Absolwent");
            ComboBoxStudent.SelectedIndex = 0;

        }

        private void Zadanie2CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StudentTextBox.SelectedText = ComboBoxStudent.SelectedItem.ToString();
        }
    }
}

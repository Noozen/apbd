using Cwiczenia3.Models;
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
    /// Interaction logic for Zadanie3i4.xaml
    /// </summary>
    public partial class Zadanie3i4 : Window
    {
        public Zadanie3i4()
        {
            InitializeComponent();

            StudentsDataGrid.Items.Add(new Student { FirstName = "Jan", LastName = "Kowalski", IndexNumber = "s1234"});
            StudentsDataGrid.Items.Add(new Student { FirstName = "Mariusz", LastName = "Kowalski", IndexNumber = "s1254"});
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StudentsDataGrid.Items.Add(new Student { FirstName = ImieBox.Text, LastName = NazwiskoBox.Text, IndexNumber = IndexBox.Text});
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < StudentsDataGrid.SelectedItems.Count; i++)
            {
                StudentsDataGrid.Items.Remove(StudentsDataGrid.SelectedItems[i]);
            }
        }

        private void StudentsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (StudentsDataGrid.SelectedItem == null) return;
            var s = StudentsDataGrid.SelectedItem as Student;

            var window = new StudentEditDialog(s);
            window.Show();
        }
    }
}

using Kolokwium.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Kolokwium
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Model1 con = new Model1();

        public MainWindow()
        {
            InitializeComponent();
            updateAnimals();
        }

        private void updateAnimals()
        {
            var animals = con.Animals;

            var result = from a in animals
                         select new
                         {
                             Owner_FirstName = a.Owner.FirstName,
                             Owner_LastName = a.Owner.LastName,
                             Animal_Name = a.Name,
                             Animal_Type = a.AnimalType.Name
                         };


            DataGrid.ItemsSource = result.ToList();

            //Nie działa mi ustawianie szerokości
            //foreach(var x in DataGrid.Columns)
            //{
            //   x.MinWidth = x.ActualWidth;
            //   x.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            //}


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window1(this, con.Owners, con.AnimalTypes);
            window.Show();
        }

        internal void refreshAnimals()
        {
            updateAnimals();
        }
    }
}

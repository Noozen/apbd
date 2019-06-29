using Kolokwium.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Kolokwium
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        private MainWindow mainWindow;

        public Window1(MainWindow mw, System.Data.Entity.DbSet<Owner> owners, System.Data.Entity.DbSet<AnimalType> animalTypes)
        {
            InitializeComponent();
            mainWindow = mw;
            NewName.Text = "";
            NewOwner.ItemsSource = new ObservableCollection<Owner>(owners.ToList());
            NewOwner.DisplayMemberPath = "LastName";
            NewOwner.SelectedValuePath = "IdOwner";
            NewOwner.SelectedIndex = 0;
            NewType.ItemsSource = new ObservableCollection<AnimalType>(animalTypes.ToList());
            NewType.DisplayMemberPath = "Name";
            NewType.SelectedValuePath = "IdAnimalType";
            NewType.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(NewName.Text))
            {
                addAnimal(
                    NewName.Text,
                    MainWindow.con.AnimalTypes.FirstOrDefault(x => x.IdAnimalType == (int)NewType.SelectedValue),
                    MainWindow.con.Owners.FirstOrDefault(x => x.IdOwner == (int)NewOwner.SelectedValue));
                Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void addAnimal(String animalName, AnimalType animalType, Owner owner)
        {
            MainWindow.con.Animals.Add(new Animal { AnimalType = animalType, Owner = owner, Name = animalName });
            MainWindow.con.SaveChanges();
            mainWindow.refreshAnimals();
        }
    }
}

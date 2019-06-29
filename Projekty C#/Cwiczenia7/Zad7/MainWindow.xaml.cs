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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zad7.Models;

namespace Zad7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Niestety baza danych na PJATK dziala niesamowicie wolno, dlatego musialem skorzystac z bazy podstawionej lokalnie
            var con = new PjatkDb();

            select(con);
            insert(con);
            delete(con);
            update(con);
        }

        public void select(PjatkDb con)
        {
            var result = con.Students.ToList();
            DataGrid.ItemsSource = result.ToList();
        }

        public void insert(PjatkDb con)
        {
            var newStudent = new Student() { age = 22, name = "Kowalski"};
            con.Students.Add(newStudent);

            con.SaveChanges();
        }

        public void delete(PjatkDb con)
        {
            var oldStudent = new Student() { Id = 1 };

            con.Students.Attach(oldStudent);
            con.Students.Remove(oldStudent);
        }

        public void update(PjatkDb con)
        {
            var result = con.Students.First();
            result.age = 99;

            con.SaveChanges();
        }

    }
}

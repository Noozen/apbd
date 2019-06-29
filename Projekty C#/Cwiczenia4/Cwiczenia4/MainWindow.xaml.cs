using Cwiczenia4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.SqlClient;
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

namespace Cwiczenia4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<Student> ListaStudentow;

        public MainWindow()
        {
            InitializeComponent();
            //LoadDataToListBox1();
            LoadDataToListBoxAndDataGrid2();
            //LoadDataToListBox3();
            ListaStudentow.CollectionChanged += ListaStudentow_CollectionChanged;
        }

        private void ListaStudentow_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //MessageBox.Show("Coś się zmieniło w kolekcji");
        }

        private void LoadDataToListBox1 ()
        {
            StudentsListBox.Items.Add(new ListBoxItem { Content = "Kwiatkowska" });
            StudentsListBox.Items.Add("Wieczorkowski");
            StudentsListBox.Items.Add(new Student { IdStudent = 1, Imie = "Mariusz", Nazwisko = "Kwiatkowski" });
        }

        private void LoadDataToListBoxAndDataGrid2()
        {
            ListaStudentow = new ObservableCollection<Student>();
            ListaStudentow.Add(new Student { IdStudent = 1, Imie = "Jan", Nazwisko = "Kowalski", Plec = true });
            ListaStudentow.Add(new Student { IdStudent = 2, Imie = "Mariusz", Nazwisko = "Głowacki" });

            StudentsListBox.ItemsSource = ListaStudentow;
            StudentsDataGrid.ItemsSource = ListaStudentow;
        }

        private void LoadDataToList3()
        {
            //Niestety z uwagi na niewiarygodnie wolną prędkość działania bazy danych na serwerze PJATK, nie jestem w stanie stworzyc odpowiedniej tabeli na serwereze wraz z przykładowymi danymi
            //Natomiast poniższy kod przy wywołaniu powinien poprawnie pobrać odpowiednie kolumny z tabeli "student" dla bazy "s16415" na serwerze PJATK i wyświetlić je w kontrolce DataGrid oraz ListBox
            ListaStudentow = new ObservableCollection<Student>();
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s16415;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM student", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int) reader["id"];
                        string imie = reader["imie"].ToString();
                        string nazwisko = reader["nazwisko"].ToString();

                        ListaStudentow.Add(new Student { Nazwisko = nazwisko, Imie = imie, IdStudent = id});
                    }
                }
            }

            StudentsListBox.ItemsSource = ListaStudentow;
            StudentsDataGrid.ItemsSource = ListaStudentow;
        }

        private void ShowSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(StudentsListBox.SelectedItem.ToString());
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            ListaStudentow.Add(new Student { IdStudent = 3, Imie = "AAA", Nazwisko = "BBB" });
        }
    }
}

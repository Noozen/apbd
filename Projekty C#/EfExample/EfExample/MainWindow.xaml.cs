using EfExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;

namespace EfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Example7AddingNewElement();
        }

        public void Example1SimpleFetch()
        {
            var context = new BazaDanych();

            var result = context.Students.ToList();

            int g = 0;
        }

        public void Example2LazyLoading()
        {
            var context = new BazaDanych();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var result = context.Students;

            foreach (var i in result)
            {
                string tmp = i.LastName;
            }
        }

        public void Example3LazyLoadingWithN1Problem()
        {
            var context = new BazaDanych();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            
            var result = context
                        .Students
                        .Include(s => s.Study).Take(10);
            
            foreach (var i in result)
            {
                if (i.Study.Name == null)
                {
                    //...
                }
            }
        }

        public void Example4Collection()
        {
            try
            {
                var context = new BazaDanych();
                context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var result = context.Studies.ToList();
            }
            catch (Exception exc)
            {
                int g = 0;
            }
        }

        public void Example5Collection()
        {
            var context = new BazaDanych();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var result = context.Students
                .Where(s => s.LastName.StartsWith("K")) //LIKE K%
                .Include(s => s.Study)
                .ToList();

        }

        public void Example6SplitQuery()
        {
            var context = new BazaDanych();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var query = context.Students //Expr tree
                .Include(s => s.Study)
                .Where(s => s.LastName.StartsWith("K"));
            
            var query2 = query.OrderBy(s => s.LastName);

            var result = query2.ToList();
        }

        public void Example7SplitQueryWorsePerformance()
        {
            var context = new BazaDanych();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            IEnumerable<Student> query = context.Students.ToList();

            var query2 = query.Where(s => s.LastName.StartsWith("K"));

            var result = query2.ToList();
        }

        public void Example7AddingNewElement()
        {
            try
            {
                var context = new BazaDanych();
                context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var newStudent = new Student()
                {
                    FirstName = "Andrzej2",
                    LastName = "Kowalski3",
                    Address = "Warsaw, ul. Koszykowa 86",
                    IdStudies = 1
                };

                context.Students.Add(newStudent);
     
                context.SaveChanges();
            }
            catch (Exception exc)
            {
                int g = 0;
            }
        }

        public void Example8AddingNewElement()
        {
            try
            {
                var context = new BazaDanych();
                context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var newStudent = new Student()
                {
                    FirstName = "Andrzej2",
                    LastName = "Kowalski3",
                    Address = "Warsaw, ul. Koszykowa 86",
                    IdStudies = 1
                };


                var newStudies = new Study()
                {
                    IdStudies = 1
                };
                context.Studies.Attach(newStudies);

                newStudent.Study = newStudies;

                context.Students.Add(newStudent);
                context.SaveChanges();
            }
            catch (Exception exc)
            {
                int g = 0;
            }

        }

        public void Example9RemovingElement()
        {
            try
            {
                var context = new BazaDanych();
                context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var student = new Student
                {
                    IdStudent=1,
                    LastName="Sth"
                };
               
                context.Students.Attach(student);
                context.Entry<Student>(student).State = EntityState.Modified;
                context.SaveChanges(); //

            }
            catch (Exception exc)
            {
                int g = 0;
            }
        }

        public void Example10RemovingElement()
        {
            try
            {
                var context = new BazaDanych();
                context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var stToRemove = new Student
                {
                    IdStudent = 1
                };

                context.Students.Attach(stToRemove);
                context.Students.Remove(stToRemove);

                context.SaveChanges();
            }
            catch (Exception exc)
            {
                int g = 0;
            }

        }

        public void Example10UpdatingElement()
        {
            try
            {
                var context = new BazaDanych();
                context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var stToRemove = new Student
                {
                    IdStudent = 3,
                    FirstName = "ZMIENIONY",
                    LastName = "ZMIENIONY",
                    IdStudies = 1,
                    Address = "a"
                };

                context.Students.Attach(stToRemove);
                var entry = context.Entry<Student>(stToRemove);
                entry.State = EntityState.Modified;

                context.SaveChanges();
            }
            catch (DbEntityValidationException exc)
            {
                int g = 0;
            }

        }

        public void Example11AddingMultipleElements()
        {
            var context = new BazaDanych();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var newSt = new Study
            {
                Name = "NOWY"
            };

            var newStudent = new Student
            {
                FirstName = "A",
                LastName = "B",
                Address = "C",
                Study = newSt
            };
            
            context.Students.Add(newStudent);
            context.SaveChanges();
        }

        public void Example12AExplicitLoading()
        {
            var context = new BazaDanych();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var student = context.Students.First();

            context.Entry(student).Reference(s => s.Study).Load();
            context.Entry(student).Collection(s => s.StudentSubject).Load();

            int g = 0;
        }
    }
}
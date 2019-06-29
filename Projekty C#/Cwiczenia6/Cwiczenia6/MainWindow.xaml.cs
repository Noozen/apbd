using Cwiczenia6.Models;
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

namespace Cwiczenia6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Emp> Emps { get; set; }
        public List<Dept> Depts { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            Example();
        }

        public void LoadData()
        {
            Emps = new List<Emp>();
            Depts = new List<Dept>();

            Emps.Add(new Emp
            {
                Empno = 7369,
                Ename = "SMITH",
                Job = "CLERK",
                Mgr = 7902,
                HireDate = new DateTime(1980, 12, 17),
                Sal=800,
                Comm=0,
                Deptno=20
            });

            Emps.Add(new Emp
            {
                Empno = 7499,
                Ename = "ALLEN",
                Job = "SALESMAN",
                Mgr = 7698,
                HireDate = new DateTime(1981, 2, 20),
                Sal = 1600,
                Comm = 300,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7521,
                Ename = "WARD",
                Job = "SALESMAN",
                Mgr = 7698,
                HireDate = new DateTime(1981, 2, 22),
                Sal = 1250,
                Comm = 500,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7566,
                Ename = "JONES",
                Job = "MANAGER",
                Mgr = 7839,
                HireDate = new DateTime(1981, 4, 2),
                Sal = 2975,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7654,
                Ename = "MARTIN",
                Job = "SALESMAN",
                Mgr = 7698,
                HireDate = new DateTime(1981, 9, 28),
                Sal = 1250,
                Comm = 1400,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7698,
                Ename = "BLAKE",
                Job = "MANAGER",
                Mgr = 7839,
                HireDate = new DateTime(1981, 5, 1),
                Sal = 2850,
                Comm = 0,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7782,
                Ename = "CLARK",
                Job = "MANAGER",
                Mgr = 7839,
                HireDate = new DateTime(1981, 6, 9),
                Sal = 2450,
                Comm = 0,
                Deptno = 10
            });

            Emps.Add(new Emp
            {
                Empno = 7788,
                Ename = "SCOTT",
                Job = "ANALYST",
                Mgr = 7566,
                HireDate = new DateTime(1982, 12, 9),
                Sal = 3000,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7839,
                Ename = "KING",
                Job = "PRESIDENT",
                Mgr = null,
                HireDate = new DateTime(1981, 11, 17),
                Sal = 5000,
                Comm = 0,
                Deptno = 10
            });

            Emps.Add(new Emp
            {
                Empno = 7844,
                Ename = "TURNER",
                Job = "SALESMAN",
                Mgr = 7698,
                HireDate = new DateTime(1981, 9, 8),
                Sal = 1500,
                Comm = 0,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7876,
                Ename = "ADAMS",
                Job = "CLERK",
                Mgr = 7788,
                HireDate = new DateTime(1983, 1, 12),
                Sal = 1100,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7900,
                Ename = "JAMES",
                Job = "CLERK",
                Mgr = 7698,
                HireDate = new DateTime(1981, 12, 3),
                Sal = 950,
                Comm = 0,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7902,
                Ename = "FORD",
                Job = "ANALYST",
                Mgr = 7566,
                HireDate= new DateTime(1981, 12, 3),
                Sal = 3000,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7934,
                Ename = "MILLER",
                Job = "CLERK",
                Mgr = 7782,
                HireDate = new DateTime(1982, 1, 23),
                Sal = 1300,
                Comm = 0,
                Deptno = 10
            });

            Depts.Add(new Dept
            {
                Deptno=10,
                Dname= "ACCOUNTING",
                Loc= "NEW YORK"
            });

            Depts.Add(new Dept
            {
                Deptno = 20,
                Dname = "RESEARCH",
                Loc = "DALLAS"
            });

            Depts.Add(new Dept
            {
                Deptno = 30,
                Dname = "SALES",
                Loc = "CHICAGO"
            });

            Depts.Add(new Dept
            {
                Deptno = 40,
                Dname = "OPERATIONS",
                Loc = "BOSTON"
            });
        }

        private void Example()
        {
            //Query syntax
            var result = from e in Emps
                         where e.Ename.StartsWith("K")
                         select e;

            //Lambda and Extension methods syntax
            var result2 = Emps.Where(e => e.Ename.StartsWith("K"));


            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_1(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         select new
                         {
                             R_PENSJA = e.Sal * 12
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_2(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         select new
                         {
                             EMPLOYEE = e.Empno + e.Ename
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_3(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         join d in Depts on e.Deptno equals d.Deptno
                         select new
                         {
                             Kto_gdzie_pracuje = e.Ename + " pracuje w dziale o numerze " + d.Deptno
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_4(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         select new
                         {
                             yearly_salary_commision = (e.Sal + e.Comm) * 12
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_5(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         select new
                         {
                             used_departments = e.Deptno
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_6(object sender, RoutedEventArgs routedEvent)
        {
            var result = (from e in Emps
                          select new
                          {
                              used_departments_distinct = e.Deptno
                          }).Distinct();

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_7(object sender, RoutedEventArgs routedEvent)
        {
            var result = (from e in Emps
                          select new
                          {
                              department = e.Deptno,
                              job = e.Job
                          }).Distinct();

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_8(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         orderby e.Ename ascending
                         select e;

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_9(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         orderby e.HireDate descending
                         select e;

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_10(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         orderby e.Deptno ascending, e.Sal descending
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_11(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where e.Job.Equals("CLERK")
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Deptno = e.Deptno,
                             Job = e.Job
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_12(object sender, RoutedEventArgs eroutedEvent)
        {
            var result = from d in Depts
                         where d.Deptno > 20
                         select new
                         {
                             deptno = d.Deptno,
                             dname = d.Dname
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_13(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where e.Comm > e.Sal
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Sal = e.Sal,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_14(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where e.Sal > 1000 && e.Sal < 2000
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Sal = e.Sal,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_15(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where e.Mgr == 7902 || e.Mgr == 7566 || e.Mgr == 7788
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Sal = e.Sal,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_16(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where e.Ename.StartsWith("S")
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Sal = e.Sal,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_17(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where e.Ename.Length==4
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Sal = e.Sal,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_18(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where e.Mgr == null
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Sal = e.Sal,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_19(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where e.Sal < 1000 || e.Sal > 2000
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Sal = e.Sal,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_20(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where !e.Ename.StartsWith("M")
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Sal = e.Sal,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_21(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where e.Mgr != null
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Sal = e.Sal,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_22(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where e.Job.Equals("CLERK") && e.Sal >= 1000 && e.Sal < 2000
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Sal = e.Sal,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_23(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where e.Job.Equals("CLERK") || (e.Sal >= 1000 && e.Sal < 2000)
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Sal = e.Sal,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_24(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where (e.Job.Equals("MANAGER") && e.Sal > 1500) || e.Job.Equals("SALESMAN")
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Sal = e.Sal,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_25(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where (e.Job.Equals("SALESMAN") && e.Sal > 1500) || e.Job.Equals("MANAGER")
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Sal = e.Sal,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q1_26(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where (e.Job.Equals("CLERK") && e.Deptno == 10) || e.Job.Equals("MANAGER")
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Sal = e.Sal,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q2_1(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         join d in Depts on e.Deptno equals d.Deptno
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Sal = e.Sal,
                             Hiredate = e.HireDate,
                             Job = e.Job,
                             Dname = d.Dname,
                             Loc = d.Loc
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q2_2(object sender, RoutedEventArgs routedEvent)
        {
            var result = (from e in Emps
                          select new { name = e.Ename }).Union(
                         (from d in Depts
                          select new { name = d.Dname })).OrderBy(x => x.name);

             DataGrid.ItemsSource = result.ToList();
        }

        private void Q2_3(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         join d in Depts on e.Deptno equals d.Deptno
                         select new
                         {
                             Ename = e.Ename,
                             Dname = d.Dname,
                             Depno = e.Deptno
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q2_4(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         join d in Depts on e.Deptno equals d.Deptno
                         where e.Sal > 1500
                         select new
                         {
                             Ename = e.Ename,
                             Dloc = d.Loc,
                             Dname = d.Dname
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q2_5(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         join d in Depts on e.Deptno equals d.Deptno
                         where d.Loc.Equals("DALLAS")
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job,
                             Salary = e.Sal,
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q2_6(object sender, RoutedEventArgs routedEvent)
        {
            var result = from d in Depts
                         join e in Emps on d.Deptno equals e.Deptno into joined
                         from j in joined.DefaultIfEmpty()
                         select new
                         {
                             Empno = j?.Empno,
                             Ename = j?.Ename,
                             Comm = j?.Comm,
                             Deptno = j?.Deptno,
                             Mgr = j?.Mgr,
                             Hiredate = j?.HireDate,
                             Job = j?.Job,
                             Salary = j?.Sal,
                             DeptName = d?.Dname,
                             DeptLoc = d?.Loc
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q2_7(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         join d in Depts on e.Deptno equals d.Deptno into joined
                         from j in joined.DefaultIfEmpty()
                         select new
                         {
                             Empno = e?.Empno,
                             Ename = e?.Ename,
                             Comm = e?.Comm,
                             Deptno = e?.Deptno,
                             Mgr = e?.Mgr,
                             Hiredate = e?.HireDate,
                             Job = e?.Job,
                             Salary = e?.Sal,
                             DeptName = j?.Dname,
                             DeptLoc = j?.Loc
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q2_8(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         join d in Depts on e.Deptno equals d.Deptno
                         where d.Deptno == 20 || d.Deptno == 30
                         select new
                         {
                             Ename = d.Deptno == 20 ? "" : e.Ename,
                             Deptno = e.Deptno
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q2_9(object sender, RoutedEventArgs routedEvent)
        {
            var result = (from e in Emps
                         join d in Depts on e.Deptno equals d.Deptno
                         where e.Deptno == 10 || e.Deptno == 30
                         select new
                         {
                             Job = e.Job
                         }).Distinct();

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q2_10(object sender, RoutedEventArgs routedEvent)
        {
            var result = (from e in Emps
                          join d in Depts on e.Deptno equals d.Deptno
                          where e.Deptno == 10 
                          select new
                          {
                              Job = e.Job
                          }).Distinct();

            var result2 = (from e in Emps
                          join d in Depts on e.Deptno equals d.Deptno
                          where e.Deptno == 30
                          select new
                          {
                              Job = e.Job
                          }).Distinct();

            var finalResult = result.Intersect(result2);

            DataGrid.ItemsSource = finalResult.ToList();
        }

        private void Q2_11(object sender, RoutedEventArgs routedEvent)
        {
            var result = (from e in Emps
                          join d in Depts on e.Deptno equals d.Deptno
                          where e.Deptno == 10 && !Emps.Any(e2 => e2.Deptno == 30 && e2.Job==e.Job)
                          select new
                          {
                              Job = e.Job
                          }).Distinct();

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q2_12(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         join e2 in Emps on e.Mgr equals e2.Empno
                         where e2 != null && e2.Sal > e.Sal
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q2_13(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         join e2 in Emps on e.Mgr equals e2.Empno
                         orderby e2.Ename
                         select new
                         {
                             Ename = e.Ename,
                             boss_name = e2?.Ename
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q3_1(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         group e.Sal by 1==1 into g
                         select new
                         {
                             average_salary = g.Average()
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q3_2(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where e.Job.Equals("CLERK")
                         group e.Sal by 1 == 1 into g
                         select new
                         {
                             minimal_clerk_salary = g.Min()
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q3_3(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where e.Deptno == 20
                         group e.Sal by 1 == 1 into g
                         select new
                         {
                             employees_dept_20 = g.Count()
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q3_4(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         group e.Sal by e.Job into g
                         select new
                         {
                             job = g.Key, 
                             average_salary = g.Average()
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q3_5(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where !e.Job.Equals("MANAGER")
                         group e.Sal by e.Job into g
                         select new
                         {
                             job = g.Key,
                             average_salary = g.Average()
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q3_6(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         group e.Sal by new {e.Job, e.Deptno} into g
                         select new
                         {
                             job = g.Key,
                             average_salary = g.Average()
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q3_7(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         group e.Sal by e.Job into g
                         select new
                         {
                             job = g.Key,
                             average_salary = g.Max()
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q3_8(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         let countEmp = (from e2 in Emps where e2.Deptno == e.Deptno group e2.Empno by 1==1 into g2 select new { count = g2.Count() }).First().count
                         where countEmp > 3
                         group e.Sal by e.Deptno into g
                         select new
                         {
                             job = g.Key,
                             average_salary = g.Average()
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q3_9(object sender, RoutedEventArgs routedEvent)
        {
            var result = (from e in Emps
                         group e.Sal by e.Job into g
                         select new
                         {
                             job = g.Key,
                             average_salary = g.Average()
                         }).Where(e2 => e2.average_salary >= 3000);

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q3_10(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         group e.Sal + e.Comm by e.Job into g
                         select new
                         {
                             job = g.Key,
                             monthly_total = g.Average(),
                             yearly_total = g.Average() * 12
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q3_11(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         group e.Sal by 1 == 1 into g
                         select new
                         {
                             diff_max_min_salary = g.Max() - g.Min()
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q3_12(object sender, RoutedEventArgs routedEvent)
        {
            var result = (from e in Emps
                         let countEmp = (from e2 in Emps where e2.Deptno == e.Deptno group e2.Empno by 1 == 1 into g2 select new { count = g2.Count() }).First().count
                         where countEmp > 3
                         select new
                         {
                             e.Deptno
                         }).Distinct();

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q3_13(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         group e.Empno by 1 == 1 into g
                         select new
                         {
                             amount_of_non_unique_identifiers = g.Count() - g.Distinct().Count()
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q3_14(object sender, RoutedEventArgs routedEvent)
        {
            var result = (from e in Emps
                         group e.Sal by e.Mgr into g
                         select new
                         {
                             job = g.Key,
                             average_salary = g.Min()
                         }).Where(g => g.average_salary >=1000);

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q3_15(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         join d in Depts on e.Deptno equals d.Deptno
                         where d.Loc.Equals("DALLAS")
                         group e.Empno by d.Deptno into g
                         select new
                         {
                             empoyee = g.Count()
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q4_1(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         let inner = Emps.Min(e2 => e2.Sal)
                         where e.Sal == inner
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job,
                             Salary = e.Sal
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q4_2(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         let inner = (from e2 in Emps where e2.Ename.Equals("BLAKE") select new {Job = e2.Job}).First()
                         where e.Job.Equals(inner.Job)
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job,
                             Salary = e.Sal
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q4_3(object sender, RoutedEventArgs routedEvent)
        {
            //Nie rozumiem roznicy miedzy poleceniem 4.3 i 4.4
            var result = from e in Emps
                         let inner = (from e2 in Emps where e2.Deptno == e.Deptno orderby e2.Sal ascending select new { Sal = e2.Sal }).First()
                         where e.Sal == inner.Sal
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job,
                             Salary = e.Sal
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q4_4(object sender, RoutedEventArgs routedEvent)
        {
            //Nie rozumiem roznicy miedzy poleceniem 4.3 i 4.4
            var result = from e in Emps
                         let inner = (from e2 in Emps where e2.Deptno == e.Deptno orderby e2.Sal ascending select new { Sal = e2.Sal }).First()
                         where e.Sal == inner.Sal
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job,
                             Salary = e.Sal
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q4_5(object sender, RoutedEventArgs routedEvent)
        {

            var result = from e in Emps
                         where Emps.Any(e2 => e2.Sal < e.Sal && e2.Deptno == 30)
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job,
                             Salary = e.Sal
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q4_6(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         let inner = (from e2 in Emps where e2.Deptno == 30 group e2.Sal by 1 == 1 into g select new { maxDep30 = g.Max() }).First().maxDep30
                         where e.Sal > inner
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job,
                             Salary = e.Sal
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q4_7(object sender, RoutedEventArgs routedEvent)
        {
            var result = (from e in Emps
                         group e.Sal by e.Deptno into g2
                         select new
                         {
                             dept = g2.Key,
                             average_per_dept = g2.Average()
                         }).Distinct().Where(i => i.average_per_dept > (from e2 in Emps where e2.Deptno == 30 group e2.Sal by 1 == 1 into g select new { maxDep30 = g.Average() }).First().maxDep30);

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q4_8(object sender, RoutedEventArgs routedEvent)
        {
            var result = (from e in Emps
                         group e.Sal by e.Job into g
                         select new
                         {
                             job = g.Key,
                             average_salary = g.Average()
                         }).OrderByDescending(i => i.average_salary).Take(1);

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q4_9(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         let inner = Emps.Min(e2 => e2.Sal)
                         where e.Sal > (from e2 in Emps join d in Depts on e2.Deptno equals d.Deptno where d.Dname.Equals("SALES") group e2.Sal by d.Deptno into g select new {maxSales = g.Max()}).First().maxSales
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job,
                             Salary = e.Sal
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q4_10(object sender, RoutedEventArgs routedEvent)
        {
            var result = from e in Emps
                         where e.Sal > (from e2 in Emps where e2.Deptno == e.Deptno group e2.Sal by e2.Deptno into g select new { dept_average = g.Average()}).First().dept_average
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job,
                             Salary = e.Sal
                         };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q4_11(object sender, RoutedEventArgs routedEvent)
        {
            //Rozumiem że chodzi o operator Any?
            var result = (from e in Emps
                          where Emps.Any(e2 => e2.Mgr == e.Empno)
                         select new
                         {
                             Empno = e.Empno,
                             Ename = e.Ename,
                             Comm = e.Comm,
                             Deptno = e.Deptno,
                             Mgr = e.Mgr,
                             Hiredate = e.HireDate,
                             Job = e.Job,
                             Salary = e.Sal
                         });

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q4_12(object sender, RoutedEventArgs routedEvent)
        {
            //Odpowiedziec jest pusta, ponieważ nie ma takich pracownikow
            var result = (from e in Emps
                          where !Depts.Any(d => d.Deptno == e.Deptno)
                          select new
                          {
                              Empno = e.Empno,
                              Ename = e.Ename,
                              Comm = e.Comm,
                              Deptno = e.Deptno,
                              Mgr = e.Mgr,
                              Hiredate = e.HireDate,
                              Job = e.Job,
                              Salary = e.Sal
                          });

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q4_13(object sender, RoutedEventArgs routedEvent)
        {
            var result = (from e in Emps
                          group e.HireDate by e.Deptno into g
                          select new
                          {
                              dept = g.Key,
                              hire_date_by_dept = g.Max()
                          }).OrderBy(d => d.hire_date_by_dept);

            DataGrid.ItemsSource = result.ToList();
        }

        private void Q4_14(object sender, RoutedEventArgs routedEvent)
        {
            //Bez numerka, ale rozumiem to jako zadanie 14?
            var result = from e in Emps
                         where e.Sal > (from e2 in Emps where e2.Deptno == e.Deptno group e2.Sal by e2.Deptno into g select new { dept_average = g.Average() }).First().dept_average
                         select new
                         {
                             Ename = e.Ename,
                             Deptno = e.Deptno,
                             Salary = e.Sal
                         };

            DataGrid.ItemsSource = result.ToList();
        }

    }
}

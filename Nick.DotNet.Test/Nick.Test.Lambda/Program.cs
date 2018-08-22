using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Nick.Test.Lambda
{
    /// <summary>
    /// P455 Lambda表達式的由來
    /// </summary>
    class Program
    {
        //定義委派
        public delegate bool StudentDelegate(Student student);

        //實現執行羅輯
        private static bool IsQualified(Student s)
        {
            return s.AvgScore > 60;
        }

        //模擬實現靜態的where方法
        public static class MyExtensions
        {
           
            public static IList<Student> Where(IList<Student> source, StudentDelegate d)
            {
                IList<Student> result = new List<Student>();

                foreach (var item in source)
                {
                    if (d(item))
                    {
                        result.Add(item);
                    }
                }

                return result;
            }

            public static IEnumerable<T> WhereExt<T>(IEnumerable<T> source, Func<T, bool> d)
            {
                foreach (var item in source)
                {
                    if (d(item))
                    {
                        yield return item;
                    }
                }
            }

            
        }

       

        /// <summary>
        /// .NET 1.0
        /// </summary>
        /// <param name="students"></param>
        /// <returns></returns>
        public static IList<Student> GetStudents(IList<Student> students)
        {
            //StudentDelegate d = new StudentDelegate(this.IsQualified);
            StudentDelegate d = new StudentDelegate(IsQualified);
            var result = MyExtensions.Where(students, d);
            return result;
        }

        /// <summary>
        /// .NET 2.0
        /// </summary>
        /// <param name="students"></param>
        /// <returns></returns>
        public static IList<Student> GetStudentsV2(IList<Student> students)
        {
            var result = Enumerable.Where(students,
                delegate(Student s)
                {
                    return s.AvgScore > 60;
                }).ToList();

            return result;
        }

        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student() {Name = "AA", AvgScore = 90},
                new Student() {Name = "BB", AvgScore = 55}
            };

            //Lambda
            //var result = students.Where(x => x.AvgScore > 80;

            //.NET 1.0 時代
            //var result = GetStudents(students);

            //.NET 2.0 時代
            //var result = GetStudentsV2(students);

            //.NET 3.0/3.5 時代
            //var result = Enumerable.Where(students, 
            //    (Student s) => { return s.AvgScore > 60; }).ToList();

            //再優化
            //var result = Enumerable.Where(students,
            //    s => s.AvgScore > 60).ToList();

            //擴充方法
            //var result = MyExtensions.WhereExt(students, s => s.AvgScore > 60).ToList();

            //擴充方法 再優化
            var result = students.WhereExt2(student => student.AvgScore > 60).ToList();

            foreach (var student in result)
            {
                Console.WriteLine(student.Name);
            }
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int AvgScore { get; set; }
    }
}

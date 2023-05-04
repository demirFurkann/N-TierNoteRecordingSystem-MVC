using Bogus;
using Bogus.DataSets;
using Project.DAL.ContextClasses;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Init
{
    public class MyInit : CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            Random rnd = new Random();
            #region Öğrenci Ekleme
            for (int i = 0; i < 10; i++)
            {
                Student s = new Student();
                s.FirstName = new Name("tr").FirstName();
                s.LastName = new Name("tr").LastName();
                s.Image = new Internet().Avatar();
                s.Gender = new Person().Gender.ToString();
                context.Students.Add(s);

            }
            context.SaveChanges();


            #endregion

            #region Ders Ekleme
            List<string> dersler = new List<string>() { "Matematik", "Fizik", "Kimya", "Biyoloji", "Tarih" };
            foreach (string item in dersler)
            {
                Lesson l = new Lesson();

                l.LessonName = item;

                context.Lessons.Add(l);
            }
            context.SaveChanges();
            #endregion

            #region Not Ekleme
            List<Student> students = context.Students.ToList();
            List<Lesson> lessons = context.Lessons.ToList();
            foreach (Student student in students)
            {
                foreach (Lesson lesson in lessons)
                {
                    Note n = new Note();
                    n.StudentID = student.ID;
                    n.LessonID = lesson.ID;
                    n.Exam1 = rnd.Next(10, 100);
                    n.Exam2 = rnd.Next(10, 100);
                    n.Exam3 = rnd.Next(10, 100);
                    n.Project = rnd.Next(10, 100);
                    n.Avarage = Convert.ToInt16((n.Exam1 + n.Exam2 + n.Exam3 + n.Project) / 4);
                    n.Case = n.Avarage >= 50 ? true : false;
                    context.Notes.Add(n);
                }
            }
            context.SaveChanges();
            #endregion
        }





    }
}

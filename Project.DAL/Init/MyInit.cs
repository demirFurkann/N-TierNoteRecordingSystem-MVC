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
            foreach (var item in dersler)
            {
                Lesson l = new Lesson();
                l.LessonName = item;
                context.Lessons.Add(l);
            }
            context.SaveChanges();
            #endregion

            #region Not Ekleme
            List<Student> ogrenciler = context.Students.ToList();
            List<Lesson>  dersListesi =  context.Lessons.ToList();

            foreach (Student ogrenci in ogrenciler)
            {
                foreach (Lesson ders in dersListesi)
                {
                    Note n = new Note();

                    n.Exam1 = new Random().Next(50,100);  
                    n.Exam2 = new Random().Next(50,100);  
                    n.Exam3 = new Random().Next(50,100);  
                    n.Project = new Random().Next(50,100);
                    n.Avarage = Convert.ToInt16((n.Exam1 + n.Exam2 + n.Exam3 + n.Project) / 4);
                    n.Case = n.Avarage  >= 50 ? true : false;   
                    context.Notes.Add(n);
                }
                context.SaveChanges();
            }
         
            #endregion

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;

namespace DBPracticum
{
    class Program
    {
        static void Main(string[] args)
        {
            //EDM_modelContainer db = new EDM_modelContainer();
            DBPracticum.EDM_modelContainer db = new EDM_modelContainer();
            var user = new User
            {
                FirstName = new FirstName { FName = "Ivan" },
                LastName = new LastName { LName = "Petrov" },
                BirthDate = new BirthDate { BDate = new DateTime(1992, 03, 15) },
                Email = "petrov92@bd.com",
                Id = Guid.NewGuid()
            };

            var date = new BirthDate
            {
                //Id = Guid.NewGuid(),
                BDate = new DateTime(1993, 10, 08)
            };

            
            if (db.BirthDateSet.Local.Contains(date) != true)
            {
                Console.WriteLine("true!!!");
                db.BirthDateSet.Local.Add(date);
            }
            //if (db.BirthDateSet.Local.Contains(date) == false)
              //  db.BirthDateSet.Add(date);
            //db.UserSet.Add(user);
            foreach (var err in db.GetValidationErrors())
            {
                Console.WriteLine(err + "\n");
            }
            //var bdate = db.BirthDateSet.Find(new DateTime(1993, 10, 08));
            //Console.WriteLine(bdate.BDate + " is found\n");
            db.SaveChanges();

            var query1 = from u in db.UserSet
                        select u;
            foreach (var item in query1)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }

            var query2 = from d in db.BirthDateSet
                         select d;
            foreach (var item in query2)
            {
                Console.WriteLine(/*item.Id + " " + */item.BDate);
            }
        }
    }
}

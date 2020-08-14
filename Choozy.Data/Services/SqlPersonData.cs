using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Choozy.Data.Models;

namespace Choozy.Data.Services
{
    public class SqlPersonData : IPersonData
    {
        private readonly ChoozyDbContext db;

        public SqlPersonData(ChoozyDbContext db)
        {
            this.db = db;
        }

        public void Add(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var person = db.Persons.Find(id);
            db.Persons.Remove(person);
            db.SaveChanges();
        }

        public Person Get(int id)
        {
            return db.Persons.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            //return db.Persons;
            return from p in db.Persons
                   orderby p.Age descending, p.Name
                   select p;
        }

        public Person GetRandom()
        {
            throw new NotImplementedException();
        }

        public void Update(Person person)
        {
            var entry = db.Entry(person);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}

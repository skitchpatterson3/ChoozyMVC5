using Choozy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choozy.Data.Services
{
    public class InMemoryPersonData : IPersonData
    {
        List<Person> persons;

        public InMemoryPersonData()
        {
            persons = new List<Person>()
            {
                new Person { Id = 1, Name = "Zach", Age = 34, AvatarFilename = "Zach.jpg" },
                new Person { Id = 2, Name = "Candice", Age = 32, AvatarFilename = "Candi.jpg" },
                new Person { Id = 3, Name = "Roxy", Age = 7, AvatarFilename = "Roxy.jpg" },
                new Person { Id = 4, Name = "James", Age = 5, AvatarFilename = "James.jpg" },
                new Person { Id = 5, Name = "Joel", Age = 3, AvatarFilename = "Joel.jpg" },
                new Person { Id = 6, Name = "Levi", Age = 1, AvatarFilename = "Levi.jpg", IsExcluded = true }
            };
        }

        public void Add(Person person)
        {
            persons.Add(person);
            person.Id = persons.Max(p => p.Id) + 1; //needs work when moving out of in-memory storage
        }

        public void Update(Person person)
        {
            var existing = Get(person.Id);
            if (existing != null)
            {
                existing.Name = person.Name;
                existing.Age = person.Age;
                existing.IsExcluded = person.IsExcluded;
                existing.AvatarFilename = person.AvatarFilename;
            }
        }

        public Person Get(int id)
        {
            return persons.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return persons.OrderByDescending(p => p.Age);
        }

        public void Delete(int id)
        {
            var person = Get(id);
            if (person != null)
            {
                persons.Remove(person);
            }
        }
        
        public Person GetRandom()
        {
            //System.Diagnostics.Debug.WriteLine("Creating 'persons' list.");
            
            //if (persons == null)
            //{
            //    Console.WriteLine("Supplied 'persons' object is null. Assigning current persons collection from the db source.");
                //if no persons collection is supplied with the method call, use the current collection from the db source
                //persons = this.persons;
            //}
            var persons = this.persons.Where(p => p.IsExcluded == false);

            //System.Diagnostics.Debug.WriteLine("Persons list finalized.");
            System.Diagnostics.Debug.WriteLine("'persons' list count: {0}", persons.Count());

            int n = persons.Count();
            //System.Diagnostics.Debug.WriteLine("Number range to pass to randomizer: 0 to {0}", n);

            //check that at least two not-excluded persons are in the list
            if (n <= 1)
            {
                System.Diagnostics.Debug.WriteLine("GetRandom() method stopped because there are not enough included persons in the list!");
                return null;
            }

            //get random number between 0 and n-1
            Random random = new Random();

            var r = random.Next(0, n);
            System.Diagnostics.Debug.WriteLine("r is {0}", r);

            Person rndPerson = persons.ToList()[r];
            System.Diagnostics.Debug.WriteLine("Random person selected is person at position {0} in list: {1}", r, rndPerson.Name);

            return rndPerson;
        }
    }
}

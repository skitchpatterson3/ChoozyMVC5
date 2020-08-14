using Choozy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choozy.Data.Services
{
    public interface IPersonData
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        void Add(Person person);
        void Update(Person person);
        void Delete(int id);
        Person GetRandom();
    }
}

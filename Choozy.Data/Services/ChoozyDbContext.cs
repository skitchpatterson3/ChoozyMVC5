using Choozy.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choozy.Data.Services
{
    public class ChoozyDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}

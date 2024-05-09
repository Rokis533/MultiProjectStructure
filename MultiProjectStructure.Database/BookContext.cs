using Microsoft.EntityFrameworkCore;
using MultiProjectStructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiProjectStructure.Database
{
    public class BookContext : DbContext
    {

        public DbSet<Book> Books { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options) { }


    }
}

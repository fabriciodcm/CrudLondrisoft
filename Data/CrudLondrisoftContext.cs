using Microsoft.EntityFrameworkCore;
using CrudLondrisoft.Models;

namespace CrudLondrisoft.Data
{
    public class CrudLondrisoftContext : DbContext
    {
        public CrudLondrisoftContext(DbContextOptions<CrudLondrisoftContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
    }
}
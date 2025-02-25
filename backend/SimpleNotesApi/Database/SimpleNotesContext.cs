using Microsoft.EntityFrameworkCore;
using SimpleNotesApi.Models;

namespace SimpleNotesApi.Database
{
    public class SimpleNotesContext : DbContext
    {
        public SimpleNotesContext(DbContextOptions options) : base(options) { }

        public DbSet<Note> Notes { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using MyNotes.Entities;
using System.Reflection.Metadata;

namespace MyNotes.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}

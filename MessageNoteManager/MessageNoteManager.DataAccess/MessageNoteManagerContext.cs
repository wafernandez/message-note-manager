using MessageNoteManager.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.DataAccess
{
    public class MessageNoteManagerContext : DbContext
    {
        public MessageNoteManagerContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MessageNoteManager_4.db");
        }
    }
}

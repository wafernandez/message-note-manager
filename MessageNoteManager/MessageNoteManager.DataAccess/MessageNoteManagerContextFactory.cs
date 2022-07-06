using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.DataAccess
{
    public class MessageNoteManagerContextFactory : IDesignTimeDbContextFactory<MessageNoteManagerContext>
    {
        public MessageNoteManagerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MessageNoteManagerContext>();
            optionsBuilder.UseSqlite("Data Source=MessageNoteManager_4.db");

            return new MessageNoteManagerContext(optionsBuilder.Options);
        }
    }
}

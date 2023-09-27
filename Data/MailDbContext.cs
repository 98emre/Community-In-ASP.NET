using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistroLabb2.Data
{
    public class MailDbContext : DbContext
    {
        /// <summary>
        /// Gets or Sets of UserDb where it contains user
        /// </summary>
        /// <value>users</value>
        public DbSet<UserDB> users { get; set; }

        /// <summary>
        /// Gets or Sets of MessageDb where it contains messages
        /// </summary>
        /// <value>messages</value>
        public DbSet<MessageDB> messages { get; set; }

        public MailDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Mail_Database; Trusted_Connection=True; MultipleActiveResultSets=true");
        }
    }
}

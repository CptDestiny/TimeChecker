using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeChecker.Domain.Models;

namespace TimeChecker.EntityFramework
{
    public class TimeCheckerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<TimeEntry> TimeEntries{ get; set;}

        public TimeCheckerDbContext(DbContextOptions options) :base(options) {  }

    }
}

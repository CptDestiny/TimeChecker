using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TimeChecker.EntityFramework
{
    /* Creates the DB Context*
     / Pull the connection string into its own self-contained factory method 
    */

    public class TimeCheckerDbContextFactory : IDesignTimeDbContextFactory<TimeCheckerDbContext>
    {
        public TimeCheckerDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<TimeCheckerDbContext>();
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TimeCheckerDB;Trusted_Connection=True;");

            return new TimeCheckerDbContext(options.Options);

        }
    }
}

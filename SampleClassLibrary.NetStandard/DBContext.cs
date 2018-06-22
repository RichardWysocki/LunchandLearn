using Microsoft.EntityFrameworkCore;
using SampleClassLibrary.NetStandard.Model;

namespace SampleClassLibrary.NetStandard
{
    public class DBContext : DbContext, IDBContext
    {

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<LogInformation> LogInformation { get; set; }
        public DbSet<AutomatedEmails> AutomatedEmails { get; set; }


        void IDBContext.SaveChanges()
        {
            base.SaveChanges();
        }


    }
}

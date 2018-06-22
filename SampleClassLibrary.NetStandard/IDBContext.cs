using Microsoft.EntityFrameworkCore;
using SampleClassLibrary.NetStandard.Model;

namespace SampleClassLibrary.NetStandard
{
    public interface IDBContext
    {

        DbSet<LogInformation> LogInformation { get; set; }
        DbSet<AutomatedEmails> AutomatedEmails { get; set; }

        void SaveChanges();
    }
}

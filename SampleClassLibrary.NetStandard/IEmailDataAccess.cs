using System.Collections.Generic;
using SampleClassLibrary.NetStandard.Model;

namespace SampleClassLibrary.NetStandard
{
    public interface IEmailDataAccess
    {
        IList<AutomatedEmails> Get();

        IList<AutomatedEmails> Get(bool emailSent);

        AutomatedEmails Get(int id);

        AutomatedEmails Insert(AutomatedEmails email);

        bool Update(AutomatedEmails update);
    }
}

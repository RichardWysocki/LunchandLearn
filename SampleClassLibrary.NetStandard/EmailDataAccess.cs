using System;
using System.Collections.Generic;
using System.Linq;
using SampleClassLibrary.NetStandard.Model;

namespace SampleClassLibrary.NetStandard
{
    public class EmailDataAccess: IEmailDataAccess
    {
        private readonly IDBContext _db;

        public EmailDataAccess(IDBContext db)
        {
            _db = db;
        }

        public IList<AutomatedEmails> Get()
        {
            var emails = _db.AutomatedEmails.ToList();
            return emails;
        }

        public IList<AutomatedEmails> Get(bool emailSent)
        {
            var emails = _db.AutomatedEmails.Where(c => c.EmailSent == emailSent).ToList();
            if (emails == null)
                throw new Exception("Error getting AutomatedEmail record.");
            return emails;
        }

        public AutomatedEmails Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("Invalid id Paramter");
            var email = _db.AutomatedEmails.Where(c => c.EmailId == id).SingleOrDefault();
            if (email == null)
                throw new Exception("Error getting AutomatedEmail record.");
            return email;
        }

        public AutomatedEmails Insert(AutomatedEmails email)
        {
            _db.AutomatedEmails.Add(email);
            _db.SaveChanges();
            return email;
        }

        public bool Update(AutomatedEmails update)
        {
            var result = _db.AutomatedEmails.SingleOrDefault(b => b.EmailId == update.EmailId);
            if (result != null)
            {
                result.EmailSent = true;
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

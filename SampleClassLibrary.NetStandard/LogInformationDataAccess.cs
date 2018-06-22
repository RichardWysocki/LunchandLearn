using System;
using System.Collections.Generic;
using System.Linq;
using SampleClassLibrary.NetStandard.Model;

namespace SampleClassLibrary.NetStandard
{
    public class LogInformationDataAccess : ILogInformationDataAccess
    {
        private readonly IDBContext _db;

        public LogInformationDataAccess(IDBContext dbcontext)
        {
            _db = dbcontext;
        }

        /// <summary>
        /// Get All LogInfo Records.  Potential Performance Issues if Records grow too big.
        /// </summary>
        /// <returns>All LogInforamtion Records</returns>
        public IList<LogInformation> Get()
        {
            var getList = _db.LogInformation.ToList();
            return getList;
        }

        /// <summary>
        /// Get One LogInformation Record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>LogInforamtion Record</returns>
        public LogInformation Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("Invalid id Paramter");
            var logInfo = _db.LogInformation.Where(LogInfo => LogInfo.LogId == id).SingleOrDefault();
            if (logInfo == null)
                throw new Exception("Error getting LogInformation record.");
            return logInfo;
        }

        /// <summary>
        /// Insert LogInformation Record.
        /// </summary>
        /// <param name="log"></param>
        /// <returns>LogInforamtion Record</returns>
        public LogInformation Insert(LogInformation log)
        {

            _db.LogInformation.Add(log);
            _db.SaveChanges();
            return log;

        }
    }
}

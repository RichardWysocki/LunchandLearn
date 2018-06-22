using System.Collections.Generic;
using SampleClassLibrary.NetStandard.Model;

namespace SampleClassLibrary.NetStandard
{
    public interface ILogInformationDataAccess
    {
        /// <summary>  
        /// Get All LogInfo Records.  Potential Performance Issues if Records grow too big.
        /// </summary>
        /// <returns>All LogInforamtion Records</returns>
        IList<LogInformation> Get();

        /// <summary>
        /// Get One LogInformation Record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>LogInforamtion Record</returns>
        LogInformation Get(int id);

        /// <summary>
        /// Insert LogInformation Record.
        /// </summary>
        /// <param name="log"></param>
        /// <returns>LogInforamtion Record</returns>
        LogInformation Insert(LogInformation log);

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SampleClassLibrary.NetStandard.Model
{
    /// <summary>
    /// Automated Email Queue
    /// </summary>
    public class AutomatedEmails
    {
        /// <summary>
        /// EmailId: ID for table
        /// </summary>
        [Key]
        public int EmailId { get; set; }

        /// <summary>
        /// ToAddress: Email address on who is getting the email
        /// </summary>
        public string ToAddress { get; set; }

        /// <summary>
        /// Name of Person Receiving the email
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Subject for Email
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Body of Email
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Bit to say Email was Sent or Not Sent. 
        /// </summary>
        public bool EmailSent { get; set; }
    }
}

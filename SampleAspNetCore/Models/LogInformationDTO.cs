﻿using System;

namespace SampleAspNetCore.Models
{
    public class LogInformationDTO
    {
        /// <summary>
        /// LogId
        /// </summary>
        public int LogId { get; set; }

        /// <summary>
        /// Product: Set Application that is sending this information over
        /// </summary>
        public String Product { get; set; }

        /// <summary>
        /// Log Type:  Informational, Error
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Log Class Name
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// Log Method Name
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Log Method Name
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Log Source
        /// </summary>
        public string Source { get; set; }
    }
}

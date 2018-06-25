using System;
using System.ComponentModel.DataAnnotations;
using EntityFramework.Common.Validation;
using EntityFramework.Common.Validation.PageViewAudit;

namespace EntityFramework.Common.Entities
{
    public class PageViewAudit
    {
        public Guid Id { get; set; }

        public DateTimeOffset ViewedAt { get; set; }

        [UserId(false)]
        public string UserId { get; set; }

        [Required]
        [IpAddress]
        public string IpAddress { get; set; }

        [Required]
        [PageUrl]
        public string PageUrl { get; set; }

        [Required]
        [HttpVerb]
        public string HttpVerb { get; set; }

        /// <summary>
        /// The type of record being viewed - E.g. "PATIENT" for viewing a patient record
        /// </summary>
        [SubjectType]
        public string SubjectType { get; set; }

        /// <summary>
        /// The identifer from a 3rd party system of the subject being viewed
        /// E.g. UR Number for a patient
        /// </summary>
        [ExternalIdentifier]
        public string SubjectExternalIdentifier { get; set; }

        /// <summary>
        /// The identifer from this system of the subject being viewed
        /// E.g. the internal reference to a PatientId which can be linked to a UR Number in this database
        /// </summary>
        public int? SubjectInternalIdentifier { get; set; }

        [ExtraData]
        public string ExtraData { get; set; }

    }
}
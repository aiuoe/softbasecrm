using SBCRM.Authorization.Users;
using SBCRM.Crm;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    /// <summary>
    /// This class stores Users connected to opportunities
    /// </summary>
    [Table("OpportunityUsers")]
    public class OpportunityUser : FullAuditedEntity
    {

        public virtual long UserId { get; set; }

        [ForeignKey("UserId")]
        public User UserFk { get; set; }

        public virtual int OpportunityId { get; set; }

        [ForeignKey("OpportunityId")]
        public Opportunity OpportunityFk { get; set; }

    }
}
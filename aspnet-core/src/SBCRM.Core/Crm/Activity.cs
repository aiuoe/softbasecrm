using SBCRM.Crm;
using SBCRM.Crm;
using SBCRM.Authorization.Users;
using SBCRM.Crm;
using SBCRM.Crm;
using SBCRM.Crm;
using SBCRM.Crm;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using SBCRM.Legacy;

namespace SBCRM.Crm
{
    [Table("Activities")]
    public class Activity : FullAuditedEntity<long>
    {

        [Required]
        [StringLength(ActivityConsts.MaxTaskNameLength, MinimumLength = ActivityConsts.MinTaskNameLength)]
        public virtual string TaskName { get; set; }

        public virtual DateTime DueDate { get; set; }

        public virtual DateTime StartsAt { get; set; }

        public virtual int DurationMinutes { get; set; }

        public virtual string Description { get; set; }

        public virtual int? OpportunityId { get; set; }

        [ForeignKey("OpportunityId")]
        public Opportunity OpportunityFk { get; set; }

        public virtual int? LeadId { get; set; }

        [ForeignKey("LeadId")]
        public Lead LeadFk { get; set; }

        public virtual long UserId { get; set; }

        [ForeignKey("UserId")]
        public User UserFk { get; set; }

        public virtual int ActivitySourceTypeId { get; set; }

        [ForeignKey("ActivitySourceTypeId")]
        public ActivitySourceType ActivitySourceTypeFk { get; set; }

        public virtual int ActivityTaskTypeId { get; set; }

        [ForeignKey("ActivityTaskTypeId")]
        public ActivityTaskType ActivityTaskTypeFk { get; set; }

        public virtual int ActivityStatusId { get; set; }

        [ForeignKey("ActivityStatusId")]
        public ActivityStatus ActivityStatusFk { get; set; }

        public virtual int ActivityPriorityId { get; set; }

        [ForeignKey("ActivityPriorityId")]
        public ActivityPriority ActivityPriorityFk { get; set; }

        public virtual string CustomerNumber { get; set; }

        [ForeignKey("CustomerNumber")]
        public Customer CustomerFk { get; set; }

    }
}
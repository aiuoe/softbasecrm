using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    [Table("ActivityStatuses")]
    public class ActivityStatus : FullAuditedEntity
    {

        [StringLength(ActivityStatusConsts.MaxDescriptionLength, MinimumLength = ActivityStatusConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual int Order { get; set; }

    }
}
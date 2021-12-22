using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    /// <summary>
    /// Table wich storages the activity statutes used on the Activities Module, this table belongs to Configuration module
    /// </summary>
    [Table("ActivityStatuses")]
    public class ActivityStatus : FullAuditedEntity
    {

        [Required]
        [StringLength(ActivityStatusConsts.MaxDescriptionLength, MinimumLength = ActivityStatusConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual int Order { get; set; }

        [Required]
        [StringLength(ActivityStatusConsts.MaxColorLength, MinimumLength = ActivityStatusConsts.MinColorLength)]
        public virtual string Color { get; set; }

    }
}
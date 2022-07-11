using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Modules.Common.Avalara.Dto
{
    public class TaxCodeDto
    {
        /// <summary>
        /// The unique ID number of this tax code.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The unique ID number of the company that owns this tax code.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// A code string that identifies this tax code.
        /// </summary>
        public string TaxCode { get; set; }

        /// <summary>
        /// The type of this tax code.
        /// </summary>
        public string TaxCodeTypeId { get; set; }

        /// <summary>
        /// A friendly description of this tax code.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// If this tax code is a subset of a different tax code, this identifies the parent code.
        /// </summary>
        public string ParentTaxCode { get; set; }

        /// <summary>
        /// True if this tax code type refers to a physical object. Read only field.
        /// </summary>
        public bool IsPhysical { get; set; }

        /// <summary>
        /// The Avalara Goods and Service Code represented by this tax code.
        /// </summary>
        public long GoodsServiceCode { get; set; }

        /// <summary>
        /// The Avalara Entity Use Code represented by this tax code.
        /// </summary>
        public string EntityUseCode { get; set; }

        /// <summary>
        /// True if this tax code is active and can be used in transactions.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// True if this tax code has been certified by the Streamlined Sales Tax governing board.
        /// </summary>
        public bool IsSSTCertified { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The User ID of the user who created this record.
        /// </summary>
        public int CreatedUserId { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// The user ID of the user who last modified this record.
        /// </summary>
        public int ModifiedUserId { get; set; }

    }
}

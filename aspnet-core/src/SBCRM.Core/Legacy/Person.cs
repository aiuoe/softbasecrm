using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Legacy
{
    /// <summary>
    /// dbo.Person table from legacy database
    /// </summary>
    [Table("Person", Schema = "dbo")]
    public class Person
    {
		[Key]
		public int Number { get; set; }
		public virtual string LastName { get; set; }
		public virtual string FirstName { get; set; }
		public virtual string MiddleInit { get; set; }
		public virtual string NickName { get; set; }
		public virtual short? MaleFemale { get; set; }
		public virtual string Address { get; set; }
		public virtual string City { get; set; }
		public virtual string State { get; set; }
		public virtual string ZipCode { get; set; }
		public virtual string Phone { get; set; }
		public virtual string Extention { get; set; }
		public virtual short? ExtentionList { get; set; }
		public virtual short? Mechanic { get; set; }
		public virtual decimal? HourlyRate { get; set; }
		public virtual decimal? MonthlyRate { get; set; }
		public virtual short? Branch { get; set; }
		public virtual short? Dept { get; set; }
		public virtual short? UseDefaults { get; set; }
		public virtual string ServiceVan { get; set; }
		public virtual string PictureFile { get; set; }
		public virtual DateTime? BirthDate { get; set; }
		public virtual DateTime? HireDate { get; set; }
		public virtual DateTime? LastReviewDate { get; set; }
		public virtual DateTime? NextReviewDate { get; set; }
		public virtual string Position { get; set; }
		public virtual DateTime? PositionDate { get; set; }
		public virtual DateTime? TerminationDate { get; set; }
		public virtual short? Active { get; set; }
		public virtual string SSNo { get; set; }
		public virtual string DLNo { get; set; }
		public virtual DateTime? DLExpirationDate { get; set; }
		public virtual string Comments { get; set; }
		public virtual string MaritalStatus { get; set; }
		public virtual byte[] PersonImage { get; set; }
		public virtual string PersonGroup { get; set; }
		public virtual string EMailAddress { get; set; }
		public virtual string AddedBy { get; set; }
		public virtual DateTime? DateAdded { get; set; }
		public virtual string ChangedBy { get; set; }
		public virtual DateTime? DateChanged { get; set; }
		public virtual short? AutomaticEmailBCC { get; set; }
	}
}

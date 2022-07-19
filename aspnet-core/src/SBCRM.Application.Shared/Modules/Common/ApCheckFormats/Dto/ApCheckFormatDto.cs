namespace SBCRM.Modules.Common.ApCheckFormats.Dto
{
    /// <summary>
    /// Contains the Data for the Check Format Entity
    /// </summary>
    public class ApCheckFormatDto
    {
        /// <summary>
        /// Name of the Format
        /// </summary>
        public string FormatName { get; set; }

        /// <summary>
        /// Name of the Element
        /// </summary>
        public string ElementName { get; set; }

        /// <summary>
        /// Top position coordinate
        /// </summary>
        public int? TopPosition { get; set; }

        /// <summary>
        /// Left position coordinate
        /// </summary>
        public int? LeftPosition { get; set; }

        /// <summary>
        /// Font Name or type
        /// </summary>
        public string Font { get; set; }

        /// <summary>
        /// Font Size
        /// </summary>
        public int? FontSize { get; set; }

        /// <summary>
        /// Font is bold
        /// </summary>
        public bool FontBold { get; set; }

        /// <summary>
        /// Font is Italic
        /// </summary>
        public bool FontItalic { get; set; }

        /// <summary>
        /// Print element
        /// </summary>
        public bool PrintElement { get; set; }

        /// <summary>
        /// Element Format
        /// </summary>
        public string ElementFormat { get; set; }

        /// <summary>
        /// Tenant Id
        /// </summary>
        public int TenantId { get; set; }

        /// <summary>
        /// Is migrated ?
        /// </summary>
        public bool IsMigrated { get; set; }
    }
}

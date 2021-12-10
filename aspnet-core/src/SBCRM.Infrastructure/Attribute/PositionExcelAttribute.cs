using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Infrastructure.Attribute
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class PositionExcelAttribute : System.Attribute
    {
        public int Column { get; set; }

        public PositionExcelAttribute(int column)
        {
            Column = column;
        }
    }
}

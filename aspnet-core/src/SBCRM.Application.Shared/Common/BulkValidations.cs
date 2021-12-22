using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBCRM.Common
{
    public class BulkValidations
    {
        private readonly List<bool> _appendConditions = new List<bool>();

        public BulkValidations AppendCondition(bool condition)
        {
            _appendConditions.Add(condition);
            return this;
        }

        public bool GetAllTrue()
        {
            return _appendConditions.All(x => x);
        }

        public bool GetAnyTrue()
        {
            return _appendConditions.Any(x => x);
        }
    }
}

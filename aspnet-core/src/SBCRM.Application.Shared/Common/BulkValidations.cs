using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBCRM.Common
{
    /// <summary>
    /// This class is used to verify wether a list of conditions met or not
    /// </summary>
    public class BulkValidations
    {
        private readonly List<bool> _appendConditions = new List<bool>();

        /// <summary>
        /// Add a new condition to the _appendConditions list
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public BulkValidations AppendCondition(bool condition)
        {
            _appendConditions.Add(condition);
            return this;
        }

        /// <summary>
        /// Verifiy if all the conditions met
        /// </summary>
        /// <returns></returns>
        public bool GetAllTrue()
        {
            return _appendConditions.All(x => x);
        }

        /// <summary>
        /// Verifiy if at least one of the conditions met
        /// </summary>
        /// <returns></returns>
        public bool GetAnyTrue()
        {
            return _appendConditions.Any(x => x);
        }
    }
}

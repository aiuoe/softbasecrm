using Microsoft.EntityFrameworkCore;

namespace SBCRM.Legacy
{
    /// <summary>
    /// WIPList VIEW from legacy schema
    /// </summary>
    [Keyless]
    public class WIPList
    {
        public virtual int? WONo { get; set; }
        public virtual string SerialNo { get; set; }
        public virtual short? CustomerFlag { get; set; }
        public virtual short? Disposition { get; set; }
    }
}

using System;

namespace SBCRM
{
    public interface IDbContextSchema
    {
        string Schema { get; }
    }

    public class DbContextSchema : IDbContextSchema
    {
        public string Schema { get; }
        public DbContextSchema(string schema)
        {
            Schema = schema ?? throw new ArgumentNullException(nameof(schema));
        }
    }
}

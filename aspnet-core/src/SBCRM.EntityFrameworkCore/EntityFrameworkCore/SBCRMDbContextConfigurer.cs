using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SBCRM.EntityFrameworkCore
{
    public static class SBCRMDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SBCRMDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString,
                b => b.MigrationsHistoryTable("__EFMigrationsHistory", schema: SBCRMConsts.DefaultSchemaName));
        }

        public static void Configure(DbContextOptionsBuilder<SBCRMDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection,
                b => b.MigrationsHistoryTable("__EFMigrationsHistory", schema: SBCRMConsts.DefaultSchemaName));
        }
    }
}
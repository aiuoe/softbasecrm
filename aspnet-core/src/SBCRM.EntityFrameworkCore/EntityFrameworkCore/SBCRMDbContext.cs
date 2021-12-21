using SBCRM.Crm;
using SBCRM.Legacy;
using Abp.IdentityServer4vNext;
using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SBCRM.Authorization.Delegation;
using SBCRM.Authorization.Roles;
using SBCRM.Authorization.Users;
using SBCRM.Chat;
using SBCRM.Editions;
using SBCRM.Friendships;
using SBCRM.MultiTenancy;
using SBCRM.MultiTenancy.Accounting;
using SBCRM.MultiTenancy.Payments;
using SBCRM.Storage;

namespace SBCRM.EntityFrameworkCore
{
    public class SBCRMDbContext : AbpZeroDbContext<Tenant, Role, User, SBCRMDbContext>, IAbpPersistedGrantDbContext
    {
        public virtual DbSet<Activity> Activities { get; set; }

        public virtual DbSet<ActivitySourceType> ActivitySourceTypes { get; set; }

        public virtual DbSet<ActivityPriority> ActivityPriorities { get; set; }

        public virtual DbSet<Secure> Secure { get; set; }

        public virtual DbSet<AccountUser> AccountUsers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<InvoiceRegList> InvoiceRegList { get; set; }
        public virtual DbSet<WIPList> WIPList { get; set; }
        public virtual DbSet<InvoiceReg> InvoiceReg { get; set; }
        public virtual DbSet<WO> WO { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EQCustomFields> EQCustomFields { get; set; }

        public virtual DbSet<ActivityStatus> ActivityStatuses { get; set; }

        public virtual DbSet<ActivityTaskType> ActivityTaskTypes { get; set; }

        public virtual DbSet<Opportunity> Opportunities { get; set; }

        public virtual DbSet<OpportunityType> OpportunityTypes { get; set; }

        public virtual DbSet<OpportunityStage> OpportunityStages { get; set; }

        public virtual DbSet<LeadUser> LeadUsers { get; set; }

        public virtual DbSet<Priority> Priorities { get; set; }

        public virtual DbSet<Lead> Leads { get; set; }

        public virtual DbSet<LeadStatus> LeadStatuses { get; set; }

        public virtual DbSet<LeadSource> LeadSources { get; set; }

        public virtual DbSet<Industry> Industries { get; set; }

        public virtual DbSet<Customer> Customer { get; set; }

        public virtual DbSet<AccountType> AccountTypes { get; set; }

        public virtual DbSet<ARTerms> ARTerms { get; set; }

        public virtual DbSet<ZipCode> ZipCodes { get; set; }

        /* Define an IDbSet for each entity of the application */

        public virtual DbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual DbSet<Friendship> Friendships { get; set; }

        public virtual DbSet<ChatMessage> ChatMessages { get; set; }

        public virtual DbSet<SubscribableEdition> SubscribableEditions { get; set; }

        public virtual DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        public virtual DbSet<SubscriptionPaymentExtensionData> SubscriptionPaymentExtensionDatas { get; set; }

        public virtual DbSet<UserDelegation> UserDelegations { get; set; }

        public SBCRMDbContext(DbContextOptions<SBCRMDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(SBCRMConsts.DefaultSchemaName);

            modelBuilder.HasSequence<int>("CustomerNumberSequence");

            modelBuilder.Entity<Customer>()
                           .Property(o => o.Number)
                           .HasDefaultValueSql("NEXT VALUE FOR Web.CustomerNumberSequence");

            modelBuilder
                .Entity<InvoiceRegList>(eb =>
                {
                    eb.HasNoKey();
                    eb.ToView("InvoiceRegList", "dbo");
                });

            modelBuilder
                .Entity<WIPList>(eb =>
                {
                    eb.HasNoKey();
                    eb.ToView("WIPList", "dbo");
                });

            modelBuilder.Entity<Customer>().Ignore(c => c.Id);

            modelBuilder.Entity<BinaryObject>(b =>
                                             {
                                                 b.HasIndex(e => new { e.TenantId });
                                             });

            modelBuilder.Entity<ChatMessage>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId, e.ReadState });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.UserId, e.ReadState });
            });

            modelBuilder.Entity<Friendship>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId });
                b.HasIndex(e => new { e.TenantId, e.FriendUserId });
                b.HasIndex(e => new { e.FriendTenantId, e.UserId });
                b.HasIndex(e => new { e.FriendTenantId, e.FriendUserId });
            });

            modelBuilder.Entity<Tenant>(b =>
            {
                b.HasIndex(e => new { e.SubscriptionEndDateUtc });
                b.HasIndex(e => new { e.CreationTime });
            });

            modelBuilder.Entity<SubscriptionPayment>(b =>
            {
                b.HasIndex(e => new { e.Status, e.CreationTime });
                b.HasIndex(e => new { PaymentId = e.ExternalPaymentId, e.Gateway });
            });

            modelBuilder.Entity<SubscriptionPaymentExtensionData>(b =>
            {
                b.HasQueryFilter(m => !m.IsDeleted)
                    .HasIndex(e => new { e.SubscriptionPaymentId, e.Key, e.IsDeleted })
                    .IsUnique();
            });

            modelBuilder.Entity<UserDelegation>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.SourceUserId });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId });
            });

            modelBuilder.ConfigurePersistedGrantEntity();
        }
    }
}
using Abp.Dependency;
using Abp.EntityHistory;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SBCRM.Base;
using SBCRM.EntityFrameworkCore;
using SBCRM.EntityFrameworkCore.Repositories;
using SBCRM.Identity;

namespace SBCRM.Test.Base.DependencyInjection
{
    public static class ServiceCollectionRegistrar
    {
        public static void Register(IIocManager iocManager, IConfigurationRoot configuration)
        {
            RegisterIdentity(iocManager);

            iocManager.IocContainer.Register(Component
                .For(typeof(IRepository<>))
                .ImplementedBy(typeof(Repository<>))
                .LifestyleTransient());

            var sx = NullEntityChangeSetReasonProvider.Instance;

            iocManager.IocContainer.Register(
                Component.For<IEntityChangeSetReasonProvider>()
                    .Instance(sx)
                    .LifestyleTransient());

            iocManager.IocContainer.Register(
                Component.For<ISoftBaseCustomerInvoiceRepository>()
                    .ImplementedBy<SoftBaseCustomerInvoiceRepository>().LifestyleTransient());

            iocManager.IocContainer.Register(
                Component.For<ISoftBaseCustomerEquipmentRepository>()
                    .ImplementedBy<SoftBaseCustomerEquipmentRepository>().LifestyleTransient());

            iocManager.IocContainer.Register(
                Component.For<ISoftBaseCustomerWipRepository>()
                    .ImplementedBy<SoftBaseCustomerWipRepository>().LifestyleTransient());

            iocManager.IocContainer.Register(
                Component.For<ISoftBaseSecureRepository>()
                    .ImplementedBy<SoftBaseSecureRepository>().LifestyleTransient());

            iocManager.IocContainer.Register(
                Component.For<ISoftBaseCustomerSequenceRepository>()
                    .ImplementedBy<SoftBaseCustomerSequenceRepository>().LifestyleTransient());

            iocManager.IocContainer.Register(
                Component.For<ISoftBasePersonRepository>()
                    .ImplementedBy<SoftBasePersonRepository>().LifestyleTransient());

            iocManager.IocContainer.Register(
               Component.For<ISoftBaseBranchRepository>()
                   .ImplementedBy<SoftBaseBranchRepository>().LifestyleTransient());

            iocManager.IocContainer.Register(
               Component.For<ISoftBaseDepartmentRepository>()
                   .ImplementedBy<SoftBaseDepartmentRepository>().LifestyleTransient());


            var builder = new DbContextOptionsBuilder<SBCRMDbContext>();
            
            builder.UseSqlServer(configuration.GetConnectionString(SBCRMConsts.ConnectionStringName));

            iocManager.IocContainer.Register(
                Component
                    .For<DbContextOptions<SBCRMDbContext>>()
                    .Instance(builder.Options)
                    .LifestyleSingleton()
            );

            new SBCRMDbContext(builder.Options).Database.EnsureCreated();
        }

        private static void RegisterIdentity(IIocManager iocManager)
        {
            var services = new ServiceCollection();

            IdentityRegistrar.Register(services);

            WindsorRegistrationHelper.CreateServiceProvider(iocManager.IocContainer, services);
        }
    }
}

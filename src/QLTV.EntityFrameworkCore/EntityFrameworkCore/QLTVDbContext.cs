using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using QLTV.ThuVien;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace QLTV.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityDbContext))]
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class QLTVDbContext : 
        AbpDbContext<QLTVDbContext>,
        IIdentityDbContext,
        ITenantManagementDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */
        
        #region Entities from the modules
        
        /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityDbContext and ITenantManagementDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */
        
        //Identity
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }
        
        // Tenant Management
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion
        public DbSet<Example> Examples { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Reader> Readers { get; set; }

        public QLTVDbContext(DbContextOptions<QLTVDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(QLTVConsts.DbTablePrefix + "YourEntities", QLTVConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});


            builder.Entity<Example>(b =>
            {
                b.ToTable(QLTVConsts.DbTablePrefix + "Examples", QLTVConsts.DbSchema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });

            builder.Entity<Category>(b =>
            {
                b.ToTable(QLTVConsts.DbTablePrefix + "Categories", QLTVConsts.DbLibrarySchema);
                b.Property(s => s.NameCategory).HasMaxLength(100).IsRequired(true);
                b.Property(s => s.DescriptionCategory).HasMaxLength(1000).IsRequired(true);
                b.ConfigureByConvention();
            });

            builder.Entity<Author>(b =>
            {
                b.ToTable(QLTVConsts.DbTablePrefix + "Authors", QLTVConsts.DbLibrarySchema);
                b.Property(s => s.NameAuthor).HasMaxLength(100).IsRequired(true);
                b.Property(s => s.DateOfBirth);
                b.Property(s => s.DescriptionAuthor).HasMaxLength(255).IsRequired(true);
                b.ConfigureByConvention();
            });

            builder.Entity<Reader>(b =>
            {
                b.ToTable(QLTVConsts.DbTablePrefix + "Readers", QLTVConsts.DbLibrarySchema);
                b.Property(s => s.NameReader).HasMaxLength(100).IsRequired(true);
                b.Property(s => s.Age);
                b.Property(s => s.Address).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.Phone).HasMaxLength(20).IsRequired(true);
                b.Property(s => s.Email).HasMaxLength(50);
                b.Property(s => s.IdCard).HasMaxLength(20).IsRequired(true);
                b.ConfigureByConvention();
            });

            builder.Entity<Block>(b =>
            {
                b.ToTable(QLTVConsts.DbTablePrefix + "Blocks", QLTVConsts.DbLibrarySchema);
                b.Property(s => s.NameBlock).HasMaxLength(20).IsRequired(true);
                b.Property(s => s.NumberBookInBlock).IsRequired(true);
                b.Property(s => s.Capacity).IsRequired(true);
                b.Property(s => s.AvailableSpace).IsRequired(true);
                b.ConfigureByConvention();
            });

            builder.Entity<Borrow>(b =>
            {
                b.ToTable(QLTVConsts.DbTablePrefix + "Borrows", QLTVConsts.DbLibrarySchema);
                b.Property(s => s.DateBorrow).IsRequired(true);
                b.Property(s => s.DateReturn).IsRequired(true);
                b.Property(s => s.IsReturnBook).IsRequired(true);
                b.HasOne(t => t.BookBorrow).WithMany(l => l.BookBorrows).HasForeignKey(t => t.IdBook);
                b.HasOne(t => t.ReaderBorrow).WithMany(l => l.ReaderBorrows).HasForeignKey(t => t.IdReader);
                b.ConfigureByConvention();
            });

            builder.Entity<Book>(b =>
            {
                b.ToTable(QLTVConsts.DbTablePrefix + "Books", QLTVConsts.DbLibrarySchema);
                b.Property(s => s.NameBook).HasMaxLength(100).IsRequired(true);
                b.Property(s => s.DatePublish);
                b.Property(s => s.Price);
                b.Property(s => s.NumberBook);
                b.HasOne(t => t.AuthorBook).WithMany(l => l.AuthorBooks).HasForeignKey(t => t.IdAuthor);
                b.HasOne(t => t.CategoryBook).WithMany(l => l.CategoryBooks).HasForeignKey(t => t.IdCategory);
                b.HasOne(t => t.BlockBook).WithMany(l => l.BlockBooks).HasForeignKey(t => t.IdBlock);
                b.ConfigureByConvention();
            });
        }
    }
}

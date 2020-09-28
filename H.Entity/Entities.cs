namespace H.Entity
{
    using H.Model;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class Entities : DbContext
    {

        public Entities() : base("name=JsDBs") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Types().Configure(f => f.ToTable("Js_" + f.ClrType.Name));
        }

        public DbSet<AZData> BAS_AZData { get; set; }
        public DbSet<Visitor> BAS_Visitor { get; set; }
        public DbSet<MCData> BAS_MCData { get; set; }
        public DbSet<IPSite> BAS_IPSite { get; set; }
        public DbSet<KSData> BAS_KSData { get; set; }
        public DbSet<Setting> BAS_Setting { get; set; }
    }


}
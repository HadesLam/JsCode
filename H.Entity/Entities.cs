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
    }


}
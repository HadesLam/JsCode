using System.Data.Entity;

namespace Entity
{
    [DbConfigurationType(typeof(DbContextConfiguration))]
    public class EntitiesLocator : Entities
    {
        static EntitiesLocator()
        {
            EntityFramework.Container container = new EntityFramework.Container();
            EntityFramework.Locator.RegisterDefaults(container);
            container.Register<EntityFramework.Batch.IBatchRunner>(() => new EntityFramework.Batch.MySqlBatchRunner());
            EntityFramework.Locator.SetContainer(container);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("");
        }
    }

    public class DbContextConfiguration : MySql.Data.Entity.MySqlEFConfiguration
    {
        public DbContextConfiguration()
        {
            EntityFramework.Locator.Current.Register<EntityFramework.Batch.IBatchRunner>(() => new EntityFramework.Batch.MySqlBatchRunner());
        }
    }
}
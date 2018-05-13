namespace AppCitas.Domain
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class DataContext : DbContext
    {
        #region Properties
        public DbSet<User> Users { get; set; }

        public DbSet<UserType> UserTypes { get; set; }
        #endregion

        #region Constructors
        public DataContext() : base("DefaultConnection")
        {
        }
        #endregion
    }
}

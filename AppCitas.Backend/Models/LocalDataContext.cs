namespace AppCitas.Backend.Models
{
    using Domain;

    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<AppCitas.Domain.User> Users { get; set; }

        public System.Data.Entity.DbSet<AppCitas.Domain.UserType> UserTypes { get; set; }
    }
}
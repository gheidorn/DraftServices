using System.Data.Entity;

namespace DraftServices.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }

    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
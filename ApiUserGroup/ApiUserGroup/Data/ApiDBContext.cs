using ApiUserGroup.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiUserGroup.Data
{
    //this is main context that will be use for handling the data between database
    public class ApiDBContext :DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }

        public DbSet<Group> groups { get; set; }
    }
}

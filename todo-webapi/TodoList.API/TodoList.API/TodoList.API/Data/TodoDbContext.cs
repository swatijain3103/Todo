using Microsoft.EntityFrameworkCore;
using TodoList.API.Models;

namespace TodoList.API.Data
// step 2 after models file
{
    public class TodoDbContext : DbContext // Dbcontext is comes from the entityframeworkcore usinf for db connections
    {
        public TodoDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Todo> Todos { get; set; }
    }
    // It is responsible for managing the connection to the database,
    // tracking changes to entities, and persisting those changes back into the database.
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiMain.Models
{
    public class ApiMainContext : IdentityDbContext
    {
        public DbSet<State> States { get; set; }
        public DbSet<Park> Parks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"server=localhost;userid=root;password=epicodus;port=3306;database=ApiMain;");

        public ApiMainContext(DbContextOptions options) : base(options)
        {

        }
        public ApiMainContext()
        {

        }
    }
}
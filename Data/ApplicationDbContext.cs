using Microsoft.EntityFrameworkCore;
using DearyDiary.Models;

namespace DearyDiary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<DiaryEntry> DiaryEntries { get; set; }
    }
}

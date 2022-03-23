using Microsoft.EntityFrameworkCore;

namespace TestOneToOne.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Student> Student { get; set; }

        public DbSet<Address> Address { get; set; }
/*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Address)
                .WithOne(a => a.Student)
                .HasForeignKey<Address>(Ab => Ab.StudentId);
        }
        */
    }

}

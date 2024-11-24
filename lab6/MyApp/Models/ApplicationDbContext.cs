using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<RefCustomerType> RefCustomerTypes { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<EndUser> EndUsers { get; set; }
    public DbSet<CustomerMachine> CustomerMachines { get; set; }
    public DbSet<Distributor> Distributors { get; set; }
    public DbSet<ServiceVendor> ServiceVendors { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<RefMachineType> RefMachineTypes { get; set; }
    public DbSet<RefServiceType> RefServiceTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RefCustomerType>().ToTable("RefCustomerTypes");
        modelBuilder.Entity<Customer>().ToTable("Customers");
        modelBuilder.Entity<EndUser>().ToTable("EndUsers");
        modelBuilder.Entity<CustomerMachine>().ToTable("CustomerMachines");
        modelBuilder.Entity<Distributor>().ToTable("Distributors");
        modelBuilder.Entity<ServiceVendor>().ToTable("ServiceVendors");
        modelBuilder.Entity<Company>().ToTable("Companies");
        modelBuilder.Entity<Address>().ToTable("Addresses");
        modelBuilder.Entity<RefMachineType>().ToTable("RefMachineTypes");
        modelBuilder.Entity<RefServiceType>().ToTable("RefServiceTypes");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("YourSqlServerConnectionString");
        // optionsBuilder.UseNpgsql("YourPostgresConnectionString");
        // optionsBuilder.UseSqlite("Data Source=yourdatabase.db");
        // optionsBuilder.UseInMemoryDatabase("InMemoryDb");
    }
}
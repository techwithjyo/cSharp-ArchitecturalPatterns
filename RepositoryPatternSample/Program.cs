using Microsoft.Extensions.DependencyInjection;
using RepositoryPatternSample.Data;
using RepositoryPatternSample.Entities;
using RepositoryPatternSample.Interfaces;
using RepositoryPatternSample.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer; // Add this using directive

Console.WriteLine("Hello, World!");

var serviceCollection = new ServiceCollection();
var connectionString = "Server=(localdb)\\mssqllocaldb;Database=CustomerDb;Trusted_Connection=True;MultipleActiveResultSets=true";

serviceCollection.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();

var serviceProvider = serviceCollection.BuildServiceProvider();

// Ensure database is created
using (var scope = serviceProvider.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await context.Database.MigrateAsync();
}

// Test repository
using (var scope = serviceProvider.CreateScope())
{
    var repository = scope.ServiceProvider.GetRequiredService<ICustomerRepository>();

    // Add a customer
    var customer = new Customer
    {
        Name = "John Doe",
        Email = "john@example.com",
        IsActive = true,
        CreatedAt = DateTime.UtcNow
    };

    await repository.AddAsync(customer);
    Console.WriteLine($"Added customer with ID: {customer.Id}");

    // Get all customers
    var customers = await repository.GetAllAsync();
    foreach (var c in customers)
    {
        Console.WriteLine($"Customer: {c.Name}, Email: {c.Email}");
    }
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
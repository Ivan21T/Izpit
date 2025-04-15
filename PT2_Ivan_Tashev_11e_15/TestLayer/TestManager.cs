using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
namespace TestingLayer;
[TestFixture]
public class TestManager
{
    internal static AppDbContext dbContext;

    static TestManager()
    {
        DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        builder.UseInMemoryDatabase("TestDb");
        dbContext = new AppDbContext(builder.Options);
    }

    [OneTimeTearDown]
    public void Dispose()
    {
        dbContext.Dispose();
    }
}

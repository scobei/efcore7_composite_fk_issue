using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using test.Data;

var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>();
optionsBuilder.UseNpgsql("...")
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging();

using (var db = new TestDbContext(optionsBuilder.Options))
{
    var entity = db.SubTables.SingleOrDefault(x => x.SubId == 1);
    Console.WriteLine($"SubId: {entity!.SubId}, BaseTypeId: {entity!.BaseTypeId}");
}
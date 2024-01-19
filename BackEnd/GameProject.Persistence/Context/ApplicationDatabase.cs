using Microsoft.EntityFrameworkCore;

namespace GameProject.Persistence.Context;

public class ApplicationDatabase : DbContext
{
    public ApplicationDatabase(DbContextOptions options) : base(options)
    { }
}
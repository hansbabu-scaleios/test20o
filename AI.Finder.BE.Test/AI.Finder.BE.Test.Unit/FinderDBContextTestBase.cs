using System;
using AI.Finder.BE.Service;
using Microsoft.EntityFrameworkCore;

namespace AI.Finder.BE.Test.Unit
{
    public class FinderDBContextTestBase : IDisposable
    {
        protected readonly FinderDbContext context;
        public FinderDBContextTestBase()
        {
            var options = new DbContextOptionsBuilder<FinderDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
             .Options;
            context = new FinderDbContext(options);
            context.Database.EnsureCreated();
        }
        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
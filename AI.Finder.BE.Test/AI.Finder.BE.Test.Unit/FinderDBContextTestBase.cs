using System;
using AI.Finder.BE.Service;
using Microsoft.EntityFrameworkCore;

namespace AI.Finder.BE.Test.Unit
{
    public class FinderDBContextTestBase : IDisposable
    {
        protected readonly FinderDbContext _context;
        public FinderDBContextTestBase()
        {
            var options = new DbContextOptionsBuilder<FinderDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
             .Options;
            _context = new FinderDbContext(options);
            _context.Database.EnsureCreated();
        }
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
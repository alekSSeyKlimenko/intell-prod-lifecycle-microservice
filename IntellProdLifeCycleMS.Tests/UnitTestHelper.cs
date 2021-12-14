using IntellProdLifeCycleMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IntellProdLifeCycleMS.Tests
{
    public class UnitTestHelper
    {
        private readonly AppDbContext _context;
        public UnitTestHelper()
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
           

            var dbContextOptions = builder.Options;
            _context = new AppDbContext(dbContextOptions);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public IPRepository IPRepository
        {
            get
            {
                return new IPRepository(_context);
            }
        }
    }
}

using LMS.Data;
using LMS.Models;
using LMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories
{
    public class BorrowerRepository : IBorrowerRepository
    {
        private readonly AppdbContext _context;
        public BorrowerRepository(AppdbContext context)
        {
            _context = context;
        }
        public async Task<int> AddBorrowerAsync(Borrower borrower)
        {
            await _context.Borrowers.AddAsync(borrower);
            return borrower.Id;
        }

        public async Task DeleteBorrowerAsync(Borrower borrower)
        {
            _context.Borrowers.Remove(borrower);
        }

        public async Task<List<Borrower>> GetAllBorrowersAsync()
        {
            return await _context.Borrowers
                .Include(b => b.Book)
                .Include(b => b.Member)
                .ToListAsync();
        }

        public async Task<Borrower> GetBorrowerByIdAsync(int id)
        {
            return await _context.Borrowers
               .Include(b => b.Book)
               .Include(b => b.Member)
               .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateBorrowerAsync(Borrower borrower)
        {
            _context.Borrowers.Update(borrower);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

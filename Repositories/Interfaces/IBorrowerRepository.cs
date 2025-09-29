using LMS.Models;

namespace LMS.Repositories.Interfaces
{
    public interface IBorrowerRepository
    {
        Task<List<Borrower>> GetAllBorrowersAsync();
        Task<int> AddBorrowerAsync(Borrower borrower);
        Task UpdateBorrowerAsync(Borrower borrower);
        Task DeleteBorrowerAsync(Borrower borrower);
        Task<Borrower> GetBorrowerByIdAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}

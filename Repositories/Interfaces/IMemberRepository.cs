using LMS.Models;

namespace LMS.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetAllMembers();
        Task<int> AddMemberAsync(Member member);
        Task UpdateMemberAsync(Member member);
        Task DeleteMemberAsync(Member member);
        Task<Member> GetMemberByIdAsync(int id);
    }
}

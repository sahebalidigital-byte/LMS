using LMS.Data;
using LMS.Models;
using LMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppdbContext _context;
        public MemberRepository(AppdbContext context)
        {
            _context = context;
        }
        public async Task<int> AddMemberAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return member.Id;
        }

        public async Task DeleteMemberAsync(Member member)
        {
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Member>> GetAllMembers()
        {
            return await _context.Members
              .Include(m => m.Borrowers)
              .ToListAsync();
        }

        public async Task<Member> GetMemberByIdAsync(int id)
        {
            return await _context.Members
              .Include(m => m.Borrowers)
              .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateMemberAsync(Member member)
        {
            _context.Entry(member).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

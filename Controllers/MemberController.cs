using AutoMapper;
using LMS.DTOs.Member;
using LMS.Models;
using LMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        public MemberController(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetAll()
        {
            var members = await _memberRepository.GetAllMembers();
            return Ok(_mapper.Map<IEnumerable<MemberDto>>(members));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetById(int id)
        {
            var member = await _memberRepository.GetMemberByIdAsync(id);
            if (member == null) return NotFound();
            return Ok(_mapper.Map<MemberDto>(member));
        }

        [HttpPost]
        public async Task<ActionResult<Member>> Create([FromBody] Member member)
        {
            var id = await _memberRepository.AddMemberAsync(member);
            return CreatedAtAction(nameof(GetById), new { id, controller = "member" }, _mapper.Map<MemberDto>(member));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateMemberDto updateMemberDto)
        {

            var member = await _memberRepository.GetMemberByIdAsync(id);
            _mapper.Map(updateMemberDto, member);
            await _memberRepository.UpdateMemberAsync(member);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _memberRepository.GetMemberByIdAsync(id);
            if (member == null) return NotFound();

            await _memberRepository.DeleteMemberAsync(member);
            return NoContent();
        }
    }
}

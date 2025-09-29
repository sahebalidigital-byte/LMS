using AutoMapper;
using LMS.DTOs.Borrower;
using LMS.Models;
using LMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowerController : ControllerBase
    {
        private readonly IBorrowerRepository _borrowerRepository;
        private readonly IMapper _mapper;
        public BorrowerController(IBorrowerRepository borrowerRepository, IMapper mapper)
        {
            _borrowerRepository = borrowerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Borrower>>> GetAll()
        {
            var borrows = await _borrowerRepository.GetAllBorrowersAsync();
            return Ok(_mapper.Map<IEnumerable<BorrowerReadDto>>(borrows));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Borrower>> GetById(int id)
        {
            var borrow = await _borrowerRepository.GetBorrowerByIdAsync(id);
            if (borrow == null) return NotFound();
            return Ok(_mapper.Map<BorrowerReadDto>(borrow));
        }
        [HttpPost]
        public async Task<ActionResult<Borrower>> Create(BorrowerCreateDto dto)
        {
            var borrow = _mapper.Map<Borrower>(dto);
            await _borrowerRepository.AddBorrowerAsync(borrow);
            await _borrowerRepository.SaveChangesAsync();

            var readDto = _mapper.Map<BorrowerReadDto>(borrow);
            return CreatedAtAction(nameof(GetById), new { id = borrow.Id, controller = "borrower" }, "Borrower Created Successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BorrowerUpdateDto dto)
        {
            var borrow = await _borrowerRepository.GetBorrowerByIdAsync(id);
            if (borrow == null) return NotFound();

            _mapper.Map(dto, borrow);
            await _borrowerRepository.UpdateBorrowerAsync(borrow);
            await _borrowerRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var borrow = await _borrowerRepository.GetBorrowerByIdAsync(id);
            if (borrow == null) return NotFound();

            await _borrowerRepository.DeleteBorrowerAsync(borrow);
            await _borrowerRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}

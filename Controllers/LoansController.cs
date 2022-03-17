#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanWebAPI.Models;
using LoanWebAPI.Repository;
using AutoMapper;
using LoanWebAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace LoanWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoansController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<LoanDTO>>> GetLoans()
        {
            var results = await _unitOfWork.LoanRepository.FindAll();
            return _mapper.Map<IEnumerable<LoanDTO>>(results).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDTO>> GetLoan(int id)
        {
            var loan = await _unitOfWork.LoanRepository.FindById(id);
            if (loan == null)
            {
                return NotFound();
            }

            return _mapper.Map<LoanDTO>(loan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, LoanDTO loanDto)
        {
            if (id != loanDto.Id)
            {
                return BadRequest();
            }

            try
            {
                var loanFromDb = await _unitOfWork.LoanRepository.FindById(id);
                var loan = _mapper.Map(loanDto, loanFromDb);
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return StatusCode(200);
        }

        [HttpPost]
        public async Task<ActionResult<Loan>> PostLoan(LoanDTO loanDto)
        {
            var loan = _mapper.Map<Loan>(loanDto);

            await _unitOfWork.LoanRepository.Add(loan);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction("GetLoan", new { id = loanDto.Id }, loanDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var loan = await _unitOfWork.LoanRepository.FindById(id);

            if (loan == null)
            {
                return NotFound();
            }

            await _unitOfWork.LoanRepository.Delete(loan);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}

using AutoMapper;
using LoanWebAPI.Models;
using LoanWebAPI.Models.DTO;

namespace LoanWebAPI.Utils
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Loan, LoanDTO>().ReverseMap();
        }
    }
}

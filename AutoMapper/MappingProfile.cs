using LMS.DTOs.Member;
using LMS.Models;
using AutoMapper;
using LMS.DTOs.Borrower;

namespace LMS.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberDto>();
            CreateMap<CreateMemberDto, Member>();
            CreateMap<UpdateMemberDto, Member>();

            CreateMap<Borrower, BorrowerReadDto>()
               .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Name))
               .ForMember(dest => dest.MemberName, opt => opt.MapFrom(src => src.Member.Name));

            CreateMap<BorrowerCreateDto, Borrower>();
            CreateMap<BorrowerUpdateDto, Borrower>();

        }

    }
}

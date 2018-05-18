using AutoMapper;
using BlogAsp.BLL.DTO;
using Task1ASP.Models.Login;

namespace Task1ASP.Infrastructure.Mapper
{
    public class ViewModelToDto : Profile
    {
        public ViewModelToDto()
        {
            CreateMap<LoginVm, LoginDto>();
        }
    }
}
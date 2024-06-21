using AutoMapper;
using ZStore_BLL.DTO;
using ZStore_BLL.Models;

namespace ZStore_API.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}

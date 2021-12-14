using AutoMapper;
using DataAccess.Models;
using LojaReal.Models;
using System.Collections.Generic;

namespace LojaReal.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProdutoModel, Produto>().ReverseMap();
        }
    }
}

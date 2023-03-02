using AutoMapper;
using Market.Application.Common.Mapping;
using Market.Application.Products.Queries.GetProductList;
using Market.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetTypeList
{
    public class TypeListDto : IMapWith<TypeOfProduct>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TypeOfProduct, TypeListDto>()
                .ForMember(typeDto => typeDto.Id,
                opt => opt.MapFrom(type => type.Id))
                 .ForMember(typeDto => typeDto.Name,
                opt => opt.MapFrom(type => type.Name));
        }
    }
}

using AutoMapper;
using Market.Application.Common.Mapping;
using Market.Application.Products.Queries.GetTypeList;
using Market.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Queries.Factories.GetFactoryList
{
    public class FactoryListDto : IMapWith<Factory>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string Img { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Factory, FactoryListDto>()
                .ForMember(factoryDto => factoryDto.Id,
                opt => opt.MapFrom(factory => factory.Id))
                 .ForMember(factoryDto => factoryDto.Name,
                opt => opt.MapFrom(factory => factory.Name))
                  .ForMember(factoryDto => factoryDto.Address,
                opt => opt.MapFrom(factory => factory.Address))
                   .ForMember(factoryDto => factoryDto.Img,
                opt => opt.MapFrom(factory => factory.Img));
        }
    }
}

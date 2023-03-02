using AutoMapper;
using Market.Application.Common.Mapping;
using Market.Application.Products.Queries.GetProductDetails;
using Market.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Queries.Products.GetProductDetails
{
    public class ProductFactoryVm : IMapWith<Factory>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Factory, ProductFactoryVm>()
                .ForMember(typeVm => typeVm.Name,
                opt => opt.MapFrom(type => type.Name));
        }
    }
}

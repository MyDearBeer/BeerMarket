using AutoMapper;
using Market.Application.Common.Mapping;
using Market.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductDetails
{
    public class ProductTypeVm : IMapWith<TypeOfProduct>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TypeOfProduct, ProductTypeVm>()
                .ForMember(typeVm => typeVm.Name,
                opt => opt.MapFrom(type => type.Name));
        }
    }
}

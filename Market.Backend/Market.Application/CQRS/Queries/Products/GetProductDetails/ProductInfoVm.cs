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
    public class ProductInfoVm : IMapWith<ProductInfo>
    {
        public string Title { get; set; }
        public string Value { get; set; }

        public void Mapping(Profile profile)
    {
        profile.CreateMap<ProductInfo, ProductInfoVm>()
            .ForMember(infoVm => infoVm.Title,
            opt => opt.MapFrom(info => info.Title))
            .ForMember(infoVm => infoVm.Value,
            opt => opt.MapFrom(info => info.Value));
        }
}
}

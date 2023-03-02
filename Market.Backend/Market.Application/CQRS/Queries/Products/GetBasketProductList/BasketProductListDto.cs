using AutoMapper;
using Market.Application.Common.Mapping;
using Market.Application.Products.Queries.GetProductList;
using Market.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Queries.Products.GetBasketProductList
{
    public class BasketProductListDto : IMapWith<BasketProduct>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public ProductLookupDto Product { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BasketProduct, BasketProductListDto>()
                .ForMember(bpVm => bpVm.Id,
                opt => opt.MapFrom(bp => bp.Id))
                .ForMember(bpVm => bpVm.ProductId,
                opt => opt.MapFrom(bp => bp.ProductId))
                .ForMember(bpVm => bpVm.Product,
                opt => opt.MapFrom(bp => bp.Product));
        }
    }
}

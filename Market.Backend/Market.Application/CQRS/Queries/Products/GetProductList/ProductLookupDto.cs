using AutoMapper;
using Market.Application.Common.Mapping;
using Market.Application.Products.Queries.GetProductDetails;
using Market.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductList
{
    public class ProductLookupDto : IMapWith<Product>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal? Rating { get; set; }

        public int Price { get; set; }

        public string? Img { get; set; }

       // public TypeOfProduct? Type { get; set; }





        //public TypeOfProduct? TypeName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductLookupDto>()
                .ForMember(productDto => productDto.Name,
                opt => opt.MapFrom(product => product.Name))
                 .ForMember(productDto => productDto.Rating,
                opt => opt.MapFrom(product => product.Rating))
                .ForMember(productDto => productDto.Price,
                opt => opt.MapFrom(product => product.Price))
                .ForMember(productDto => productDto.Id,
                opt => opt.MapFrom(product => product.Id))
                .ForMember(productDto => productDto.Img,
                opt => opt.MapFrom(product => product.Img))
               // .ForMember(productDto => productDto.Type.Name,
               // opt => opt.MapFrom(product => product.Type))
                 ;
        }
    }
}

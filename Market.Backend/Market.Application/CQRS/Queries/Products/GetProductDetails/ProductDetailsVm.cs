
using AutoMapper;
using Market.Application.Common.Mapping;
using Market.Application.CQRS.Queries.Products.GetProductDetails;
using Market.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductDetails
{
    public class ProductDetailsVm : IMapWith<Product>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal? Rating { get; set; }

        public int Price { get; set; }

        public string? Img { get; set; }

        // public Guid FactoryId { get; set; }

     //   public TypeOfProduct? Type { get; set; }

        public string? Description { get; set; }

        public ProductTypeVm Type { get; set; }
        public ProductFactoryVm Factory { get; set; }
        public ICollection<ProductInfoVm>? Info { get; set; } = new List<ProductInfoVm>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDetailsVm>()
                .ForMember(productVm => productVm.Name,
                opt => opt.MapFrom(product => product.Name))
                .ForMember(productVm => productVm.Rating,
                opt => opt.MapFrom(product => product.Rating))
                .ForMember(productVm => productVm.Price,
                opt => opt.MapFrom(product => product.Price))
                .ForMember(productVm => productVm.Id,
                opt => opt.MapFrom(product => product.Id))
                .ForMember(productVm => productVm.Img,
                opt => opt.MapFrom(product => product.Img))
                .ForMember(productVm => productVm.Description,
                opt => opt.MapFrom(product => product.Description))
                .ForMember(productVm => productVm.Type,
                opt => opt.MapFrom(product => product.Type))
                .ForMember(productVm => productVm.Factory,
                opt => opt.MapFrom(product => product.Factory))
                .ForMember(productVm => productVm.Info,
                opt => opt.MapFrom(product => product.Info))
                ;
        }

        }
   
}

using AutoMapper;
using Inventory.Entities.DTOs;
using Inventory.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Product
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductCreateDto>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductUpdateDto>();
            CreateMap<ProductStockDto, Product>();
            CreateMap<Product, ProductStockDto>();

            //Movement
            CreateMap<MovementCreateDto, Movement>();
            CreateMap<Movement, MovementCreateDto>();
        }
    }
}

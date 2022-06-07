using AutoMapper;
using Inventory.Contracts.Repository;
using Inventory.Core.Handlers;
using Inventory.DataAccess.Context;
using Inventory.Entities.DTOs;
using Inventory.Entities.Entities;
using Inventory.Entities.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Inventory.Core.V1
{
    public class ProductCore
    {
        private readonly IProductRepository _context;
        private readonly ILogger<Product> _logger;
        private readonly ErrorHandler<Product> _errorHandler;
        private readonly IMapper _mapper;

        public ProductCore(ILogger<Product> logger, IMapper mapper, IProductRepository context)
        {
            _logger = logger;
            _errorHandler = new ErrorHandler<Product>(logger);
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseService<List<Product>>> GetProductsAsync()
        {
            try
            {
                var response = await _context.GetAllAsync();
                return new ResponseService<List<Product>>(false, response.Count == 0 ? "No records found" : $"{response.Count} records found", HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetProductsAsync", new List<Product>());
            }
        }
        public async Task<ResponseService<Product>> GetProductByIdAsync(int id)
        {
            try
            {
                var response = await _context.GetByIdAsync(id);
                return new ResponseService<Product>(false, response == null ? "No records found" : "Records found", HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetProductsAsync", new Product());
            }
        }
        public async Task<ResponseService<Product>> UpdateProductAsync(int id,ProductUpdateDto product)
        {
            try
            {

                Product updateProduct = await _context.GetByIdAsync(id);
                //updateProduct=_mapper.Map<Product>(product);
                updateProduct.Unit = product.Unit;
                updateProduct.Status = product.Status;
                updateProduct.Barcode = product.Barcode;
                updateProduct.Description = product.Description;
                var response = await _context.UpdateAsync(updateProduct);
                return new ResponseService<Product>(false, response.Item2 == true ? "Record updated!" : "Record not updated", HttpStatusCode.OK, response.Item1);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "UpdateProductAsync", new Product());
            }
        }
        public async Task<bool> UpdateProductStockAsync(int id,int qty, int type)
        {
            Product product = await _context.GetByIdAsync(id);
            if (type == 1)
            {
                product.Stock += qty;
            }
            else if (type == -1)
            {
                if(product.Stock > 0)
                {
                    product.Stock -= qty;
                }
                else
                {
                    throw new Exception("Not enough to make action");
                }
            }
            var response=await _context.UpdateAsync(product);
            return response.Item2;
        }
        public async Task<ResponseService<Product>> AddProductAsync(ProductCreateDto product)
        {
            try
            {
                Product newProduct = _mapper.Map<Product>(product);
                var response = await _context.AddAsync(newProduct);
                return new ResponseService<Product>(false, response == null ? "No records found" : "Records found", HttpStatusCode.OK, response.Item1);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "AddProductAsync", new Product());
            }
        }
        public async Task<ResponseService<List<ProductStockDto>>> GetStockAsync()
        {
            try
            {
                var response = await _context.GetAllAsync();
                List<ProductStockDto> stockProducts = _mapper.Map<List<ProductStockDto>>(response);
                return new ResponseService<List<ProductStockDto>>(false, stockProducts.Count == 0 ? "No records found" : $"{stockProducts.Count} records found", HttpStatusCode.OK, stockProducts);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetStockProductsAsync", new List<ProductStockDto>());
            }
        }
        public async Task<ResponseService<ProductStockDto>> GetStockByIdAsync(int id)
        {
            try
            {
                var response = await _context.GetByIdAsync(id);
                ProductStockDto stockProducts = _mapper.Map<ProductStockDto>(response);
                return new ResponseService<ProductStockDto>(false, stockProducts == null ? "No records found" : "Record found", HttpStatusCode.OK, stockProducts);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetStockProductsAsync", new ProductStockDto());
            }
        }
    }
}

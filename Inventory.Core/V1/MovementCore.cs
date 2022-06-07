using AutoMapper;
using Inventory.Contracts.Repository;
using Inventory.Core.Handlers;
using Inventory.Entities.DTOs;
using Inventory.Entities.Entities;
using Inventory.Entities.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Inventory.Core.V1
{
    public class MovementCore
    {
        private readonly IMovementRepository _context;
        private readonly ProductCore _productCore;
        private readonly ILogger<Movement> _logger;
        private readonly ErrorHandler<Movement> _errorHandler;
        private readonly IMapper _mapper;

        public MovementCore(ILogger<Movement> logger, IMapper mapper, IMovementRepository context,IProductRepository productContext, ILogger<Product> productLogger)
        {
            _logger = logger;
            _errorHandler = new ErrorHandler<Movement>(logger);
            _context = context;
            _mapper = mapper;
            _productCore = new(productLogger, mapper,productContext);
        }

        public async Task<ResponseService<List<Movement>>> GetMovementsAsync()
        {
            try
            {
                var response = await _context.GetAllAsync();
                return new ResponseService<List<Movement>>(false, response.Count == 0 ? "No records found" : $"{response.Count} records found", HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetMovementsAsync", new List<Movement>());
            }
        }
        public async Task<ResponseService<Movement>> AddMovementAsync(MovementCreateDto movement)
        {
            try
            {
                Movement newMovement = _mapper.Map<Movement>(movement);
                
                await _productCore.UpdateProductStockAsync(movement.IdProduct,movement.Qty,movement.Type);
                
                var response = await _context.AddAsync(newMovement);
                return new ResponseService<Movement>(false, response == null ? "No records found" : "Movement created", HttpStatusCode.OK, response.Item1);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "AddProductAsync", new Movement());
            }
        }
    }
}

using Inventory.Contracts.Generics;
using Inventory.Entities.Entities;

namespace Inventory.Contracts.Repository
{
    public interface IProductRepository: IGenericActionDbAddUpdate<Product>,IGenericActionDbQuery<Product>
    {
    }
}

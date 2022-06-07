using Inventory.Contracts.Generics;
using Inventory.Entities.Entities;

namespace Inventory.Contracts.Repository
{
    public interface IMovementRepository : IGenericActionDbAddUpdate<Movement>, IGenericActionDbQuery<Movement>
    {

    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogs.Entities;

namespace Catalogs.Repositories
{
    public interface IInMemItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}

using Realm_.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Realm_.Repositories
{
    public interface IItemRepository
    {
        Task AddItems(IList<ItemDataModel> items);

        IList<ItemDataModel> SearchItems(string text);

        int Count();
    }
}
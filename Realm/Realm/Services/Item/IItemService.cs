using Realm_.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Realm_.Services.Item
{
    public interface IItemService
    {
        Task LoadItemsAsync();

        IList<ItemDataModel> Search(string text);

        int Count();
    }
}

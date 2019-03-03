using Realm_.DataModels;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Realm_.Repositories
{
    public class ItemRepository : IItemRepository
    {
        #region --IItemRepository--

        public async Task AddItems(IList<ItemDataModel> items)
        {
            var realm = Realm.GetInstance();
            await realm.WriteAsync(tempRealm =>
            {
                foreach (var item in items)
                {
                    tempRealm.Add(item);
                }
            });
        }

        public int Count()
        {
            var realm = Realm.GetInstance();

            return realm.All<ItemDataModel>().Count();
        }

        public IList<ItemDataModel> SearchItems(string text)
        {
            var realm = Realm.GetInstance();

            return realm.All<ItemDataModel>().Where(i=>i.Name.Contains(text, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        #endregion

    }
}
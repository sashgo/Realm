using Realm_.DataModels;
using Realm_.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Realm_.Services.Item
{
    public class ItemService : IItemService
    {
        private int _count;
        private const int COUNT_LOAD = 100000;
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
            _count = Count();
        }

        #region --IItemService--

        public async Task LoadItemsAsync()
        {
            var result = new List<ItemDataModel>();
            var date = DateTime.Now;

            for (int i = 0; i < COUNT_LOAD; i++)
            {
                _count++;
                var name = $"Item_{date.ToString("hh_mm_ss")}_{i}";
                result.Add(new ItemDataModel() { Id = _count, Name = name});
            }
            try
            {
                await _itemRepository.AddItems(result);
            }
            catch (Exception ex)
            {
            }
        }

        public IList<ItemDataModel> Search(string text)
        {
            return _itemRepository.SearchItems(text);
        }

        public int Count()
        {
            return _itemRepository.Count();
        }

        #endregion

    }
}
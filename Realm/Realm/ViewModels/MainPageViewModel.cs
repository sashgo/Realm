using Prism.Commands;
using Prism.Navigation;
using Realm_.DataModels;
using Realm_.Services.Item;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Realm_.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IItemService _itemService;

        public MainPageViewModel(INavigationService navigationService,
            IItemService itemService)
            : base(navigationService)
        {
            Title = "Main Page";
            _itemService = itemService;
        }

        #region --Public properties--

        private ObservableCollection<ItemDataModel> _items;
        public ObservableCollection<ItemDataModel> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private int _count;
        public int Count
        {
            get { return _count; }
            set { SetProperty(ref _count, value); }
        }

        private ICommand _loadItemsCommand;
        public ICommand LoadItemsCommand
        {
            get { return _loadItemsCommand ?? (_loadItemsCommand = new DelegateCommand(() => OnLoadItemsCommand())); }
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get { return _searchCommand ?? (_searchCommand = new DelegateCommand(() => OnSearchCommand())); }
        }

        #endregion

        #region --Overrides--

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            Count = _itemService.Count();
        }

        #endregion

        #region --Private helpers--

        private async void OnLoadItemsCommand()
        {
            await _itemService.LoadItemsAsync();
            Count = _itemService.Count();
        }

        private void OnSearchCommand()
        {
            var resp = _itemService.Search(Text);
            if (resp != null)
            {
                Items = new ObservableCollection<ItemDataModel>(resp);
            }
        }

        #endregion
    }
}

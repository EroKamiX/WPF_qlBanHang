using DataGrid.Commands;
using DataGrid.Store;
using DataGrid.ViewModels.ProductViewModel;
using System;
using System.Windows.Input;

namespace DataGrid.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public ICommand CommandCategoryIndex { get; }
        public ICommand NagvigateHomeCommand { get; }
        public ICommand CommandProductIndex { get; }
        public ICommand CommandTopicIndex { get; }
        public ICommand CommandPostIndex { get; }
        public ICommand CommandOrderIndex { get; }
        public ICommand CommandUserIndex { get; }

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            CommandCategoryIndex = new NavigateCommand<CategoryModels>(navigationStore, () => new CategoryModels(navigationStore));
            CommandProductIndex = new NavigateCommand<ProductModels>(navigationStore, () => new ProductModels(navigationStore));
            CommandTopicIndex = new NavigateCommand<TopicViewModel.View>(navigationStore, () => new TopicViewModel.View(navigationStore));
            CommandPostIndex = new NavigateCommand<PostViewModel.View>(navigationStore, () => new PostViewModel.View(navigationStore));
            CommandOrderIndex = new NavigateCommand<OrderViewModel.View>(navigationStore, () => new OrderViewModel.View(navigationStore));
            CommandUserIndex = new NavigateCommand<UserViewModel.View>(navigationStore, () => new UserViewModel.View(navigationStore));
            NagvigateHomeCommand = new NavigateCommand<ViewTwoModels>(navigationStore, () => new ViewTwoModels(navigationStore));
        }

        private void OnCurrentViewModelChanged()
        {
            OnChanged(nameof(CurrentViewModel));
        }
    }
}

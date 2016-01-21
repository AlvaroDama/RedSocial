using System;
using RedSocial.ViewModel.Base;
using Xamarin.Forms;

namespace RedSocial.Factory
{
    public interface IViewFactory
    {
        void Register<TViewModel, TView>() where TViewModel: class, IViewModel 
            where TView:Page;

        Page Resolve<TViewModel>(Action<TViewModel> action = null) 
            where TViewModel : class, IViewModel;

        Page Resolve<TViewModel>(out TViewModel viewModel, 
            Action<TViewModel> action = null) where TViewModel : class, IViewModel;

        Page Resolve<TViewModel>(TViewModel viewModel) 
            where TViewModel : class, IViewModel;
    }
}

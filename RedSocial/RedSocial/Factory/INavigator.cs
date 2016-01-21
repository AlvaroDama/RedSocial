﻿using System;
using System.Threading.Tasks;
using RedSocial.ViewModel.Base;

namespace RedSocial.Factory
{
    public interface INavigator
    {
        //eliminar
        Task<IViewModel> PopAsync();
        Task<IViewModel> PopModalAsync();
        Task PopToRootAsync();

        //añadir
        Task<TViewModel> PushAsync<TViewModel>(Action<TViewModel> action = null) 
            where TViewModel:class, IViewModel;
        Task<TViewModel> PushAsync<TViewModel>(TViewModel viewModel) 
            where TViewModel : class, IViewModel;
        Task<TViewModel> PushModalAsync<TViewModel>(Action<TViewModel> action = null) 
            where TViewModel : class, IViewModel;
        Task<TViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) 
            where TViewModel : class, IViewModel;

    }
}

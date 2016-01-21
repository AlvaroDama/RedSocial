using RedSocial.Factory;
using RedSocial.Service;
using RedSocial.ViewModel.Base;

namespace RedSocial.ViewModel
{
    public class GeneralViewModel:ViewModelBase
    {
        protected INavigator _navigator;
        protected IServicioDatos _servicio;

        public GeneralViewModel(INavigator navigator, IServicioDatos servicio)
        {
            _servicio = servicio;
            _navigator = navigator;
        }
    }
}

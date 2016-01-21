using System;
using System.Windows.Input;
using RedSocial.Factory;
using RedSocial.Model;
using RedSocial.Resources;
using RedSocial.Service;
using Xamarin.Forms;

namespace RedSocial.ViewModel
{
    public class LoginViewModel:GeneralViewModel
    {
        private User _login = new User();

        public string LoginLabel { get { return Resources.Strings.Login; } }
        public string RegisterLabel { get { return Strings.NewUser; } }
        public string PassLabel { get { return Strings.Password; } }
        public string UserNameLabel { get; set; } = Strings.UserName;

        public ICommand CmdLogin { get; set; }
        public ICommand CmdAlta { get; set; }
        
        public User User
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }

        public LoginViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
            CmdLogin = new Command(IniciarSesion);
            CmdAlta = new Command(NuevoUser);
            
        }

        private async void NuevoUser()
        {
            //await _navigator.PopToRootAsync();
            await _navigator.PushModalAsync<RegistroViewModel>(viewModel =>
            {
                Titulo = "Nuevo Usuario";
            });
        }

        private async void IniciarSesion()
        {
            var page = new Page();
            try
            {
                IsBusy = true;
                var us = await _servicio.ValidarUsuario(_login);

                if (us != null)
                {
                    await _navigator.PopToRootAsync();
                    await _navigator.PushAsync<ContactosViewModel>(viewModel =>
                    {
                        Titulo = "Inicio de sesión";
                    });
                }
                else
                {
                    var xx = ""; //para comprobar que se haga bien.
                }

                //TODO: aquí navegaríamos a la pantalla principal o daríamos error
                await page.DisplayAlert(Strings.Error, Strings.UserDoesNotExist, Strings.Ok);
            }
            catch (Exception e)
            {
                await page.DisplayAlert(Strings.Error, e.Message, Strings.Ok);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

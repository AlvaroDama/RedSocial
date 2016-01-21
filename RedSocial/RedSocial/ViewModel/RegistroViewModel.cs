using System;
using System.Windows.Input;
using RedSocial.Factory;
using RedSocial.Model;
using RedSocial.Resources;
using RedSocial.Service;
using Xamarin.Forms;

namespace RedSocial.ViewModel
{
    public class RegistroViewModel:GeneralViewModel
    {
        public ICommand CmdAlta { get; set; }

        public User User
        {
            get{return _user;}
            set{SetProperty(ref _user, value);}
        }

        private User _user = new User();

        public string LoginLabel { get; set; } = Strings.Login;
        public string PassLabel { get; set; } = Strings.Password;
        public string NameLabel { get; set; } = Strings.Name;
        public string LastNameLabel { get; set; } = Strings.LastName;
        public string NewUserLabel { get; set; } = Strings.NewUser;


        public RegistroViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
            CmdAlta = new Command(GuardarUser);
        }

        private async void GuardarUser()
        {
            _user.Avatar = "";
            var page = new Page();
            try
            {
                IsBusy = true;
                var r = await _servicio.AddUsuario(_user);
                if (r != null)
                {
                    await page.DisplayAlert(Strings.UserCreatedTitle, 
                        Strings.UserCreatedText, Strings.Ok);
                    await _navigator.PushModalAsync<LoginViewModel>();
                }
                else
                {
                    var a = "";
                }
            }
            catch (Exception e)
            {
                
                await page.DisplayAlert(Strings.Error, Strings.UserAlreadyText, Strings.Ok);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

using System;
using Autofac;
using RedSocial.Service;
using RedSocial.View;
using RedSocial.ViewModel;
using Xamarin.Forms;

namespace RedSocial.Module
{
    public class RedSocialModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServicioDatosImpl>().As<IServicioDatos>().SingleInstance();

            builder.RegisterType<Login>();
            builder.RegisterType<LoginViewModel>();

            builder.RegisterType<Contactos>();
            builder.RegisterType<ContactosViewModel>();

            builder.RegisterType<Registro>();
            builder.RegisterType<RegistroViewModel>();

            builder.RegisterInstance<Func<Page>>(() =>
            {
                var masterP = Application.Current.MainPage as MasterDetailPage;
                var page = masterP != null ? masterP.Detail : Application.Current.MainPage;

                var navigation = page as IPageContainer<Page>;

                return navigation != null ? navigation.CurrentPage : page;
            });
        }
    }
}

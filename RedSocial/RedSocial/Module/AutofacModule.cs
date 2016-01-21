using Autofac;
using RedSocial.Factory;
using Xamarin.Forms;

namespace RedSocial.Module
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance(); //singleton

            builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();

            builder.Register(ctx => Application.Current.MainPage.Navigation).SingleInstance();
        }
    }
}

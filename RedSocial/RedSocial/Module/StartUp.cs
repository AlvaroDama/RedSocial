using Autofac;
using RedSocial.Factory;
using RedSocial.View;
using RedSocial.ViewModel;
using Xamarin.Forms;


namespace RedSocial.Module
{
    public class StartUp:AutofacBootstrapper
    {
        private readonly App _app;

        public StartUp(App app)
        {
            _app = app;
        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<RedSocialModule>();
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<LoginViewModel, Login>();
            viewFactory.Register<ContactosViewModel, Contactos>();
            viewFactory.Register<RegistroViewModel, Registro>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();
            var main = viewFactory.Resolve<LoginViewModel>();
            var navPage = new NavigationPage(main); //pone la barra de navegación
            _app.MainPage = navPage;
        }
    }
}

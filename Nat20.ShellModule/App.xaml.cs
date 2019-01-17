using Nat20.ShellModule.ViewModels;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace Nat20.ShellModule
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IShellViewModel, ShellViewModel>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var catalog = base.CreateModuleCatalog();

            catalog.AddModule<CharacterAttributeModule.CharacterAttributeModule>();

            return catalog;
        }
    }
}

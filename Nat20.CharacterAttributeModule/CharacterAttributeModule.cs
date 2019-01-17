using Nat20.CharacterAttributeModule.ViewModels;
using Nat20.CharacterAttributeModule.Views;
using Nat20.RegionsModule;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Nat20.CharacterAttributeModule
{
    public class CharacterAttributeModule : IModule
    {
        private IRegionManager regionManager;

        public CharacterAttributeModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            regionManager.RegisterViewWithRegion(Regions.CharacterRegion, () => containerProvider.Resolve<ICharacterAttributeView>());
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ICharacterAttributeViewModel, CharacterAttributeViewModel>();
            containerRegistry.Register<ICharacterAttributeView, CharacterAttributeView>();
        }
    }
}

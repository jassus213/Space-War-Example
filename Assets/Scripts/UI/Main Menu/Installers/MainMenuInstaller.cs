using UI.Main_Menu.Signals;
using UI.Signals;
using Zenject;

namespace UI.Main_Menu.Installers.Installers
{
    public class MainMenuInstaller : Installer<MainMenuInstaller>
    {
        public override void InstallBindings()
        {
            #region Presenter

            Container.BindInterfacesAndSelfTo<MainMenuPresenter>().AsSingle();

            #endregion

            #region Signals

            Container.DeclareSignal<MenuSignals.OpenMainMenu>().OptionalSubscriber();
            Container.DeclareSignal<MenuSignals.CloseMainMenu>().OptionalSubscriber();

            #endregion
        }
    }
}
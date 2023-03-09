using DefaultNamespace.UI.Settings;
using UI.Signals;
using Zenject;

namespace UI.Settings.Installers
{
    public class SettingsInstaller : Installer<SettingsInstaller>
    {
        public override void InstallBindings()
        {
            #region Presenter

            Container.BindInterfacesAndSelfTo<SettingPresenter>().AsSingle();

            #endregion

            #region Signals

            Container.DeclareSignal<SettingsSignals.OpenSettings>().OptionalSubscriber();
            Container.DeclareSignal<SettingsSignals.CloseSettings>().OptionalSubscriber();

            #endregion

        }
    }
}
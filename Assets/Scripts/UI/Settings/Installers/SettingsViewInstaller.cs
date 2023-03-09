using UI.Settings.Installers;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.UI.Settings.Installers
{
    public class SettingsViewInstaller : MonoInstaller
    {
        [SerializeField] private SettingsView settingsView;
        public override void InstallBindings()
        {
            SettingsInstaller.Install(Container);
            
            Container.BindInterfacesAndSelfTo<SettingsView>().FromInstance(settingsView).AsSingle();
        }
    }
}
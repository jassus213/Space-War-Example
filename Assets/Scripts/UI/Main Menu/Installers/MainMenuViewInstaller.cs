using UnityEngine;
using Zenject;

namespace UI.Main_Menu.Installers.Installers
{
    public class MainMenuViewInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuView mainMenuView;
        public override void InstallBindings()
        {
            MainMenuInstaller.Install(Container);
            
            Container.BindInterfacesAndSelfTo<MainMenuView>().FromInstance(mainMenuView);
        }
    }
}
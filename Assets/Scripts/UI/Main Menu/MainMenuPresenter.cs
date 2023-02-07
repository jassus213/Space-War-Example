using Common;
using UI.Signals;
using UnityEngine;
using Zenject;

namespace UI.Main_Menu.Installers
{
    public class MainMenuPresenter : IMainMenuPresenter, IInitializable
    {
        private readonly IMainMenuView _view;
        private readonly SignalBus _signalBus;

        public MainMenuPresenter(IMainMenuView view, SignalBus signalBus)
        {
            _view = view;
            _signalBus = signalBus;
        }

        public void StartNewGame()
        {
            SceneLoader.LoadScene(ScenesInfo.GameScene);
        }

        public void LoadGame()
        {
            Debug.Log("Works");
        }
        
        public void OpenSettings()
        {
            _signalBus.TryFire<MenuSignals.OpenSettings>();
        }

        public void Exit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif

            Application.Quit();
        }

        public void Initialize()
        {
            _view.SetPresenter(this);
        }
    }
}
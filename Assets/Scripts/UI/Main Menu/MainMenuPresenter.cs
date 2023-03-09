using System;
using Common;
using DefaultNamespace.Signals;
using UI.Main_Menu.Installers;
using UI.Main_Menu.Interfaces;
using UI.Main_Menu.Signals;
using UI.Signals;
using UnityEngine;
using Zenject;

namespace UI.Main_Menu
{
    public class MainMenuPresenter : IMainMenuPresenter, IInitializable, IDisposable
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
            _signalBus.TryFire(new LevelSignals.StartLevel {LevelIndex = ScenesInfo.GameScene});
        }

        public void LoadGame()
        {
            Debug.Log("Works");
        }
        
        public void OpenSettings()
        {
            _signalBus.TryFire<SettingsSignals.OpenSettings>();
            _view.Show(false);
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
            
            _signalBus.Subscribe<MenuSignals.OpenMainMenu>(OpenMainMenuCallBack);
        }

        private void OpenMainMenuCallBack(MenuSignals.OpenMainMenu args)
        {
            _view.Show(true);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<MenuSignals.OpenMainMenu>(OpenMainMenuCallBack);
        }
    }
}
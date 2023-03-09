using System;
using DefaultNamespace.UI.Settings.Interfaces;
using UI.Main_Menu.Interfaces;
using UI.Main_Menu.Signals;
using UI.Signals;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.UI.Settings
{
    public class SettingPresenter : ISettingPresenter, IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly ISettingView _settingView;
                
        public SettingPresenter(ISettingView settingView, SignalBus signalBus)
        {
            _settingView = settingView;
            _signalBus = signalBus;
        }

        public void BackToMainMenu()
        {
            _signalBus.TryFire<SettingsSignals.CloseSettings>();
            _signalBus.TryFire<MenuSignals.OpenMainMenu>();
            _settingView.Show(false);   
        }

        public void Initialize()
        { 
            _settingView.SetPresenter(this);
            
            _signalBus.Subscribe<SettingsSignals.OpenSettings>(OpenSettingsCallBack);
        }

        private void OpenSettingsCallBack(SettingsSignals.OpenSettings args)
        {
            Debug.Log("CallBack Settings");
            _settingView.Show(true);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<SettingsSignals.OpenSettings>(OpenSettingsCallBack);
        }
    }
}
using DefaultNamespace.UI.Settings.Interfaces;
using UnityEngine;
using UnityEngine.UI;


public class SettingsView : MonoBehaviour, ISettingView
{
    private ISettingPresenter _presenter;
    
    [SerializeField] private Button backButton;
    public void SetPresenter(ISettingPresenter presenter)
    {
        _presenter = presenter;
        
        backButton.onClick.AddListener(_presenter.BackToMainMenu);
    }

    public void Show(bool value)
    {
        gameObject.SetActive(value);
    }
}


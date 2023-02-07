using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Main_Menu.Installers
{
    public class MainMenuView : MonoBehaviour, IMainMenuView, IInitializable
    {
        [Header("Buttons")] [SerializeField] private Button newGameButton;
        [SerializeField] private Button settings;
        [SerializeField] private Button loadGameButton;
        [SerializeField] private Button exitGameButton;
        

        private IMainMenuPresenter _presenter;

        public void Initialize()
        {
            newGameButton.onClick.AddListener(_presenter.StartNewGame);
            settings.onClick.AddListener(_presenter.OpenSettings);
            loadGameButton.onClick.AddListener(_presenter.LoadGame);
            exitGameButton.onClick.AddListener(_presenter.Exit);
        }

        public void SetPresenter(IMainMenuPresenter presenter)
        {
            _presenter = presenter;
        }
    }
}
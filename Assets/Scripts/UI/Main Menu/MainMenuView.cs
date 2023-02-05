using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Main_Menu.Installers
{
    public class MainMenuView : MonoBehaviour, IMainMenuView
    {
        [Header("Buttons")] 
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button loadGameButton;
        [SerializeField] private Button exitGameButton;

        private readonly IMainMenuPresenter _presenter;

        public MainMenuView(IMainMenuPresenter presenter)
        {
            _presenter = presenter;


            newGameButton.onClick.AddListener(_presenter.StartNewGame);
            loadGameButton.onClick.AddListener(_presenter.LoadGame);
            exitGameButton.onClick.AddListener(_presenter.StartNewGame);
        }
    }
}
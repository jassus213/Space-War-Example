using Common;
using UnityEngine;

namespace UI.Main_Menu.Installers
{
    public class MainMenuPresenter : IMainMenuPresenter
    {
        public void StartNewGame()
        {
            SceneLoader.LoadScene(ScenesInfo.GameScene);
        }

        public void LoadGame()
        {
            Debug.Log("Works");
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
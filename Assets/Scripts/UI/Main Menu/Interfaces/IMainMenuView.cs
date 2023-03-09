using UI.Common.Interfaces;
using UI.Main_Menu.Installers;

namespace UI.Main_Menu.Interfaces
{
    public interface IMainMenuView : IHavePresenter<IMainMenuPresenter>, IView
    {
    }
}
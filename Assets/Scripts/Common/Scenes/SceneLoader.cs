using UnityEngine.SceneManagement;

namespace Common
{
    public static class SceneLoader
    {
        public static void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}
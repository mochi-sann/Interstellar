using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Planet.Generate.Game
{
    public class MultiSceneManager : IInitializable
    {
        public MultiSceneManager()
        {
            Debug.Log("Init");
        }

        public void Initialize()
        {
            Debug.Log("Main");
            SceneManager.LoadScene("Main", LoadSceneMode.Additive);
        }

        public void AddScene()
        {
            
        }
    }
}

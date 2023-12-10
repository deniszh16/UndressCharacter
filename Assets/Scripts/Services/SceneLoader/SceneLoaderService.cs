using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.SceneLoader
{
    public class SceneLoaderService : MonoBehaviour, ISceneLoaderService
    {
        [Header("Экран затемнения")]
        [SerializeField] private CanvasGroup _blackout;

        public void LoadSceneAsync(Scenes scene, bool screensaver, float delay) =>
            _ = StartCoroutine(LoadSceneAsyncCoroutine(scene.ToString(), screensaver, delay));

        private IEnumerator LoadSceneAsyncCoroutine(string scene, bool screensaver, float delay)
        {
            yield return new WaitForSeconds(delay);

            if (screensaver)
            {
                _blackout.blocksRaycasts = true;
                _blackout.alpha = 1f;
            }

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);
            while (asyncOperation.isDone != true)
                yield return null;

            if (screensaver)
            {
                _blackout.blocksRaycasts = false;
                _blackout.alpha = 0;
            }
        }
    }
}
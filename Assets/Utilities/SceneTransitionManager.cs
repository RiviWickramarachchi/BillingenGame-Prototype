using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : Singleton<SceneTransitionManager>
{
    private AsyncOperation sceneAsync;

    public void GoToScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }
    
    private IEnumerator LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);

        SceneManager.sceneLoaded += (newScene, mode) =>
        {
            SceneManager.SetActiveScene(newScene);
        };

        Scene sceneToLoad = SceneManager.GetSceneByName(sceneName);

        yield return null;
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneInitializer : MonoBehaviour
{
    [Header("Dependencies")]
    public SceneSO[] scenes;

    [Header("Unity Events")]
    public UnityEvent onDependenciesLoaded;

    private void Start()
    {
        StartCoroutine(LoadDependencies());
    }

    private IEnumerator LoadDependencies()
    {
        for (int i = 0; i < scenes.Length; i++)
        {
            SceneSO sceneToLoad = scenes[i];

            if (SceneManager.GetSceneByName(sceneToLoad.name).isLoaded == false)
            {
                var loadOperation = SceneManager.LoadSceneAsync(sceneToLoad.name, LoadSceneMode.Additive);

                while (loadOperation.isDone == false)
                {
                    yield return null;
                }
            }
        }

        if (onDependenciesLoaded != null)
            onDependenciesLoaded.Invoke();
    }

}

using UnityEngine;
using ScriptableObjectArchitecture;

public class SceneLoader : MonoBehaviour
{
    [Header("Configuration")]
    public SceneSO sceneToLoad;
    public bool loadingScreen;

    [Header("Broadcasting Events")]
    public LoadSceneRequestGameEvent loadSceneEvent;

    public void LoadScene()
    {
        var request = new LoadSceneRequest(
            scene: sceneToLoad,
            loadingScreen: loadingScreen
        );

        loadSceneEvent.Raise(request);
    }
}

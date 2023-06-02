using UnityEngine;

[CreateAssetMenu(fileName = "NewPath", menuName = "Scriptable Objects/Path")]
public class PlayerPathSO : ScriptableObject
{
    public Transform path;

    public void ResetPath()
    {
        path = null;
    }

    private void OnDisable()
    {
        path = null;
    }
}

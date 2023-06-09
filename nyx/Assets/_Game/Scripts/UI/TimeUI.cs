using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    [Header("Dependencies")]
    public TextMeshProUGUI timeTxt;

    public void SetupHUD(string time)
    {
        timeTxt.text = time;
    }
}

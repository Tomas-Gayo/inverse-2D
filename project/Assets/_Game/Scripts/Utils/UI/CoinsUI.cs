using UnityEngine;
using TMPro;

public class CoinsUI : MonoBehaviour
{
    [Header("Dependencies")]
    public TextMeshProUGUI coinsTxt;

    public void SetupHUD(string coins)
    {
        coinsTxt.text = "x " + coins; ;
    }
}

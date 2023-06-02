using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [Header("Dependencies")]
    public CoinsUI coinsUI;

    // Private reference
    private int totalCoins;         // Total coins collected by the user

    public void SumCoin()
    {
        totalCoins++;
    }

    private void Update()
    {
        coinsUI.SetupHUD(totalCoins.ToString("#00"));
    }

}

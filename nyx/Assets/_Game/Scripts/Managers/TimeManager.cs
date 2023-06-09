//using UnityEngine;
//using ScriptableObjectArchitecture;

//public class TimeManager : MonoBehaviour
//{
//    [Header("Configuration")]
//    public float countdown;
//    [Header("Dependencies")]
//    public TimeUI timeUI;
//    [Header("Broadcasting on Channels")]
//    public GameEvent onPlayerDead;

//    private void Update()
//    {
//        if (countdown > 0)
//            timeUI.SetupHUD(Countdown());
//        else
//            onPlayerDead.Raise();
//    }

//    private string Countdown()
//    {
//        countdown -= Time.deltaTime;
//        float seconds = Mathf.FloorToInt(countdown);
//        return seconds.ToString();
//    }
//}

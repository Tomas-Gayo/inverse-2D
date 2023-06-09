//using System.Collections;
//using UnityEngine;
//using UnityEngine.Events;
//using ScriptableObjectArchitecture;

//public class CoinCollision : MonoBehaviour
//{
//    [Header("Configuration")]
//    public float timeBeforeDestroy;

//    [Header("Unity Events")]
//    public UnityEvent OnPicked;

//    [Header("Broadcasting on")]
//    public GameEvent itemPicked;

//    // Private reference
//    private bool isCollected;

//    private void Start()
//    {
//        isCollected = false;
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Player") && !isCollected)
//        {
//            isCollected = true;

//            if (OnPicked != null)
//                OnPicked.Invoke();

//            itemPicked.Raise();

//            StartCoroutine(DestroyCoin());
//        }
//    }

//    private IEnumerator DestroyCoin()
//    {
//        yield return new WaitForSeconds(timeBeforeDestroy);

//        Destroy(gameObject);
//    }
//}

//using UnityEngine;
//using ScriptableObjectArchitecture;

//[RequireComponent(typeof(Animator))]
//public class LoadingScreenUI : MonoBehaviour
//{
//    [Header("Broadcasting on channels")]
//    public BoolGameEvent loadingScreenToggled;

//    // Private dependencies
//    private Animator animator;

//    private void Awake()
//    {
//        animator = GetComponent<Animator>();
//    }

//    public void ToggleScreen(bool enable)
//    {
//        if (enable)
//            animator.SetTrigger("Show");
//        else
//            animator.SetTrigger("Hide");
//    }

//    public void SendLoadingScreenShownEvent()
//    {
//        loadingScreenToggled.Raise(true);
//    }

//    public void SendLoadingScreenHiddenEvent()
//    {
//        loadingScreenToggled.Raise(false);
//    }
//}

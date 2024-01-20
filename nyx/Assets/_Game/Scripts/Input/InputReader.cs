using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Scriptable Objects/InputReader")]
public class InputReader : ScriptableObject, PlayerInputs.IGameplayActions
{
    public event UnityAction<float> MoveEvent = delegate { };
    public event UnityAction JumpStartedEvent = delegate { };
    public event UnityAction JumpCanceledEvent = delegate { };
    public event UnityAction DashStartedEvent = delegate { };
    public event UnityAction DashCanceledEvent = delegate { };
    public event UnityAction AttackEvent = delegate { };

    PlayerInputs playerInputs;

    private void OnEnable()
    {
        if(playerInputs == null)
        {
            playerInputs = new PlayerInputs();

            playerInputs.Gameplay.SetCallbacks(this);
            playerInputs.Gameplay.Enable();
        }
    }

    private void OnDisable()
    {
        playerInputs.Gameplay.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent.Invoke(context.ReadValue<Vector2>().normalized.x);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                JumpStartedEvent.Invoke();
                break;
            case InputActionPhase.Canceled:
                JumpCanceledEvent.Invoke();
                break;
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                DashStartedEvent.Invoke();
                break;
            case InputActionPhase.Canceled:
                DashCanceledEvent.Invoke();
                break;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            AttackEvent.Invoke();
        }
    }


}

using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;
[CreateAssetMenu(fileName = "New Input Reader", menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, IPlayerActions

{
    public Action<bool> PrimaryFireEvent;
    public Action<Vector2> MoveEvent;
    private Controls controls;
    public Vector2 AimPosition { get; private set; }
  

    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this);
        }
        controls.Player.Enable();
    }
    void IPlayerActions.OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    void IPlayerActions.OnPrimaryFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PrimaryFireEvent?.Invoke(true);
        }
        else if (context.canceled) 
        {
            PrimaryFireEvent?.Invoke(false);

        }


    }
    public void OnAim(InputAction.CallbackContext context)
    {
        AimPosition=context.ReadValue<Vector2>();
    }
}

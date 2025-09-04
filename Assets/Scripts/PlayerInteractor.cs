using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    public event Action OnInteract;    // creating new interact event for player

    // function to run when user presses interact key
    public void InteractPerformed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnInteract?.Invoke();    // invoke the event
        }
    }
}

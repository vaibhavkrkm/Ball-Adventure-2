using UnityEngine;
using UnityEngine.InputSystem;

public class BallSwitcher : MonoBehaviour
{
    private LevelManager levelManager;

    private void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
    }

    public void SwitchBallPerformed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            levelManager.EnableBallSwitcherUI();
        }
    }
}

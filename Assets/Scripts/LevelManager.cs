using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // UI elements
    public GameObject pauseUI;
    public GameObject helpUI;
    public TMP_Text helpText;
    public GameObject freeBallUI;
    public TMP_Text freeBallText;
    public GameObject ballSwitcherUI;
    public Transform ballsMenuTransform;

    public GameObject player;
    private BallCageManager ballCage;
    private PlayerInput playerInput;
    private PlayerBallLoader playerBallLoader;

    private void Awake()
    {
        playerInput = player.GetComponent<PlayerInput>();
        playerBallLoader = player.GetComponent<PlayerBallLoader>();
    }

    public void CancelPerformed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (pauseUI.activeInHierarchy)
            {
                ContinueButtonPressed();
            }
            else if (helpUI.activeInHierarchy)
            {
                HelpOkButtonPressed();
            }
            else if (ballSwitcherUI.activeInHierarchy)
            {
                BallSwitcherCloseButtonPressed();
            }
        }
    }

    public void PauseButtonPressed()
    {
        Time.timeScale = 0;
        playerInput.SwitchCurrentActionMap("UI");
        pauseUI.SetActive(true);
    }

    public void ContinueButtonPressed()
    {
        pauseUI.SetActive(false);
        playerInput.SwitchCurrentActionMap("Player");
        Time.timeScale = 1;
    }

    public void HelpOkButtonPressed()
    {
        helpUI.SetActive(false);
        playerInput.SwitchCurrentActionMap("Player");
        Time.timeScale = 1;
    }

    public void BallSwitcherCloseButtonPressed()
    {
        ballSwitcherUI.SetActive(false);
        playerInput.SwitchCurrentActionMap("Player");
        Time.timeScale = 1;
    }

    public void FreeBallButtonPressed()
    {
        Animator ballCageAnimator = ballCage.gameObject.GetComponent<Animator>();
        freeBallUI.SetActive(false);
        Global.UnlockBall(ballCage.ballName);
        ballCageAnimator.SetBool("CageDestroyed", true);    // change this to play animation
        ballCage = null;
        playerInput.SwitchCurrentActionMap("Player");
        Time.timeScale = 1;
    }

    public void EnableHelpUI(string helpString)
    {
        Time.timeScale = 0;
        playerInput.SwitchCurrentActionMap("UI");
        helpText.text = helpString;
        helpUI.SetActive(true);
    }

    public void EnableFreeBallUI(BallCageManager ballCageManager)
    {
        Time.timeScale = 0;
        playerInput.SwitchCurrentActionMap("UI");
        ballCage = ballCageManager;
        freeBallText.text = ballCage.freeBallStoryline;
        freeBallUI.SetActive(true);
    }

    public void EnableBallSwitcherUI()
    {
        RefreshBallsStatus();
        Time.timeScale = 0;
        playerInput.SwitchCurrentActionMap("UI");
        ballSwitcherUI.SetActive(true);
    }

    private void RefreshBallsStatus()
    {
        foreach (Transform ball in ballsMenuTransform)
        {
            Transform lockedIcon = ball.Find("LockedIcon");
            Transform selectedIcon = ball.Find("SelectedIcon");
            Button selectButton = ball.GetComponentInChildren<Button>();

            lockedIcon.gameObject.SetActive(!Global.IsBallUnlocked(ball.name));
            selectButton.interactable = Global.IsBallUnlocked(ball.name);

            if (Global.selectedBall == ball.name)
            {
                selectedIcon.gameObject.SetActive(true);
                selectButton.enabled = false;
            }
            else
            {
                selectedIcon.gameObject.SetActive(false);
                selectButton.enabled = true;
            }
        }
    }

    public void SwitchBall(string ballName)
    {
        if (Global.IsBallUnlocked(ballName))
        {
            Global.selectedBall = ballName;
            playerBallLoader.LoadBall();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        playerInput.SwitchCurrentActionMap("UI");
        print("gameover");

        // trigger a gameover coroutine
    }
}

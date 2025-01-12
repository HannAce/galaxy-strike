using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private const string GameScene = "Game";
    private const string MainMenuScene = "MainMenu";
    [SerializeField] private Button m_startButton;
    [SerializeField] private Button m_exitButton;
    [SerializeField] private Button m_resumeButton;
    [SerializeField] private Button m_mainMenuButton;

    private GameManager m_gameManager;

    protected virtual void Start()
    {
        if (GameManager.Exists)
        {
            m_gameManager = GameManager.Instance;
        }

        if (m_startButton != null)
        {
            m_startButton.onClick.AddListener(HandleStartClicked);
        }

        if (m_exitButton != null)
        {
            m_exitButton.onClick.AddListener(HandleExitClicked);
        }

        if (m_resumeButton != null)
        {
            m_resumeButton.onClick.AddListener(HandleResumeClicked);
        }

        if (m_mainMenuButton != null)
        {
            m_mainMenuButton.onClick.AddListener(HandleMainMenuClicked);
        }
    }

    protected virtual void OnDestroy()
    {
        if (m_startButton != null)
        {
            m_startButton.onClick.RemoveListener(HandleStartClicked);
        }

        if (m_exitButton != null)
        {
            m_exitButton.onClick.RemoveListener(HandleExitClicked);
        }

        if (m_resumeButton != null)
        {
            m_resumeButton.onClick.RemoveListener(HandleResumeClicked);
        }

        if (m_mainMenuButton != null)
        {
            m_mainMenuButton.onClick.RemoveListener(HandleMainMenuClicked);
        }
    }

    private void HandleStartClicked()
    {
        SceneManager.LoadScene(GameScene); // Load game scene
    }

    private void HandleResumeClicked()
    {
        //GameManager.Instance.TogglePause(); for one off
        m_gameManager.TogglePause();
    }

    private void HandleMainMenuClicked()
    {
        SceneManager.LoadScene(MainMenuScene); // Return to main menu scene
    }

    private void HandleExitClicked()
    {
        //if (Application.isEditor)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        
#else
        Application.Quit();
#endif
        
    }
}

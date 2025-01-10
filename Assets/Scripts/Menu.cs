using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private const string GameScene = "Game";
    [SerializeField] private Button m_startButton;
    [SerializeField] private Button m_exitButton;
    
    void Start()
    {
        m_startButton.onClick.AddListener(HandleStartClicked);
        m_exitButton.onClick.AddListener(HandleExitClicked);
    }

    private void OnDestroy()
    {
        m_startButton.onClick.RemoveListener(HandleStartClicked);
        m_exitButton.onClick.RemoveListener(HandleExitClicked);
    }

    private void HandleStartClicked()
    {
        SceneManager.LoadScene(GameScene); // Load game scene
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

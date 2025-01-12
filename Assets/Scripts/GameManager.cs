using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField] private GameObject m_crosshairObject;
    [SerializeField] private GameObject m_menuObject;
    [SerializeField] private GameObject m_endGameMenuObject;
    [SerializeField] private GameObject m_gameOverMenuObject;
    private bool m_isPaused = false;

    // overriding Awake so able to use a Singleton
    protected override void Awake()
    {
        // need to call base.Awake otherwise it won't run Singleton code (press f12 on Awake if needed)
        base.Awake();
        if (m_menuObject == null)
        {
            Debug.LogError("MenuObject is null.");
        }

        if (m_crosshairObject == null)
        {
            Debug.LogError("CrosshairObject is null.");
        }
    }

    private void Start()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Pause))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        m_isPaused = !m_isPaused;
        
        // if (!m_isPaused)
        // {
        //     Time.timeScale = 0;
        //     m_isPaused = true;
        // }
        // else
        // {
        //     Time.timeScale = 1;
        //     m_isPaused = false;
        // } shorthand below, ternary operator
        
        Time.timeScale = m_isPaused ? 0 : 1;
        m_menuObject.SetActive(m_isPaused);
        m_crosshairObject.SetActive(!m_isPaused);
        Cursor.visible = m_isPaused;
    }

    public void ReloadLevel()
    {
        StartCoroutine(ReloadLevelRoutine());
    }
    public IEnumerator ReloadLevelRoutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGame(bool isWin)
    {
        if (isWin)
        {
            m_endGameMenuObject.SetActive(true);
        }
        else
        {
            m_gameOverMenuObject.SetActive(true);
        }
        
        Scoreboard.Instance.TrySetHighScore();
        Cursor.visible = true;
        Time.timeScale = 0;

    }
}

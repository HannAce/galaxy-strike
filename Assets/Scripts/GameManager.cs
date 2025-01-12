using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField] private GameObject crosshairObject;
    [SerializeField] private GameObject menuObject;
    private bool m_isPaused = false;

    // overriding Awake so able to use a Singleton
    protected override void Awake()
    {
        // need to call base.Awake otherwise it won't run Singleton code (press f12 on Awake if needed)
        base.Awake();
        if (menuObject == null)
        {
            Debug.LogError("MenuObject is null.");
        }

        if (crosshairObject == null)
        {
            Debug.LogError("CrosshairObject is null.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
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
        menuObject.SetActive(m_isPaused);
        crosshairObject.SetActive(!m_isPaused);
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
    
    
}

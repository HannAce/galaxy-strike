using System;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Start()
    {
        int noOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;

        if (noOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

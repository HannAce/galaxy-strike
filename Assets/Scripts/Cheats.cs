using UnityEngine;

public class Cheats : MonoBehaviour
{
    void Update()
    {
        // Press backspace to reset high score
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Scoreboard.Instance.ResetHighScore();
            Debug.Log("<color=yellow>Cheat activated:</color> High Score reset.");
        }
    }
}

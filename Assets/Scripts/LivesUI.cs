using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;

    private void Update()
    {
        int lives = PlayerStats.lives;
        string suffix = (lives == 1 ? "LIFE" : "LIVES");
        livesText.text = $"{lives} {suffix}";
    }
}

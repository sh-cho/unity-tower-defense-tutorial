using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    private void OnEnable()
    {
        roundsText.text = $"{PlayerStats.rounds}";
    }

    // -------------------------------------------------------------------------
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
    }
}

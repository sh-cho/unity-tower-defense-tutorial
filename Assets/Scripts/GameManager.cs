using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    public static bool gameIsOver;

    private void Start()
    {
        gameIsOver = false;
    }

    private void Update()
    {
        if (gameIsOver)
            return;

        // TODO: Remove before publish
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    //------------------------------------------------------------
    private void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }
}

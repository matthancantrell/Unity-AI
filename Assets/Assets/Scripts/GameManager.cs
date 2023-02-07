using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameOver = false;
    public float restartDelay;
    public RollerGameManager rgm;

    public void CompleteLevel()
    {
        Debug.Log("Level Complete!");
    }

    public void EndGame()
    {
        if (!gameOver) 
        {
            gameOver = true;
            Debug.Log("Game Over.");
            Invoke("Restart", restartDelay);
            //rgm.SetState(RollerGameManager.State.GAME_OVER);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

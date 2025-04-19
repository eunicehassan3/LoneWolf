using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void GoToMainGame(){
        SceneManager.LoadScene("MainGame");
    }

    public void GoToMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void GoToWin(){
        SceneManager.LoadScene("Win");
    }

    public void GoToGameOver(){
        SceneManager.LoadScene("GameOver");
    }

    public void GoToInstructions(){
        SceneManager.LoadScene("Instructions");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("Gameplay");
        
    }
    public void Tutorial(){
        SceneManager.LoadScene("Loading");
    }
    public void ExitGame(){
        Debug.Log("Has Quit");
        Application.Quit();
    }

    public void Gameover(){
        SceneManager.LoadScene("GameOver");
    }
    
}

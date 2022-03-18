
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  public void Restart()
    {
        //1-restart scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        //2-restart player s' position
        //Save the player 's initial position when game starts
        // When respawning simply reposition the player to that  init position


    }
}

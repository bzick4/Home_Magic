using UnityEngine;
using UnityEngine.SceneManagement;


public class ReloadScene : MonoBehaviour
{
   public void RestartLevel()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RestartLevel();
        
    }
}

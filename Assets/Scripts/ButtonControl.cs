using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    Scene currentScene;
    public bool paused = false;
    public void onPause()
    {

        if (paused == true)
        {
            Debug.Log("unpaused game");
            Time.timeScale = 1;
            paused = false;
        }
        else
        {
            Debug.Log("paused game");
            Time.timeScale = 0;
            paused = true;
        }
    }

    public void onRestart()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}

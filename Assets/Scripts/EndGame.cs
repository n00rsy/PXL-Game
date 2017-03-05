using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

public void onEnd()
    {
        Debug.Log("ended game");
        Application.Quit();
    }
}

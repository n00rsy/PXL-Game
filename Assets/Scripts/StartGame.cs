using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

public void onStart()
    {
        SceneManager.LoadScene("Game");
    }
}

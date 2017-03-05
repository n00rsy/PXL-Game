using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    Scene currentScene;

    [SerializeField]
    GameObject[] players;
    [SerializeField]
    GameObject[] textHolders;
    [SerializeField]
    string[] textColNames;
    TextManager[] messages;

    bool[] hit;

    void Start()
    {

        currentScene = SceneManager.GetActiveScene();

        messages = new TextManager[textHolders.Length];

        for (int i = 0; i < textHolders.Length; i++)
        {
            messages[i] = (TextManager)textHolders[i].GetComponent(typeof(TextManager));
        }

        hit = new bool[players.Length];

    }


    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        for (int e = 0; e < players.Length; e++)
        {
            hit[e] = players[e].GetComponent<OtherPlayers>().hitFinishLevel;
        }
            
            
            
        
        
        //bool two = Ptwo.GetComponent<OtherPlayers>().hitPlayer;
        Debug.Log("hit trigger");
        string otherTag = other.tag;
        string otherName = other.name;
        if (otherTag == "Death")
        {
            //Destroy(this.gameObject);
            SceneManager.LoadScene(currentScene.name);
        }

        if (otherName == textColNames[0])
        {
            Debug.Log("hit first collider");
            messages[0].TextOut();
        }
        if (otherName == textColNames[1])
        {
            Debug.Log("hit second collider");
            messages[1].TextIn();
        }

        if (otherTag == "FinishLevel")
        {
            Debug.Log("hit level end collider");
            bool isTrue = false;
            foreach (bool b in hit) {
                
                if (b==true)
                {
                    isTrue = true;
                }
                else
                {
                    isTrue = false;
                    Debug.Log("calling level finish text");
                    messages[2].TextIn();
                    //break;
                }

                if (isTrue) {
                    Debug.Log("finished level "+currentScene.name);
                    StartCoroutine("NextLevel");
                }
            }
            
        }
    }
    IEnumerator NextLevel()
    {
        float fadeTime = GameObject.Find("_GM").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("Game");
        //SceneManager.LoadScene("Game");
    }
}
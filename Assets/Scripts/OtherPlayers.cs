using UnityEngine;
using System.Collections;

public class OtherPlayers : MonoBehaviour
{

    public bool hitFinishLevel;
    bool hitPlayer = false;
    //PlayerFlashController flash;
    public GameObject flasher;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("hit trigger");
        
        if (other.tag == "FinishLevel")
        {
            hitFinishLevel = true;
        }
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collided with somethng");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit Player");
            if (!hitPlayer)
            {
                Debug.Log("calling makeflah");
                PlayerFlashController flash = flasher.GetComponent<PlayerFlashController>();
                flash.makeFlash();
                hitPlayer = true;
            }
        }
    }
}
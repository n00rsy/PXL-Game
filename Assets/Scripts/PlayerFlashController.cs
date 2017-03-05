using UnityEngine;
using System.Collections;

public class PlayerFlashController : MonoBehaviour {
    [SerializeField]
    SpriteRenderer renderer;
    [SerializeField]
    float startSize;
    [SerializeField]
    float endSize;
    [SerializeField]
    float scaleSpeed;
    [SerializeField]
    float fadeSpeed;
    Vector3 screenSize;
    AudioSource hitSound;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
        screenSize = Camera.main.WorldToScreenPoint(transform.position);
        //StartCoroutine(Flash());
        hitSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void makeFlash()
    {
        Debug.Log("makeflash called");
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        //yield return new WaitForSeconds(3);
        float s = 0f;
        float count = scaleSpeed;
        float alpha = 1f;
        Debug.Log("flashing");
        bool isBig = false;

        hitSound.Play();

        while (s <= endSize)
        {
            transform.localScale = new Vector2(s,s);
            //s = Mathf.Lerp(startSize, endSize, count);
            //count += Time.deltaTime;
            s += count;
            yield return new WaitForSeconds(0.001f);
            //yield return null;
            Debug.Log("scaling  " + s);
            
        }
        isBig = true;
        Debug.Log("finised size");
        if (isBig)
        {
            while (alpha <= 1 && alpha >= 0)
            {
                Debug.Log("fading");
                alpha -= fadeSpeed;
                this.renderer.material.color = new Color(1, 1, 1, alpha);
                yield return new WaitForSeconds(0.001f);
            }
        }
        yield return new WaitForSeconds(3);
        Destroy (this.gameObject);
    }
}

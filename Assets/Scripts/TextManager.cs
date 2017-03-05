using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    public float FadeoutTime;
    private Color startColor;
    private Color endColor;

    bool fadedin = false;
    bool fadedout = false;


    void Start()
    {
        startColor = GetComponent<Text>().color;
        endColor = startColor - new Color(0, 0, 0, 0);
        endColor = Color.blue;

    }

    public void TextOut()
    {
        Debug.Log("text fader works");
        StartCoroutine(TextFadeIn());
    }

    public void TextIn()
    {
        Debug.Log("text fader works");
        StartCoroutine(TextFadeOut());

    }


    IEnumerator TextFadeIn()
    {
        Debug.Log("textfade called");
        float a = 1F;
        if (fadedin == false) {
            for (int i = 0; i < 11; i++) {
                a = a - 0.1F;
                Color temp = GetComponent<Text>().color;
                temp.a = a;
                GetComponent<Text>().color = temp;
                yield return new WaitForSeconds(0.1F);
                if (a < 0)
                {
                    a = 0;
                    fadedin = true;
                }
            }
        }
    }

    IEnumerator TextFadeOut()
    {
        Debug.Log("textfade out called");
        float a = 0F;
        if (fadedout == false)
        {
            for (int i = 0; i < 10; i++)
            {
                a = a + 0.1F;
                Color temp = GetComponent<Text>().color;
                temp.a = a;
                GetComponent<Text>().color = temp;
                yield return new WaitForSeconds(0.1F);
                if (a > 1)
                {
                    a = 1;
                }
            }
            fadedout = true;
        }
    }
}

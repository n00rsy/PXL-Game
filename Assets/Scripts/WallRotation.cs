using UnityEngine;
using System.Collections;

public class WallRotation : MonoBehaviour {
    public float rotationSpeed;
    bool rendered = false;
    ButtonControl other;


    void Start () {
        GameObject holder = GameObject.Find("_GM");
        other = (ButtonControl)holder.GetComponent(typeof(ButtonControl));
	}
	
	// Update is called once per frame
	void Update () {
        //bool render = GetComponent<Renderer>().isVisible;
        bool pause = other.paused;
        if (rendered)
        {
            if (pause == false) {
                transform.Rotate(Vector3.forward * -rotationSpeed);
            }
        }

    }

    void OnBecameVisible()
    {
        rendered = true;
    }

    void OnBecameInisible()
    {
        rendered = false;
    }
}

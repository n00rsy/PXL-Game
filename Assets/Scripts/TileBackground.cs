using UnityEngine;
using System.Collections;

// @NOTE the attached sprite's position should be "top left" or the children will not align properly
// Strech out the image as you need in the sprite render, the following script will auto-correct it when rendered in the game
[RequireComponent(typeof(SpriteRenderer))]

// Generates a nice set of repeated sprites inside a streched sprite renderer
// @NOTE Vertical only, you can easily expand this to horizontal with a little tweaking
public class TileBackground : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField]
    Material wall1;

    void Awake()
    {

        wall1 = new Material(Shader.Find("Diffuse"));

        
        // Get the current sprite with an unscaled size
        sprite = GetComponent<SpriteRenderer>();
        Vector2 spriteSize = new Vector2(sprite.bounds.size.x / transform.localScale.x, sprite.bounds.size.y / transform.localScale.y);
        //sprite.material = wall1;
        
        // Generate a child prefab of the sprite renderer
        GameObject childPrefab = new GameObject();
        SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
        childSprite.GetComponent<SpriteRenderer>().material = wall1;
        childPrefab.transform.position = transform.position;
        childSprite.sprite = sprite.sprite;

        // Loop through and spit out repeated tiles
        GameObject child;

        
        for (int i = 1, l = (int)Mathf.Round(sprite.bounds.size.y); i < l; i++)
        {
            child = Instantiate(childPrefab) as GameObject;
            child.transform.localScale = new Vector2(1.5f, 2);
            child.transform.position = transform.position + (new Vector3(spriteSize.x, 0, 0) * i);
            child.transform.parent = transform;
            //child.GetComponent<SpriteRenderer>().material = wall1;
        }

        // Set the parent last on the prefab to prevent transform displacement
        childPrefab.transform.parent = transform;
        //childPrefab.GetComponent<SpriteRenderer>().material = wall1;

        // Disable the currently existing sprite component since its now a repeated image
        //sprite.material = wall1;
        sprite.enabled = false;
        
    }
}
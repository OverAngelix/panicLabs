using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceLauncher : MonoBehaviour
{
    public List<Sprite> diceSprites;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        int initFace = Random.Range(0, 6);
        spriteRenderer.sprite = diceSprites[initFace];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

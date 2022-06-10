using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAction : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private bool isSelected = false;
    private bool isHover = false;
    public Sprite start;
    public Sprite selected;
    public Sprite hover;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = start;
    }


    private void OnMouseEnter()
    {
        isHover = true;
        if (isSelected)
        {
            spriteRenderer.sprite = selected;
        }
        else
        {
            spriteRenderer.sprite = hover;
        }
    }

    private void OnMouseExit()
    {
        isHover = false;
        if (isSelected)
        {
            spriteRenderer.sprite = selected;
        }
        else
        {
            spriteRenderer.sprite = start;
        }
    }

    private void OnMouseDown()
    {
        if (isSelected == false && GameInformation.isPlayed == false)
        {
            spriteRenderer.sprite = selected;
            isSelected = !isSelected;
            GameInformation.isPlayed = !GameInformation.isPlayed;
        }
        else if (isSelected == true && GameInformation.isPlayed == true)
        {
            if (isHover)
            {
                spriteRenderer.sprite = hover;
            }
            else
            {
                spriteRenderer.sprite = start;
            }
            isSelected = !isSelected;
            GameInformation.isPlayed = !GameInformation.isPlayed;
        }
    }
}

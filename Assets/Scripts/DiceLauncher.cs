using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceLauncher : MonoBehaviour
{
    public List<Sprite> diceSprites;
    public string typeDice;
    private SpriteRenderer spriteRenderer;
    private int indexDice;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        indexDice = Random.Range(0, 6);
        spriteRenderer.sprite = diceSprites[indexDice];
        if (typeDice == "FORM")
        {
            FormLaunch();
        }
        if (typeDice == "COLOR")
        {
            ColorLaunch();
        }
        if (typeDice == "PATTERN")
        {
            PatternLaunch();
        }
        else if (typeDice == "LAB")
        {
            Labaunch();
        }
    }

    private void FormLaunch()
    {
        if (indexDice == 0 || indexDice == 2 || indexDice == 4)
        {
            //BLOB
            GameInformation.form = 'B';
        }
        else if (indexDice == 1 || indexDice == 3 || indexDice == 5)
        {
            //SNAIL
            GameInformation.form = 'S';
        }
    }

    private void PatternLaunch()
    {
        if (indexDice == 0 || indexDice == 2 || indexDice == 4)
        {
            //STRIPE
            GameInformation.pattern = 'S';
        }
        else if (indexDice == 1 || indexDice == 3 || indexDice == 5)
        {
            //POINT
            GameInformation.pattern = 'P';
        }
    }

    private void ColorLaunch()
    {
        if (indexDice == 0 || indexDice == 2 || indexDice == 4)
        {
            //BLUE
            GameInformation.color = 'B';
        }
        else if (indexDice == 1 || indexDice == 3 || indexDice == 5)
        {
            //RED
            GameInformation.color = 'R';
        }
    }

    private void Labaunch()
    {
        switch (indexDice)
        {
            case 0:
                GameInformation.lab = "BL";
                break;
            case 1:
                GameInformation.lab = "RD";
                break;
            case 2:
                GameInformation.lab = "YD";
                break;
            case 3:
                GameInformation.lab = "BD";
                break;
            case 4:
                GameInformation.lab = "RL";
                break;
            case 5:
                GameInformation.lab = "YL";
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }
}

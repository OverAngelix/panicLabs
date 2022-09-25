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
            Debug.Log(GameInformation.form);
        }
        if (typeDice == "COLOR")
        {
            ColorLaunch();
            Debug.Log(GameInformation.color);
        }
        if (typeDice == "PATTERN")
        {
            PatternLaunch();
            Debug.Log(GameInformation.pattern);
        }
        else if (typeDice == "LAB")
        {
            Labaunch();
            Debug.Log(GameInformation.lab);
        }
    }

    private void FormLaunch()
    {
        if (indexDice == 0 || indexDice == 2 || indexDice == 4)
        {
            GameInformation.form = "ALIEN";
        }
        else if (indexDice == 1 || indexDice == 3 || indexDice == 5)
        {
            GameInformation.form = "SNAIL";
        }
    }

    private void PatternLaunch()
    {
        if (indexDice == 0 || indexDice == 2 || indexDice == 4)
        {
            GameInformation.pattern = "STRIP";
        }
        else if (indexDice == 1 || indexDice == 3 || indexDice == 5)
        {
            GameInformation.pattern = "POINT";
        }
    }

    private void ColorLaunch()
    {
        if (indexDice == 0 || indexDice == 2 || indexDice == 4)
        {
            GameInformation.color = "BLUE";
        }
        else if (indexDice == 1 || indexDice == 3 || indexDice == 5)
        {
            GameInformation.color = "RED";
        }
    }

    private void Labaunch()
    {
        switch (indexDice)
        {
            case 0:
                GameInformation.lab = "BLL";
                break;
            case 1:
                GameInformation.lab = "RDL";
                break;
            case 2:
                GameInformation.lab = "YDL";
                break;
            case 3:
                GameInformation.lab = "BDL";
                break;
            case 4:
                GameInformation.lab = "RLL";
                break;
            case 5:
                GameInformation.lab = "YLL";
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }
}

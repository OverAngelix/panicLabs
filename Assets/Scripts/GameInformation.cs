using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameInformation : MonoBehaviour
{
    //PARAMETRE POUR UN JOUEUR
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public static bool isPlayed;
    public static string cardSelected;

    private int maxVents = 3;
    private int currentNbVent = 0;
    private int maxMutations = 4;
    private int currentMutation = 0;

    //PARAMETRE DU LANCER DE DÉS
    public static char form;
    public static char color;
    public static char pattern;
    public static string lab;

    public Dictionary<string, System.Action> mutations = new Dictionary<string, System.Action>();


    public static List<GameObject> listCards = new List<GameObject>();

    private CardPositionScript cardActions;

    private bool isFound = false;
    private int indexLab;
    private bool wayLab;
    // Start is called before the first frame update
    void Start()
    {
        mutations.Add("changePattern", changePattern);
        mutations.Add("changeColor", changeColor);
        mutations.Add("changeForm", changeForm);
        isPlayed = false;
        cardActions = this.GetComponent<CardPositionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            searchSolution();
        }
    }

    private void searchLaboratory()
    {
        switch (lab)
        {
            case "BL":
                indexLab = cardActions.searchCard("blueLab");
                wayLab = false;
                break;
            case "RD":
                indexLab = cardActions.searchCard("redLab");
                wayLab = true;
                break;
            case "YD":
                indexLab = cardActions.searchCard("yellowLab");
                wayLab = true;
                break;
            case "BD":
                indexLab = cardActions.searchCard("blueLab");
                wayLab = true;
                break;
            case "RL":
                indexLab = cardActions.searchCard("redLab");
                wayLab = false;
                break;
            case "YL":
                indexLab = cardActions.searchCard("yellowLab");
                wayLab = false;
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }


    private void searchSolution()
    {
        searchLaboratory();
        GameObject currentCard = null;
        string searchedTag = searchedTagString();
        int currentIndex = indexLab;
        int i = 0;
        while (!isFound && i < 30)
        {
            currentIndex = cardActions.getNextIdx(currentIndex, wayLab);
            currentCard = cardActions.getElement(currentIndex);

            //MUTATION (4eme mutation pour gagner)
            if (currentCard.tag == "Mutation" && currentMutation < maxMutations)
            {
                //utilisation d'un dictonaire
                mutations[currentCard.name]();
                searchedTag = searchedTagString();
                currentMutation++;
                if (currentMutation == 4)
                {
                    Debug.Log("FOUND !");
                    isFound = true;
                }
            }

            //VENT (3max apres ça compte plus)
            else if (currentCard.tag == "Vent" && currentNbVent < maxVents)
            {
                currentIndex = cardActions.searchNextVent(currentIndex, wayLab);
                currentNbVent++;
            }

            //CHECK CARD FOUND
            else if (currentCard.tag == searchedTag)
            {
                Debug.Log("FOUND !");
                isFound = true;
            }
            i++;
        }
        if (cardSelected == currentCard.name)
        {
            score++;
            scoreText.SetText("Score : " + score);
        }
        else
        {
            if (score == 0)
            {
                score--;
                scoreText.SetText("Score : " + score);
            }
        }

    }

    private string searchedTagString()
    {
        return color + "" + pattern + "" + form;
    }

    private void changePattern()
    {
        //condition ? vrai : faux
        pattern = pattern == 'P' ? 'S' : 'P';
    }

    private void changeForm()
    {
        form = form == 'S' ? 'B' : 'S';
    }

    private void changeColor()
    {
        color = color == 'B' ? 'R' : 'B';
    }
}

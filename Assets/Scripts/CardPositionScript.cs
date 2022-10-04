using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPositionScript : MonoBehaviour
{
    public List<GameObject> listCards;
    public List<GameObject> listSpawnCards;
    // Start is called before the first frame update
    void Start()
    {
       // while (IsCorrectlyShuffle)
       // {
            listCards = shuffleCards(listCards);
            for (int i = 0; i < listSpawnCards.Count; i++)
            {
                listCards[i].transform.position = listSpawnCards[i].transform.position;
            }
        IsCorrectlyShuffle(listCards);
    }

    // Update is called once per frame
    void Update()
    {
    }


    private List<GameObject> shuffleCards(List<GameObject> listCards)
    {
        List<GameObject> shuffleList = new List<GameObject>();

        for (int i = 0; i < listCards.Count; i++)
        {
            GameObject temp = listCards[i];
            int randomIndex = Random.Range(i, listCards.Count);
            listCards[i] = listCards[randomIndex];
            listCards[randomIndex] = temp;
            shuffleList.Add(listCards[i]);
        }
        return shuffleList;
    }


    private bool IsCorrectlyShuffle(List<GameObject> listCards)
    {
        for (int i = 0; i < listCards.Count; i++)
        {
            //SI LABS
            //SI VENTS
            //SI CHANGES


            if (getElement(listCards, i).tag=="RedLab" || getElement(listCards, i).tag == "BlueLab" || getElement(listCards, i).tag == "YellowLab")
            {
                if (getPreviousElement(listCards, i, true).tag == "RedLab" || getPreviousElement(listCards, i, true).tag == "BlueLab" || getPreviousElement(listCards, i, true).tag == "YellowLab" || getNextElement(listCards, i, true).tag == "RedLab" || getNextElement(listCards, i, true).tag == "BlueLab" || getNextElement(listCards, i, true).tag == "YellowLab")
                {
                    print("Coucouy");
                }
            }
           /* if (getElement(listCards, i).tag == "ChangeColor" || getElement(listCards, i).tag == "ChangeForm" || getElement(listCards, i).tag == "ChangePattern")
            {

            }*/



            if (getElement(listCards,i).tag == getNextElement(listCards, i,true).tag)
            {
                print("Blob");
            }
            if (getElement(listCards, i).tag == getPreviousElement(listCards, i, true).tag)
            {
                print("Blob2");
            }

        }
        return true;
    }


    private GameObject getElement(List<GameObject> listCards,int idx)
    {
        return listCards[(idx + 25) % 25];
    }

    //sens true => sens horaire //sens false => sens anti-horaire
    private GameObject getNextElement(List<GameObject> listCards, int idx, bool sens)
    {
        if (sens)
        {
            return listCards[(idx + 26) % 25];
        }
        else
        {
            return listCards[(idx + 24) % 25];
        }
    }

    private GameObject getPreviousElement(List<GameObject> listCards, int idx, bool sens)
    {
        if (sens)
        {
            return listCards[(idx + 24) % 25];
        }
        else
        {
            return listCards[(idx + 26) % 25];
        }
    }

    //REGEX sur les libelles pour correspondance;
}

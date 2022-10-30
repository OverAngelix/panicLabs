using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPositionScriptbiq : MonoBehaviour
{
    public List<GameObject> listCards;
    public List<GameObject> listSpawnCards;
    // Start is called before the first frame update
    void Start()
    {
        do
        {
            listCards = shuffleCards(listCards);
            for (int i = 0; i < listSpawnCards.Count; i++)
            {
                listCards[i].GetComponent<RectTransform>().position = listSpawnCards[i].GetComponent<RectTransform>().position;
                listCards[i].GetComponent<RectTransform>().position = listSpawnCards[i].GetComponent<RectTransform>().position;

            }
        } while (IsNotCorrectlyShuffle());
        //GameInformation.listCards = listCards;
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


    private bool IsNotCorrectlyShuffle()
    {
        for (int i = 0; i < listCards.Count; i++)
        {
            if (getElement(i).tag == "Lab" && getNextElement(i, true).tag == "Lab")
            {
                return true;
            }

            if (getElement(i).tag == "Mutation" && getNextElement(i, true).tag == "Mutation")
            {
                return true;
            }

            if (getElement(i).tag == "Vent" && getNextElement(i, true).tag == "Vent")
            {
                return true;
            }

            //Rajouter cas si besoin
        }
        return false;
    }


    public GameObject getElement(int idx)
    {
        return listCards[(idx + 25) % 25];
    }

    //sens true => sens horaire //sens false => sens anti-horaire
    public GameObject getNextElement(int idx, bool sens)
    {
        return listCards[getNextIdx(idx, sens)];
    }

    public int getNextIdx(int idx, bool sens)
    {
        if (sens)
        {
            return (idx + 26) % 25;
        }
        else
        {
            return (idx + 24) % 25;
        }
    }

    public int searchCard(string name)
    {
        for (int i = 0; i < listCards.Count; i++)
        {
            if (getElement(i).name == name)
            {
                return i;
            }
        }
        return -1;
    }

    public int searchNextVent(int index, bool sens)
    {
        do
        {
            index = getNextIdx(index, sens);
        } while (getElement(index).tag != "Vent");
        return index;
    }

}

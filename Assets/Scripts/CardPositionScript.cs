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
        bool IsCorrectlyShuffle = true;
        while (IsCorrectlyShuffle)
        {
            listCards = shuffleCards(listCards);
            for (int i = 0; i < listSpawnCards.Count; i++)
            {
                listCards[i].transform.position = listSpawnCards[i].transform.position;
            }
        }
        //ITERE POUR L4ORDRE DES CARTES

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < listSpawnCards.Count; i++)
        {
            
        }
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

}

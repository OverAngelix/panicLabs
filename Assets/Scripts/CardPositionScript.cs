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
        for (int i = 0; i < listSpawnCards.Count; i++)
        {
            GameObject temp = listSpawnCards[i];
            int randomIndex = Random.Range(i, listSpawnCards.Count);
            listSpawnCards[i] = listSpawnCards[randomIndex];
            listSpawnCards[randomIndex] = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < listSpawnCards.Count; i++)
        {
            listCards[i].transform.position = listSpawnCards[i].transform.position;
        }
    }
}

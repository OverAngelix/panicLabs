using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour
{
    //PARAMETRE POUR UN JOUEUR
    public static int score = 0;
    public static bool isPlayed;

    //PARAMETRE DU LANCER DE DÉS
    public static string form;
    public static string color;
    public static string pattern;
    public static string lab;
    // Start is called before the first frame update
    void Start()
    {
        isPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

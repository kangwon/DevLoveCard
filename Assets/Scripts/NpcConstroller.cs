using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcConstroller : MonoBehaviour
{
    public Card npcCard;

    void Start()
    {
        
    }

    void Update()
    {
        if (!(npcCard is null) && (npcCard.items.Count == 3))
        {
            GameObject.Find("Item0Button").GetComponentInChildren<Text>().text = 
                npcCard.items[0].name;
            GameObject.Find("Item1Button").GetComponentInChildren<Text>().text = 
                npcCard.items[1].name;
            GameObject.Find("Item2Button").GetComponentInChildren<Text>().text = 
                npcCard.items[2].name;
        }
    }
}

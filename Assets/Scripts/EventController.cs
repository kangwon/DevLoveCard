using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{
    public Card eventCard;

    void Start()
    {
        
    }

    void Update()
    {
        if (!(eventCard is null))
        {
            switch (eventCard.type)
            {
                case "chest":
                    GameObject.Find("ActivateButton").GetComponentInChildren<Text>().text = 
                        "연다";
                    break;
                case "buff":
                    GameObject.Find("ActivateButton").GetComponentInChildren<Text>().text = 
                        "받는다";
                    break;
                case "random":
                    GameObject.Find("ActivateButton").GetComponentInChildren<Text>().text = 
                        "받는다";
                    break;
            }
        }
    }
}

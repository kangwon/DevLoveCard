using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDetailController : MonoBehaviour
{
    public GameObject CardTitle;

    public GameObject MonsterDisplay;
    public GameObject EventDisplay;
    public GameObject NpcDisplay;

    private Card _currentCard;
    public Card CurrentCard
    { 
        get { return _currentCard; }
        set {
            _currentCard = value;
            UpdateCardDetail();
        }
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    void UpdateCardDetail()
    {
        CardTitle.GetComponentInChildren<Text>().text = CurrentCard.title;

        MonsterDisplay.SetActive(false);
        EventDisplay.SetActive(false);
        NpcDisplay.SetActive(false);
        
        switch (CurrentCard.type)
        {
            case "monster":
                MonsterDisplay.SetActive(true);
                MonsterController monsterController = 
                    MonsterDisplay.GetComponentInChildren<MonsterController>();
                monsterController.monster = new Monster(CurrentCard.stat);
                break;
            case "chest":
            case "buff":
            case "random":
                EventDisplay.SetActive(true);
                EventController evnetController = 
                    EventDisplay.GetComponentInChildren<EventController>();
                evnetController.eventCard = CurrentCard;
                break;
            case "npc":
                NpcDisplay.SetActive(true);
                NpcConstroller npcConstroller =
                    NpcDisplay.GetComponentInChildren<NpcConstroller>();
                npcConstroller.npcCard = CurrentCard;
                break;
        }
    }
}

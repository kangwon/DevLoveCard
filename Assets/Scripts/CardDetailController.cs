using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDetailController : MonoBehaviour
{
    public GameObject CardTitle;

    public GameObject MonsterDisplay;

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
        
        switch (CurrentCard.type)
        {
            case "monster":
                MonsterDisplay.SetActive(true);
                MonsterController controller = 
                    MonsterDisplay.GetComponentInChildren<MonsterController>();
                controller.monster = new Monster(CurrentCard.stat);
                break;
        }
    }
}

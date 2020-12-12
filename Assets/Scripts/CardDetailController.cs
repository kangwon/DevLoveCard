using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDetailController : MonoBehaviour
{
    public GameObject CardTitle;

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
        CardTitle.GetComponentInChildren<Text>().text = CurrentCard.Title;
    }
}

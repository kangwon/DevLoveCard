using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card
{
    public string Type { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }

    public Card(string type, string slug, string title)
    {
        this.Type = type;
        this.Slug = slug;
        this.Title = title;
    }
}

public class CardGenerator : MonoBehaviour
{
    public GameObject CardButtonPrefab;
    public GameObject Canvas;
    public int CardX = 540;
    public int CardY = 1737;
    public int CardMargin;

    List<Card> CardData = new List<Card> 
    {
        new Card("monster", "몹", "슬라임"),
        new Card("chest", "상자", "보물 상자"),
        new Card("buff", "버프", "버프"),
        new Card("event", "랜덤", "랜덤 이벤트"),
        new Card("npc", "NPC", "무기 상인"),
    };
    List<GameObject> CardButtons = new List<GameObject>();
    int CurrentIndex = 0;

    Vector2 StartPosition;
    Vector2 EndPosition;
    
    void Start()
    {
        GenerateCardButtons();
        ArrangeCards();
    }

    void Update()
    {
        // Swipe genture
        if(Input.GetMouseButtonDown(0))
        {
            StartPosition = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            EndPosition = Input.mousePosition;
            float swipeLen = EndPosition.x - StartPosition.x;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

    void GenerateCardButtons()
    {
        for (int i = 0; i < CardData.Count; i++)
        {
            GameObject cardButton = Instantiate(CardButtonPrefab) as GameObject;
            cardButton.transform.SetParent(Canvas.transform, false);
            cardButton.transform.SetAsFirstSibling();

            Card card = CardData[i];
            cardButton.GetComponentInChildren<Text>().text = card.Slug;

            CardButtons.Add(cardButton);
        }
    }

    void ArrangeCards()
    {
        for (int i = 0; i < CardButtons.Count; i++)
        {
            GameObject cardButton = CardButtons[i];
            float cardWidth = cardButton.GetComponent<RectTransform>().rect.width;
            cardButton.transform.position = 
                new Vector3(CardX + (i - CurrentIndex) * (cardWidth + CardMargin), CardY, 0);
        }
    }

    void MoveLeft()
    {
        CurrentIndex--;
        if (CurrentIndex < 0)
            CurrentIndex = CardButtons.Count - 1;
        ArrangeCards();
    }

    void MoveRight()
    {
        CurrentIndex++;
        if (CurrentIndex >= CardButtons.Count)
            CurrentIndex = 0;
        ArrangeCards();
    }
}

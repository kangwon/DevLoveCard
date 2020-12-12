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
    public GameObject cardButtonPrefab;
    public int CardY;
    public int CardMargin;

    public List<Card> Cards = new List<Card> 
    {
        new Card("monster", "몹", "슬라임"),
        new Card("chest", "상자", "보물 상자"),
        new Card("buff", "버프", "버프"),
        new Card("event", "랜덤", "랜덤 이벤트"),
        new Card("npc", "NPC", "무기 상인"),
    };
    
    void Start()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        for (int i = 0; i < Cards.Count; i++)
        {
            GameObject cardButton = Instantiate(cardButtonPrefab) as GameObject;
            float cardWidth = cardButton.GetComponent<RectTransform>().rect.width;
            cardButton.transform.position = 
                new Vector3(i * (cardWidth + CardMargin), CardY, 1);
            cardButton.transform.SetParent(canvas.transform, false);

            Card card = Cards[i];
            cardButton.GetComponentInChildren<Text>().text = card.Slug;
        }
    }

    void Update()
    {
        
    }
}

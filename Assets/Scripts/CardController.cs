using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public GameObject CardButtonPrefab;
    public CardDetailController DetailController;
    public GameObject Canvas;
    public int CardX = 540;
    public int CardY = 1737;
    public int CardMargin = 22;

    public string WorldId = "devWorld";
    int CurrentStage = 0;
    List<Card> CardData = new List<Card>();
    List<GameObject> CardButtons = new List<GameObject>();
    int CurrentIndex = 0;

    Vector2 StartPosition;
    Vector2 EndPosition;
    
    void Start()
    {
        LoadWorldData();
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

    void LoadWorldData()
    {
        World world = WorldDB.GetWorld(WorldId);
        Stage stage = world.stages[CurrentStage];
        foreach (string cardId in stage.cardIds)
        {
            CardData.Add(CardDB.GetCard(cardId));
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
            cardButton.GetComponentInChildren<Text>().text = card.slug;

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
        DetailController.CurrentCard = CardData[CurrentIndex];
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

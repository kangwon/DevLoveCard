using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CardDB  
{  
    [System.Serializable]
    class RawCardData { public List<Card> cards; }

    Dictionary<string, Card> cardData = new Dictionary<string, Card>();

    private static readonly CardDB instance = new CardDB();  
    // Explicit static constructor to tell C# compiler  
    // not to mark type as before field dinit  
    static CardDB() {}  
    private CardDB() 
    {        
        TextAsset jsonFile = Resources.Load<TextAsset>("card");
        List<Card> cardList = JsonUtility.FromJson<RawCardData>(jsonFile.text).cards;
        foreach (Card card in cardList)
        {
            cardData.Add(card.id, card);
        }
    }  
    public static CardDB Instance  
    {  
        get { return instance; }  
    }  

    public static Card GetCard(string cardId)
    {
        return Instance.cardData[cardId];
    }
}

[System.Serializable]
public class Card
{
    public string id;
    public string type;
    public string slug;
    public string title;
}

[System.Serializable]
public class Stage
{
    public List<string> cardIds;
    public List<Card> cards
    {
        get;
    }
}

[System.Serializable]
public class World
{

}

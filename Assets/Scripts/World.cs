using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class Card : JsonItem
{
    public string type;
    public string slug;
    public string title;
    public Stat stat;
}

[System.Serializable]
public class Stage
{
    public List<string> cardIds;
    public List<Card> cards
    {
        get => cardIds.Select(id => JsonDB.GetCard(id)).ToList();
    }
}

[System.Serializable]
public class World : JsonItem
{
    public List<Stage> stages;
}

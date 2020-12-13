using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class JsonDBItem
{
    public string id;
}

class JsonDB<T> where T : JsonDBItem
{  
    [System.Serializable]
    class RawData { public List<T> items; }

    Dictionary<string, T> itemDict = new Dictionary<string, T>();
    public JsonDB(string resourcePath) 
    {        
        TextAsset jsonFile = Resources.Load<TextAsset>(resourcePath);
        List<T> itemList = JsonUtility.FromJson<RawData>(jsonFile.text).items;
        foreach (T item in itemList)
            itemDict.Add(item.id, item);
    }

    public T GetItem(string id)
    {
        return itemDict[id];
    }
}

[System.Serializable]
public class Card : JsonDBItem
{
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
        get => cardIds.Select(id => CardDB.GetCard(id)).ToList();
    }
}

[System.Serializable]
public class World : JsonDBItem
{
    public List<Stage> stages;
}

public sealed class CardDB
{
    private JsonDB<Card> db;
    private static readonly CardDB instance = new CardDB();  
    static CardDB() {}  
    private CardDB() 
    {        
        db = new JsonDB<Card>("card");
    }  
    public static CardDB Instance  
    {  
        get { return instance; }  
    }  

    public static Card GetCard(string cardId)
    {
        return Instance.db.GetItem(cardId);
    }
}

public sealed class WorldDB
{
    private JsonDB<World> db;
    private static readonly WorldDB instance = new WorldDB();  
    static WorldDB() {}  
    private WorldDB() 
    {        
        db = new JsonDB<World>("world");
    }  
    public static WorldDB Instance  
    {  
        get { return instance; }  
    }  

    public static World GetWorld(string worldId)
    {
        return Instance.db.GetItem(worldId);
    }
}

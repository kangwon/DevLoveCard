using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class JsonItem
{
    public string id;
}

class JsonCollection<T> where T : JsonItem
{  
    [System.Serializable]
    class RawData { public List<T> items; }

    Dictionary<string, T> itemDict = new Dictionary<string, T>();
    public JsonCollection(string resourcePath) 
    {        
        TextAsset jsonFile = Resources.Load<TextAsset>(resourcePath);
        List<T> itemList = JsonUtility.FromJson<RawData>(jsonFile.text).items;
        foreach (T item in itemList)
            itemDict.Add(item.id, item);
    }

    public T GetItem(string id) => itemDict[id];
}

class JsonDB
{
    private JsonCollection<Card> cardCollection;
    private JsonCollection<World> worldCollection;

    private static readonly JsonDB instance = new JsonDB();  
    static JsonDB() {}  
    private JsonDB() 
    {        
        cardCollection = new JsonCollection<Card>("card");
        worldCollection = new JsonCollection<World>("world");
    }
    public static JsonDB Instance  
    {  
        get => instance;
    }

    public static Card GetCard(string id)
        => Instance.cardCollection.GetItem(id);
    public static World GetWorld(string id)
        => Instance.worldCollection.GetItem(id);
}

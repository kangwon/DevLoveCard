using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour
{   
    public GameObject HpText;
    public GameObject DefenseText;
    public GameObject AttackText;
    public GameObject SpeedText;

    public Monster monster;

    void Start()
    {
        
    }

    void Update()
    {
        if (!(monster is null))
        {
            HpText.GetComponentInChildren<Text>().text = $"{monster.hp} / {monster.baseStat.maxHp}";
            DefenseText.GetComponentInChildren<Text>().text = $"{monster.baseStat.defense}";
            AttackText.GetComponentInChildren<Text>().text = $"{monster.baseStat.attack}";
            SpeedText.GetComponentInChildren<Text>().text = $"{monster.baseStat.speed}";
        }
    }

    public void Fight()
    {

    }
}

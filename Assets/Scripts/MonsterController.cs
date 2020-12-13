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
            HpText.GetComponentInChildren<Text>().text = $"HP: {monster.hp} / {monster.GetStat().maxHp}";
            DefenseText.GetComponentInChildren<Text>().text = $"DEF: {monster.GetStat().defense}";
            AttackText.GetComponentInChildren<Text>().text = $"ATK: {monster.GetStat().attack}";
            SpeedText.GetComponentInChildren<Text>().text = $"SPD: {monster.GetStat().speed}";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject HpText;
    public GameObject DefenseText;
    public GameObject AttackText;
    public GameObject SpeedText;

    public Player player;

    void Start()
    {
        player = new Player(new Stat {
            maxHp = 20, attack = 7, defense = 1, speed = 100
        });
    }

    void Update()
    {
        if (!(player is null))
        {
            HpText.GetComponentInChildren<Text>().text = $"HP: {player.hp} / {player.GetStat().maxHp}";
            DefenseText.GetComponentInChildren<Text>().text = $"DEF: {player.GetStat().defense}";
            AttackText.GetComponentInChildren<Text>().text = $"ATK: {player.GetStat().attack}";
            SpeedText.GetComponentInChildren<Text>().text = $"SPD: {player.GetStat().speed}";
        }
    }
}

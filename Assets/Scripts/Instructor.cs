using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructor : MonoBehaviour
{
    public PlayerController playerController;
    public MonsterController monsterController;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Battle()
    {
        Player player = playerController.player;
        Monster monster = monsterController.monster;
        Damage(
            monster, 
            player.GetStat().attack * player.GetStat().speed / 100
            - monster.GetStat().defense
        );
        Damage(
            player, 
            monster.GetStat().attack * monster.GetStat().speed / 100
            - player.GetStat().defense
        );
    }

    void Damage(Character character, int amount)
    {
        character.hp -= amount;
        if (character.hp < 0)
        {
            character.hp = 0;
        }
    }
}

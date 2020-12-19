using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructor : MonoBehaviour
{
    public PlayerController playerController;
    public MonsterController monsterController;
    public EventController eventController;

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

    public void ActivateEvent()
    {
        Player player = playerController.player;
        Monster monster = monsterController.monster;
        string instruction = eventController.eventCard.instruction;

        switch(instruction)
        {
            case "heal_10": Heal(player, 10); break;
            case "heal_999": Heal(player, 999); break;

            case "damage_5": Damage(player, 5); break;

            case "buff_attack_5": Buff(player, new Stat(){attack = 5}); break;
            case "buff_attack_99": Buff(player, new Stat(){attack = 99}); break;
            case "buff_defense_99": Buff(player, new Stat(){defense = 99}); break;
        }
    }

    void Damage(Character character, int amount)
    {
        character.hp = Math.Max(character.hp - amount, 0);
    }

    void Heal(Character character, int amount)
    {
        character.hp = Math.Min(character.hp + amount, character.GetStat().maxHp);
    }

    void Buff(Player character, Stat buff)
    {
        character.AddBuff(buff);
    }
}

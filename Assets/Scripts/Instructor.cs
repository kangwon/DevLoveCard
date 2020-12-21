using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructor : MonoBehaviour
{
    public PlayerController playerController;
    public MonsterController monsterController;
    public EventController eventController;
    public NpcConstroller npcController;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DoBattle()
    {
        ExecuteInstruction("battle");
    }

    public void ActivateEvent()
    {
        ExecuteInstruction(eventController.eventCard.instruction);
    }

    public void BuyItem(int itemIndex)
    {
        NpcItem item = npcController.npcCard.items[itemIndex];
        ExecuteInstruction(item.instruction);
    }

    void ExecuteInstruction(string instruction)
    {
        Player player = playerController.player;
        Monster monster = monsterController.monster;

        switch(instruction)
        {
            case "battle": Battle(player, monster); break;

            case "heal_10": Heal(player, 10); break;
            case "heal_999": Heal(player, 999); break;

            case "damage_5": Damage(player, 5); break;

            case "buff_attack_5": Buff(player, new Stat(){attack = 5}); break;
            case "buff_attack_99": Buff(player, new Stat(){attack = 99}); break;
            case "buff_defense_99": Buff(player, new Stat(){defense = 99}); break;
        }

        if(monster.isDead)
        {
            SceneManager.LoadScene("GameClearScene");
        }
        else if(player.isDead)
        {
            SceneManager.LoadScene("GameOverScene");
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

    void Battle(Character player, Character monster)
    {
        Damage(
            monster, 
            Math.Max(
                player.GetStat().attack * player.GetStat().speed / 100
                - monster.GetStat().defense,
                1
            )
        );
        Damage(
            player, 
            Math.Max(
                monster.GetStat().attack * monster.GetStat().speed / 100
                - player.GetStat().defense,
                1
            )
        );
    }
}

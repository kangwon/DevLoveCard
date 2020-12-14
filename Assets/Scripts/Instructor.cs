using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Instructor : MonoBehaviour
{
    public PlayerController playerController;
    public MonsterController monsterController;

    void Start() 
    { 
        InitEnv();
    }
    void Update() { }

    public void BattleOnClick()
    {
        Instruct(
            new List<string> 
            {
                "attack", "player", "monster",
            }
        );
    }
}

public partial class Instructor
{
    Dictionary<string, Delegate> envFuncs;
    Dictionary<string, dynamic> envVars;

    dynamic Instruct(dynamic instruction)
    {
        Debug.Log($"{instruction}");
        if (instruction is string)
        {
            if (envVars.ContainsKey(instruction))
            {
                return envVars[instruction];
            }
            else if (envFuncs.ContainsKey(instruction))
            {
                return envFuncs[instruction];
            }
        }
        if (instruction is List<string>)
        {
            string funcName = instruction[0];
            List<dynamic> args = (instruction as List<string>)
                .Skip(1).Select(x => Instruct(x)).ToList();
            switch (args.Count)
            {
                case 0:
                    return envFuncs[funcName].DynamicInvoke();
                case 1:
                    return envFuncs[funcName].DynamicInvoke(args[0]);
                case 2:
                    return envFuncs[funcName].DynamicInvoke(args[0], args[1]);
            }
        }
        return null;
    }

    void InitEnv()
    {
        envFuncs = new Dictionary<string, Delegate>
        {
            {"damage", new Action<Character, int>(Damage)},
            {"attack", new Action<Character, Character>(Attack)},
        };
        envVars = new Dictionary<string, dynamic>
        {
            {"player", playerController.player},
            {"monster", monsterController.monster},
        };
    }

    void Damage(Character character, int amount)
    {
        character.hp -= amount;
        if (character.hp < 0)
        {
            character.hp = 0;
        }
    }

    void Attack(Character attacker, Character defender)
    {
        Damage(
            defender, 
            attacker.GetStat().attack * attacker.GetStat().speed / 100
            - defender.GetStat().defense
        );
    }

    void Battle()
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
}
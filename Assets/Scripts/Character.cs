using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class Stat
{
    public int maxHp;
    public int attack;
    public int defense;
    public int speed;

    public static Stat operator +(Stat a, Stat b)
    {
        return new Stat
        {
            maxHp = a.maxHp + b.maxHp,
            attack = a.attack + b.attack,
            defense = a.defense + b.defense,
            speed = a.speed + b.speed
        };
    }

    public override string ToString()
    {
        return $"Stat(hp:{maxHp}, atk:{attack}, def:{defense}, spd:{speed})";
    }
}

public class Character
{
    public readonly Stat baseStat;
    public int hp;

    public Character(Stat stat)
    {
        this.baseStat = stat;
        this.hp = this.baseStat.maxHp;
    }

    public virtual Stat GetStat()
    {
        return baseStat;
    }
}

public class Monster : Character 
{ 
    public Monster(Stat stat) : base(stat) { }
}

public class Player : Character
{
    List<Stat> buffs = new List<Stat>();

    public Player(Stat stat) : base(stat) { }

    public void AddBuff(Stat buff)
    {
        buffs.Add(buff);
    }

    public override Stat GetStat()
    {
        return buffs.Aggregate(baseStat, (stat, buff) => stat + buff);
    }
}
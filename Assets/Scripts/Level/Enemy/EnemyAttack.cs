using System;
using UnityEngine.UI;
using static Enums;

public class EnemyAttack
{
    public AttackPattern AttackPattern { get; set; }

    public float TimeBetweenAttacks { get; set; }
    public float TimeBetweenBullet { get; set; }

    public float AttackRange { get; set; }

    public int BaseDamage { get; set; }

    public EnemyAttack(AttackPattern attackPattern, float timeBetweenAttacks, float timeBetweenBullet, float attackRange, int baseDamage)
    {
        AttackPattern = attackPattern;
        TimeBetweenAttacks = timeBetweenAttacks;
        TimeBetweenBullet = timeBetweenBullet;
        AttackRange = attackRange;
        BaseDamage = baseDamage;
    }
}


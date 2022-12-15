using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : Enemy
{
    [SerializeField] float slowAmount = 0.9f;
    protected override void PlayerImpact(Player player)
    {
        player.SlowDown(slowAmount);
    }
}
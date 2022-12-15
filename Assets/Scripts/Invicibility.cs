using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invicibility : PowerupBase
{
    private Color lastColor;
    protected override void PowerUp(Player player){
        if(player != null){
            TankController tank = player.GetComponent<TankController>();
            if(tank != null){
                lastColor = tank.ChangeColor(Color.black);
                player.Invincible(true);
            }
        }
    }
    protected override void PowerDown(Player player){
        if(player != null){
            TankController tank = player.GetComponent<TankController>();
            if(tank != null){
                tank.ChangeColor(lastColor);
                player.Invincible(false);
            }
        }
    }
}

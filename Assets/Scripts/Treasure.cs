using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : CollectibleBase
{
    [SerializeField] Text _treasureLabel;
    protected override void Collect(Player player){
        if(player != null){
            _treasureLabel.text = "Treasure: " + player.IncreaseTreasure();
        }
    }
}

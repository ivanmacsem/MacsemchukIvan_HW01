using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    int _currentHealth;
    int _treasureCount;
    bool isInvincible = false;

    TankController _tankController;
    void Awake(){
        _tankController = GetComponent<TankController>();
    }
    
    void Start()
    {
        _currentHealth = _maxHealth;
    }
    public int IncreaseTreasure(){
        _treasureCount ++;
        return _treasureCount;
    }

    public void IncreaseHealth(int amount){
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount){
        if(!isInvincible){
            _currentHealth -= amount;
            Debug.Log("Player's health: " + _currentHealth);
            if(_currentHealth <= 0){
                Kill();
            }
        }
    }
    public void SlowDown(float slowPercentage){
        _tankController.MaxSpeed *= slowPercentage;
    }
    public void Invincible(bool inv){
        isInvincible = inv;
    }

    public void Kill(){
        if(!isInvincible){
            gameObject.SetActive(false);
        }
    }
}

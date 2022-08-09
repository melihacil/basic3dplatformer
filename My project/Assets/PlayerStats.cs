using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{


    public float currentHealth;
    public float maxHealth = 100;
    public int Coins = 0;
    // Start is called before the first frame update


    
    public UnityEvent<float> healthBar;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar?.Invoke(1);
    }

    private void Update()
    {
        healthBar.Invoke(currentHealth / maxHealth);
    }

    public void damagePlayer(float damage)
    {
        currentHealth -= damage;
    }
    public void upCoin()
    {
        Coins++;
        Debug.Log("Coins =" + Coins);
    }
}

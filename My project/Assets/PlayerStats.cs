using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{


    public float currentHealth;
    public float maxHealth = 100;
    public int Coins = 0;
    // Start is called before the first frame update
    public Text coinText;

    [SerializeField]
    private Transform playerTransform;
    
    public UnityEvent<float> healthBar;
    //public UnityEvent<int> coinNumber;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar?.Invoke(1);
        coinText.text = "Coins = " + Coins;
    }

    private void Update()
    {
        healthBar.Invoke(currentHealth / maxHealth);
        coinText.text = "Coins = " + Coins;
        gameObject.transform.position = playerTransform.position;
    }

    public void damagePlayer(float damage)
    {
        currentHealth -= damage;
    }
    public void upCoin(int coinValue)
    {
        Coins += coinValue;
        Debug.Log("Coins =" + Coins);
    }
}

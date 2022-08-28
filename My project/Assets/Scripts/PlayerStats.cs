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

    public bool hasKey = false;
    // Start is called before the first frame update
    public Text coinText;

    [SerializeField]
    private Text keyText;
    
    public UnityEvent<float> healthBar;
    //public UnityEvent<int> coinNumber;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar?.Invoke(1);
        coinText.text = "Coins = " + Coins;
        keyText.enabled = false;
        
    }

    private void Update()
    {
        healthBar.Invoke(currentHealth / maxHealth);
        coinText.text = "Coins = " + Coins;
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

    public void GotKey()
    {
        keyText.enabled = true;
        Invoke("DisableText", 2f);
    }
    private void DisableText()
    {
        keyText.enabled = false;
    }

}

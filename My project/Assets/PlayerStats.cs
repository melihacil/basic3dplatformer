using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int Coins = 0;
    // Start is called before the first frame update
    public void upCoin()
    {
        Coins++;
        Debug.Log("Coins =" + Coins);
    }
}

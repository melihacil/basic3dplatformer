using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private int coinValue = 1;

    //Added coin animation
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Got one more Coin!");
            Destroy(gameObject);
            //collision.gameObject.GetComponent<PlayerStats>().upCoin();
            collision.gameObject.GetComponentInParent<PlayerStats>().upCoin(coinValue);
        }
    }
}

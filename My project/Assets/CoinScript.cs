using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private int coinValue = 1;

    private void Update()
    {
        //Need to add rotation to coin this does not work
        transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion (0,0,0,0), 30);
    }
    // Start is called before the first frame update
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

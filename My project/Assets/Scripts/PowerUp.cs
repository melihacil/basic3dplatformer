using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            Destroy(gameObject);
            collision.gameObject.GetComponentInParent<PlayerStats>().healPlayer(40);
        }
    }
}

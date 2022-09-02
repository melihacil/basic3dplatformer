using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInParent<PlayerStats>().hasKey = true;
            collision.gameObject.GetComponentInParent<PlayerStats>().GotKey();
            Destroy(gameObject);
        }


}
}

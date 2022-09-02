using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponentInParent<PlayerStats>().hasKey)
            {
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("No key");
            }
        }
    }
}

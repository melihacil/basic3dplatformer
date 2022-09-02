using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    //Damages and shoots the player upwards
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.transform.up * 7, ForceMode.Impulse);
            collision.gameObject.GetComponentInParent<PlayerStats>().damagePlayer(20);
        }
    }
}

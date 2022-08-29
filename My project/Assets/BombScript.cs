using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public Transform player;
    public float radius = 1.5f;

    private void OnCollisionEnter(Collision collision)
    {

        if (!GetComponent<ParticleSystem>().isPlaying)
            GetComponent<ParticleSystem>().Play();

        


        GetComponent<MeshRenderer>().enabled = false;
        GetComponentInChildren<Light>().enabled = false;
        Invoke(nameof(SetVisibility), 2f);


        //Raycast can be used too

        //this code block can be used for exploding world objects too
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.gameObject.tag == "Player")
            {
                Debug.Log("Wow");
                nearbyObject.gameObject.GetComponentInParent<PlayerStats>().damagePlayer(30);
                break;
            }

        }

    }



    private void SetVisibility()
    {
        GetComponent<ParticleSystem>().Stop();
        GetComponent<MeshRenderer>().enabled = true;
        GetComponentInChildren<Light>().enabled = true;
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public Transform player;
    public float radius = 2f;

    private void OnCollisionEnter(Collision collision)
    {

        if (!GetComponent<ParticleSystem>().isPlaying)
            GetComponent<ParticleSystem>().Play();

        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= radius)
        {
            player.GetComponentInParent<PlayerStats>().damagePlayer(30);
        }




        GetComponent<MeshRenderer>().enabled = false;
        GetComponentInChildren<Light>().enabled = false;
        Invoke(nameof(SetVisibility), 2f);

        /* If you want stuff to blow up this is the way to go
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in colliders)
        {
            if ()

        }
        */

        //But to just check if player is in radius just shoot a ray to player
        


     }



    private void SetVisibility()
    {
        GetComponent<ParticleSystem>().Stop();
        GetComponent<MeshRenderer>().enabled = true;
        GetComponentInChildren<Light>().enabled = true;
        gameObject.SetActive(false);
    }
}

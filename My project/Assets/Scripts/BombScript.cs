using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public Transform player;
    public float radius = 0.4f;
    private bool damaged = false;
    private bool checkCollision = false;

    private void OnCollisionEnter(Collision collision)
    {

        if (!GetComponent<ParticleSystem>().isPlaying)
            GetComponent<ParticleSystem>().Play();

        //FindObjectOfType<SoundManager>().PlaySound("bombExplosion");


        GetComponent<MeshRenderer>().enabled = false;
        GetComponentInChildren<Light>().enabled = false;
        Invoke(nameof(SetVisibility), 2f);
        if (!checkCollision)
        {
            ExplosionCheck();
            checkCollision = true;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void ExplosionCheck()
    {
        //Raycast can be used too

        //this code block can be used for exploding world objects too

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            if (!damaged && nearbyObject.gameObject.tag == "Player")
            {
                Debug.Log("Wow");
                nearbyObject.gameObject.GetComponentInParent<PlayerStats>().damagePlayer(20);
                damaged = true;
            }
            else if (!damaged && nearbyObject.gameObject.tag == "Boss" )
            {
                Debug.Log("Hit boss");
                nearbyObject.gameObject.GetComponent<BossScript>().DamageBoss();
                damaged = true;

            }
        }
    }

    private void SetVisibility()
    {
        GetComponent<ParticleSystem>().Stop();
        GetComponent<MeshRenderer>().enabled = true;
        GetComponentInChildren<Light>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        damaged = false;
        checkCollision = false;
        gameObject.SetActive(false);
    }
}

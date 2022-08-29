using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject particle;

    public ParticleSystem explosion;
    private void OnCollisionEnter(Collision collision)
    {
        // gameObject.SetActive(false);
        //explosion.Play();
        /*
        Instantiate(explosion,transform.position,transform.rotation);
        explosion.Play();
        explosion.GetComponent<ParticleSystem>();
        */

        if (!GetComponent<ParticleSystem>().isPlaying)
            GetComponent<ParticleSystem>().Play();
     }
}

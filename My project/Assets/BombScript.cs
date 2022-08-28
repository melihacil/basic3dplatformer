using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject particle;
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(particle, transform);
        Destroy(gameObject);
    }
}

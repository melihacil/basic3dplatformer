using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
    private bool hasFired = false;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == "Player")
        {
            if ( !hasFired)
            {
                hasFired = true;
            }
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if ( collision.gameObject.tag == "Player")
        {
            hasFired = false;
        }
    }
}

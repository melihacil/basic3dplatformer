using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
    private bool hasFired = false;
    //Used on boss ground to kill the boss
    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == "Player")
        {
            if ( !hasFired)
            {
                hasFired = true;

                GetComponentInParent<ShootBomb>().Fire();
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

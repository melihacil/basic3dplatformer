using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageScript : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    private void OnCollisionEnter(Collision collision)
    {
        //isPlayer = Physics.Raycast(transform.position, Vector3.up, enemyHeight * 0.5f + 0.2f, whatIsPlayer);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player hopped on enemy");

            //Will be adding damage and other stuff--
            Destroy(enemy);
            collision.gameObject.GetComponent<PlayerMovement>().addJumpForce();
        }
    }
}

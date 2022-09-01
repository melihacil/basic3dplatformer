using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBomb : MonoBehaviour
{

    public Transform shootingPoint;

    public GameObject bomb;

    private ObjectPool bombPool;



    private void Awake()
    {
        bombPool = GetComponent<ObjectPool>();
    }


    private void Start()
    {
        bombPool.Initialize(bomb, 5);
    }

    public void Fire()
    {

        var bomb = bombPool.CreateObject();

        Rigidbody rb = bomb.GetComponent<Rigidbody>();

        rb.velocity = new Vector3(0, 0, 0);
        // Can be made scaling with distance !! Vector3.Distance(transform.position, player.position);
        rb.AddForce(shootingPoint.forward * 6f, ForceMode.Impulse);
        rb.AddForce(shootingPoint.up * 8f, ForceMode.Impulse);
    }
}

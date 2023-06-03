using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float rotator;
    public Rigidbody EnemyRB;
    public GameObject player;
    float speed = 3.5f;
    Vector3 lookDirecton;
    public Vector3 KeepTransform;
    public Vector3 ZeroMoment;
    public float x;
    public float y;
    public float z;
    int randomer;
    bool HasLocation = false;
    bool turnoffRotation;

    void Start()
    {
        player = GameObject.Find("Player");
        InvokeRepeating("randomThing", 3, 3);
        InvokeRepeating("randomMove", 3, 3);
    }

void Update()
{
    lookDirecton = (player.transform.position - transform.position).normalized;

    RaycastHit playerHit;
    bool hasLineOfSight = Physics.Raycast(transform.position, lookDirecton, out playerHit, Mathf.Infinity);
    if (hasLineOfSight && playerHit.collider.CompareTag("Player"))
    {
        EnemyRB.AddForce(lookDirecton * speed);
        EnemyRB.transform.RotateAround(transform.position, transform.up + lookDirecton, Time.deltaTime);
        KeepTransform = player.transform.position;
    }
    else
    {
        RaycastHit obstacleHit;
        bool hasObstacle = Physics.SphereCast(transform.position, 0.5f, lookDirecton, out obstacleHit, 0.5f);
        if (hasObstacle)
        {
            Vector3 avoidanceDirection = Vector3.Reflect(lookDirecton, obstacleHit.normal);
            EnemyRB.AddForce(avoidanceDirection * speed);
        }
        else
        {
            EnemyRB.AddForce(lookDirecton * speed);
        }
    }
}





    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
        }
        randomMove();
        randomThing();
    }

    void randomThing()
    {
        if (turnoffRotation == false){
        randomer = -Random.Range(-5, 5) * 60;}
    }

    void randomMove()
    {
        if (turnoffRotation == false){
        EnemyRB.AddForce(randomer, 1, randomer);}
    }
}

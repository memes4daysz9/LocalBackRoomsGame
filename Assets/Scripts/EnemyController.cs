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
    Vector3 LostSightDir;
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
        KeepTransform = player.transform.position;
    }else{
        LostSightDir = (player.transform.position - transform.position) - KeepTransform;
        EnemyRB.AddForce(-LostSightDir * speed * Time.deltaTime);
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

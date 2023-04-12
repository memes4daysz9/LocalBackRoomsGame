using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;
    public Transform DeathBed;
    private Rigidbody enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb.GetComponent<RigidBody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookdirection = (Player.transform.position - transform.position).normalized;


        
    }
    void OnCollisionEnter(Collision collision){
        Player.transform.position = DeathBed.transform.position;
    }
}

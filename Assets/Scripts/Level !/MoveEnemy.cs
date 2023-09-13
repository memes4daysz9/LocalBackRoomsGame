using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    float speed = 5.2f;
    Teleporter GMScript;
    PlayerController PlayerControllerScript;
    public Rigidbody Playerchasers;
    Vector3 lookDirecton;
    public GameObject player;
    public bool Confirmation;
    public GameObject EnemyGO;

    // Start is called before the first frame update
    void Start()
    {
        GMScript = FindObjectOfType<Teleporter>();
        player = GameObject.Find("Player");
        Playerchasers.GetComponent<Rigidbody>();
        EnemyGO.GetComponent<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        lookDirecton = (player.transform.position - transform.position).normalized;
        if (PlayerControllerScript.startChase == true){
            Confirmation = true;
        }
        if (Confirmation == true){
            Debug.Log("LOOK MOM I DID IT");
            transform.Translate(Vector3.forward* speed);
        }
        if(EnemyGO.activeSelf == true){
            Confirmation = true;
        }



    }
    void OnEnabled(){
        Confirmation = true;
    }

}

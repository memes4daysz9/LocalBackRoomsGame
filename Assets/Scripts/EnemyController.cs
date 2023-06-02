using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float rotator;//this float is the variable that rotates the raycaster to find the player
    public Rigidbody EnemyRB; //variable moment
    public GameObject player;
    float speed = 1.5f;
    Vector3 lookDirecton;
    public Vector3 KeepTransform;
    public Vector3 ZeroMoment;
    public float x;
    public float y;
    public float z;
    int randomer;
    bool HasLocation = false;
    public bool isdead;
    bool reset;

    
    
    
    // Start is called before the first frame update
    void Start()
    {

        
        player = GameObject.Find("Player"); //get other stuff
        InvokeRepeating("randomThing",3,3);
        InvokeRepeating("randomMove",3,3);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isdead){
            HasLocation = false;
        }

        
        if (reset == true){
            KeepTransform = ZeroMoment;
        }

        lookDirecton = (player.transform.position - transform.position); // ai momento numero dos
        

        
        RaycastHit attack;

        if (Physics.Raycast(transform.position, transform.TransformDirection(lookDirecton), out attack, 150) ){
            if (attack.collider.CompareTag("Player")){

                EnemyRB.transform.Translate(lookDirecton* speed * Time.deltaTime); //more ai stuff

                EnemyRB.transform.RotateAround(transform.position,transform.up + lookDirecton,Time.deltaTime);

                Debug.DrawRay(transform.position, lookDirecton, Color.green);
                HasLocation = true;
                reset = false;
            }else{
                if (HasLocation == true){
                    KeepPosDataFunc();
                }
                
                if ((KeepTransform.x > ZeroMoment.x)&& (KeepTransform.z > ZeroMoment.z)){
                    EnemyRB.AddForce(KeepTransform * 20);
                    reset = true;
                }
            //move everywhere when no human
             

         
        
            

        }
        }}
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Respawn")){
            randomMove();
            randomThing();
        }
    }
    
    void randomThing(){
        randomer = -Random.Range(-5,5) * 60;
    }
    void randomMove(){
        EnemyRB.AddForce(randomer,1,randomer);
    }
    void KeepPosDataFunc(){
        KeepTransform = (player.transform.position);
    }
}

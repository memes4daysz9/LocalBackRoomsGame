using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public GameObject playerGO;
    public bool startChase = false; 
    public Transform playerStart; 
    public GameObject LevelEx;
    public GameObject Level0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnTriggerEnter (Collider other){
        startChase = true;
        playerGO.transform.position = playerStart.transform.position;
        
        
    }
}

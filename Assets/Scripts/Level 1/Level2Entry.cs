using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Entry : MonoBehaviour
{
    public GameObject playerGO;
    public Transform playerTelePos; 
    public GameObject LevelEx;
    public GameObject Level1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter (Collider other){
        
        playerGO.transform.position = playerTelePos.transform.position;
        LevelEx.SetActive(false);
        Level1.SetActive(false);
        
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject PutPlayerHere;
    public Transform WhereToTeleport; 
    public GameObject LevelTeleportingFrom;
    public GameObject LevelTeleportingTO;
    public bool startChase;
    public GameObject Level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter (Collider other){
        
        PutPlayerHere.transform.position = WhereToTeleport.transform.position;
        unseePastLevel();
        SeeCurretLevel();
        
        
    }
    private void unseePastLevel(){
        LevelTeleportingFrom.SetActive(false);
    }
    private void SeeCurretLevel(){
        LevelTeleportingTO.SetActive(true);
    }
}

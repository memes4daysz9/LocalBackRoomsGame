using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0To1Door : MonoBehaviour
{
    public GameObject playerGO;
    public bool startLevel1 = false; 
    public Transform playerStart; 
    public GameObject Level1;
    public GameObject Level0;
    public GameObject Level2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startLevel1){
            Level1.SetActive(true);
            Level0.SetActive(false);
            Level2.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other){
        startLevel1 = true;
        playerGO.transform.position = playerStart.transform.position;
    }
}

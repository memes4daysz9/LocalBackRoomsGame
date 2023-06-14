using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    float speed = 5.2f;
    Teleporter GMScript;
    // Start is called before the first frame update
    void Start()
    {
        GMScript = FindObjectOfType<Teleporter>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GMScript.startChase == true){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }


    }

}

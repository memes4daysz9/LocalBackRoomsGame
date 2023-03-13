using UnityEngine;
 using System.Collections;
 
 public class Pause : MonoBehaviour {
     
     public GameObject Canvas;
     public GameObject Camera;
     
 
     void Start(){
         Canvas.gameObject.SetActive (false);
     }
 
     void Update () {
         if (Input.GetKeyDown ("escape")) {
             Canvas.gameObject.SetActive (true);
         }
     }
     
 }   
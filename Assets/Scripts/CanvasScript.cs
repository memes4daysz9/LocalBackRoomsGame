using UnityEngine;
 using System.Collections;
 
 public class CanvasScript : MonoBehaviour {
     
     public GameObject Canvas;
     
     
 
     void Start(){

         Canvas.gameObject.SetActive (false);
     }
 
     void Update () {
         if (Input.GetKeyDown ("Escape")) {
             Canvas.gameObject.SetActive (true);
         }
         if(Input.GetKeyDown ("Escape")) {
            Canvas.gameObject.SetActive(false);
         }
     }
     
 }   
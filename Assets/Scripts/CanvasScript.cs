using UnityEngine;
 using System.Collections;
 
 public class Pause : MonoBehaviour {
     
     public GameObject Canvas;
     public GameObject Camera;
     bool Paused = false;
 
     void Start(){
         Canvas.gameObject.SetActive (false);
     }
 
     void Update () {
         if (Input.GetKeyDown ("escape")) {
             if(Paused == true){
                 Time.timeScale = 1.0f;
                 Canvas.gameObject.SetActive (false);
                 Screen.showCursor = false;
                 Screen.lockCursor = true;
                 Camera.audio.Play ();
                 Paused = false;
             } else {
                 Time.timeScale = 0.0f;
                 Canvas.gameObject.SetActive (true);
                 Screen.showCursor = true;
                 Screen.lockCursor = false;
                 Camera.audio.Pause ();
                 Paused = true;
             }
         }
     }
     public void Resume(){
         Time.timeScale = 1.0f;
         Canvas.gameObject.SetActive (false);
         Screen.showCursor = false;
         Screen.lockCursor = true;
         Camera.audio.Play ();
     }
 }   
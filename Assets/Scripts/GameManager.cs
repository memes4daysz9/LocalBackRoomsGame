using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    PlayerController PlayerControllerScript;
    public Button restartButton;

    //level scripts
    PlayerDetection PD; //level ! exclamation Point
    Level0To1Door Lvl01; //level 1 one

    // level activation center
    public GameObject Level0;
    public GameObject LevelEx;
    public GameObject Level1;
    

    // Start is called before the first frame update
    void Start()
    {
        Level1.SetActive(false);
        PD = FindObjectOfType<PlayerDetection>();
        Lvl01 = FindObjectOfType<Level0To1Door>();
    }

    // Update is called once per frame
    void Update()
    {
        


        
        if (PlayerControllerScript.IsGameOn == false){
            restartButton.gameObject.SetActive(true);
        }
    }
    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    void FixedUpdate(){
        
        
    }
}

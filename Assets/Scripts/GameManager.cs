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
    // Start is called before the first frame update
    void Start()
    {
        
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
}

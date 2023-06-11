using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float VerticalMovement;
    float HorizontalMovement;
    float Movespeed = 3.5f;
    float SprintSpeed = 11.0f;
    float InitialMoveSpeed = 3.5f;
    public bool isSprinting;
    public Vector2 Mouseturn;
    public float  sesitivity = 200.5f;
    float jumpForce = 5;
    public Rigidbody playerRb;
    bool isOnGround = true;
    bool IsDead = false;
    public float health = 100;
    public float stamina = 100;

    public GameObject CanavasGO;

    public bool IsGameOn = true;
    bool isClimbing = false;
    bool IsAmoungUs = false;//isventing
    public TextMeshProUGUI GameOverText;

    public Slider HealthBarSlider;
    public Slider StaminaBarSlider;

    public float maxStamina = 100f;
    public float staminaDecreaseRate = 10f;
    public float staminaIncreaseRate = 20f;
    public float minStaminaToRun = 10f;

    private float currentStamina;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerRb = GetComponent<Rigidbody>();
        
        IsGameOn = true;

        currentStamina = maxStamina;
    }



    
    // Update is called once per frame
    void Update()
    {
        HealthBarSlider.value = health; //health bar slider moment
        StaminaBarSlider.value = stamina;

        stamina = currentStamina;

        if(health == 0){
            IsGameOn = false;
            GameOverText.text = "GameOver";
            Debug.Log("GameOver");

        }
        if (IsGameOn == true){        
            VerticalMovement = Input.GetAxis("Vertical");
            HorizontalMovement = Input.GetAxis("Horizontal");

            if (isClimbing == false){
                transform.Translate(Vector3.forward * VerticalMovement * Movespeed * Time.deltaTime);
                transform.Translate(Vector3.right * HorizontalMovement * Movespeed * Time.deltaTime);
            }else{
                transform.Translate(Vector3.up * VerticalMovement * Movespeed * Time.deltaTime);
            }}

        //look boi
        Mouseturn.x += Input.GetAxis("Mouse X") * sesitivity * 0.11f;
        Mouseturn.y += Input.GetAxis("Mouse Y") * sesitivity * 0.11f;
        transform.localRotation = Quaternion.Euler(-Mouseturn.y, Mouseturn.x,0);


        


// Decrease stamina while left shift is held down
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0f)
        {
            currentStamina -= staminaDecreaseRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        }
        // Increase stamina when left shift is released
        else if (!Input.GetKey(KeyCode.LeftShift) && currentStamina < maxStamina)
    {
        currentStamina += staminaIncreaseRate * Time.deltaTime;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
    }

        // Check if the player has enough stamina to run
        bool canRun = currentStamina >= minStaminaToRun;

        // Run when both left shift is pressed and stamina is sufficient
        if (Input.GetKey(KeyCode.LeftShift) && canRun)
        {
            Run();
            
        }else{
            NoRun();   
        }




    
        


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        

        if(health < 0.1){
            IsDead = true;
        }else {
            IsDead=false;
        }

    }
    private void OnCollisionEnter (Collision collision){
        if (collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
        }if (collision.gameObject.CompareTag("Ladder")){
            isClimbing = true;
        }if (collision.gameObject.CompareTag("Vent")){//AMOGUS NGL
            IsAmoungUs = true;
        }if (collision.gameObject.CompareTag("Enemy")){
            health -= 25;
        }
    }
    void Run(){
        Movespeed = SprintSpeed;
        isSprinting = true;
    }void NoRun(){
        Movespeed = InitialMoveSpeed;
        isSprinting = false;
    }
}

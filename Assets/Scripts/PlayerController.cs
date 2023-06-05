using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float VerticalMovement;
    float HorizontalMovement;
    float Movespeed = 3.5f;
    float SprintSpeed = 8f;
    float InitialMoveSpeed = 3.5f;
    public bool isSprinting;
    public Vector2 Mouseturn;
    public float  sesitivity = 200.5f;
    float jumpForce = 5;
    private Rigidbody playerRb;
    bool isOnGround = true;
    bool IsDead = false;
    float health = 100;

    public GameObject CanavasGO;

    bool IsGameOn = false;
    bool isClimbing = false;
    bool IsAmoungUs = false;//isventing

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerRb = GetComponent<Rigidbody>();
        CanavasGO.SetActive(false);
        IsGameOn = true;
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Movespeed += SprintSpeed;
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Movespeed = InitialMoveSpeed;
            isSprinting = false;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.P) && IsGameOn){
            CanavasGO.SetActive(true);
        }else{
            CanavasGO.SetActive(false);
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
        }
    }
}

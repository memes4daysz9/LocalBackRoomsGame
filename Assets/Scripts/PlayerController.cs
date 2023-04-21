using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float VerticalMovement;
    float HorizontalMovement;
    float Movespeed = 3.5;
    float SprintSpeed = 8;
    float InitialMoveSpeed = 3.5;
    public bool isSprinting;
    public Vector2 Mouseturn;
    public float  sesitivity = 20.01f;
    float jumpForce = 5;
    private Rigidbody playerRb;
    bool isOnGround = true;
    bool IsDead = false;
    float health = 100;

    public GameObject CanavasGO;

    bool IsGameOn = false;

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
        VerticalMovement = Input.GetAxis("Vertical");
        HorizontalMovement = Input.GetAxis("Horizontal");


        transform.Translate(Vector3.forward * VerticalMovement * Movespeed * Time.deltaTime);
        transform.Translate(Vector3.right * HorizontalMovement * Movespeed * Time.deltaTime);

        //look boi
        Mouseturn.x += Input.GetAxis("Mouse X") * sesitivity;
        Mouseturn.y += Input.GetAxis("Mouse Y") * sesitivity;
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
        }
    }
}

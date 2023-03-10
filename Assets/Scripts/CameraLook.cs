using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector2 Mouseturn;
    public float  sesitivity = 20.01f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Mouseturn.x += Input.GetAxis("Mouse X") * sesitivity;
        Mouseturn.y += Input.GetAxis("Mouse Y") * sesitivity;
        transform.localRotation = Quaternion.Euler(-Mouseturn.y, Mouseturn.x,0);
    }
}

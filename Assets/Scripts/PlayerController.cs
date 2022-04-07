using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInputs playerInputs;

    public static float limitX=0;
    float xAxis;
    public static float speed=0;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
    }

    private void Start()
    {
        playerInputs.PlayerMovement.Movement.performed += OnMoveX;
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, speed*Time.deltaTime*-1));
    }


    void OnMoveX(InputAction.CallbackContext context)
    {
        if (Input.GetMouseButton(0))
        {
            xAxis = context.ReadValue<float>();
            transform.position -= new Vector3(xAxis / 6, 0, 0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -limitX, limitX), transform.position.y, transform.position.z);  
        }

    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }
    private void OnDisable()
    {
        playerInputs.Disable();
    }

}

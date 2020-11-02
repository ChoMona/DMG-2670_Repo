
using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class CharacterMover : MonoBehaviour
{
    
    private CharacterController controller;
    private Vector3 movement;

    public float  rotateSpeed = 30f, gravity = -9.81f, jumpForce = 10f;
    private float yVar;

    public FloatData normalMoveSpeed, fastMoveSpeed;
    private FloatData moveSpeed;
    
    public IntData playerJumpCount;
    private int jumpCount;

    public Vector3Data currentSpawnPoint;
    

   private void Start()
   {
       moveSpeed = normalMoveSpeed;
       controller = GetComponent<CharacterController>();
   }
   

   private void Update()
   {
       //Running when you press down on Shift
       if (Input.GetKeyDown(KeyCode.LeftShift))
       {
           moveSpeed = fastMoveSpeed;
       }

       if (Input.GetKeyUp(KeyCode.LeftShift))
       {
           moveSpeed = normalMoveSpeed;
       }
       
       //Moving back and forth with A and D
       var vInput = Input.GetAxis("Horizontal") * moveSpeed.value;
       movement.Set(vInput, yVar, 0);

       //Rotating with W and S
       var hInput = Input.GetAxis("Vertical") * Time.deltaTime * rotateSpeed;
       transform.Rotate(0, hInput, 0);

       //Pull down force
       yVar += gravity * Time.deltaTime;

       //So Gravity doesnt add onto itself
       if (controller.isGrounded && movement.y < 0)
       {
           yVar = -1f;
           jumpCount = 0;
       }

       //Double Jump
       if (Input.GetButtonDown("Jump") && jumpCount < playerJumpCount.value)
       {
           yVar = jumpForce;
           jumpCount++;
       }

       //Moving not so slow?
       movement = transform.TransformDirection(movement);
       controller.Move(movement * Time.deltaTime);
       
   }

   private void OnEnable()
   {
       transform.position = currentSpawnPoint.value;
   }
}


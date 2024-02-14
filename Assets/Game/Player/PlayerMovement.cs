using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2.0f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] CharacterController controller;

    Transform _transform;
    float velocityY;

    private void Awake()
    {
        // cache transform for performance
        _transform = transform;
    }

    private void Update()
    {
        // if player on ground, set vertical force to 0
        if (controller.isGrounded && velocityY < 0) velocityY = 0f;

        // get relative move vector and apply to character controller
        Vector3 move = Input.GetAxis("Horizontal") * _transform.right + Input.GetAxis("Vertical") * _transform.forward;
        controller.Move(moveSpeed * Time.deltaTime * Vector3.ClampMagnitude(move, 1f));

        // apply gravity continuously
        velocityY += gravity * Time.deltaTime;
        controller.Move(velocityY * Time.deltaTime * Vector3.up);
    }
}

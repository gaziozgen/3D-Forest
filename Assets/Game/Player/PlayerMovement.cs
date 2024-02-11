using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2.0f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] CharacterController controller;

    Transform _transform;
    Vector3 moveVelocity;

    private void Awake()
    {
        // cache transform for performance
        _transform = transform;
    }

    private void Update()
    {
        // if player on ground, set vertical force to 0
        if (controller.isGrounded && moveVelocity.y < 0) moveVelocity.y = 0f;

        // get relative move vector and apply to character controller
        Vector3 move = (Input.GetAxis("Horizontal") * _transform.right + Input.GetAxis("Vertical") * _transform.forward).normalized;
        controller.Move(moveSpeed * Time.deltaTime * move);

        // apply gravity continuously
        moveVelocity.y += gravity * Time.deltaTime;
        controller.Move(moveVelocity * Time.deltaTime);
    }
}

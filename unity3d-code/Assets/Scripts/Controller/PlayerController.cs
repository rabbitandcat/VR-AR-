    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region 声明变量
    private bool p_isJumping = false;
    private float p_jumpForce = 8f;
    private float p_moveSpeed = 30;
    private Vector3 p_movDir = new Vector3();
    private Rigidbody p_rb;
    private float p_movX, p_movZ;
    private float mouseX, mouseY;
    private float p_rotaSpeed=200;
    public Camera mainCamera;
    bool isGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
    #endregion

    private void Start()
    {
        p_rb = GetComponent<Rigidbody>();
        mainCamera.enabled = false;
    }
    private void FixedUpdate()
    {
        Move();
        Jump();
        Rotate();
    }

    #region 移动
    private void Move()
    {
        p_movX = Input.GetAxisRaw("Horizontal");
        p_movZ = Input.GetAxisRaw("Vertical");
        p_movDir.Normalize();
        if (Input.GetKey(KeyCode.W))
        {
            p_movDir = transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            p_movDir = -transform.forward;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            p_movDir = -transform.right;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            p_movDir = transform.right;
        }
        else
        {
            p_movDir = Vector3.zero;
        }
        p_rb.MovePosition(transform.position + p_movDir * p_moveSpeed * Time.deltaTime);
    }
    #endregion

    #region 跳跃
    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            p_rb.velocity += Vector3.up * p_jumpForce;
        }
    }
    #endregion


    #region 旋转
    private void Rotate()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        this.transform.Rotate(Vector3.up * p_rotaSpeed * mouseX * Time.deltaTime);
    }
    #endregion

    
}

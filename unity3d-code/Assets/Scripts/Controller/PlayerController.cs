using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region 数据定义
    private bool p_isJumping = false;
    private float p_jumpForce = 3;
    private float p_moveSpeed = 1.0f;
    private Vector3 p_movDir = new Vector3();
    private Rigidbody p_rb;
    private float p_movX, p_movZ;
    private float mouseX, mouseY;
    private float p_rotaSpeed=200;
    public Camera mainCamera;
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
        transform.position += new Vector3(p_movX, 0.0f, p_movZ) * p_moveSpeed;
        transform.Translate(p_movDir * p_moveSpeed * Time.deltaTime);
    }
    #endregion

    #region 跳跃
    private void Jump()
    {
        if (Input.GetButton("Jump") && p_isJumping == false)
        {
            p_isJumping = true;
            p_rb.velocity += Vector3.up * p_jumpForce;
        }
        if (this.transform.position.y == 1.5)
        {
            p_isJumping = false;
        }
    }
    #endregion

    #region 视角移动
    private void Rotate()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        this.transform.Rotate(Vector3.up * p_rotaSpeed * mouseX * Time.deltaTime);
    }
    #endregion

    
}

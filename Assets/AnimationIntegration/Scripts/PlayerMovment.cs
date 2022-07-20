using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed = 5;


    public Animator anim;


    private bool _isForward = false;
    private bool _isBack = false;
    public static bool canMove = true;
    private bool _Moving = false;

    
    void Update()
    {
        try
        {
            _Moving = false;
            if (canMove)
            {
                if (!(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)))
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        MoveForward(true);
                    }
                    else
                    {

                        _isForward = false;
                    }

                    if (Input.GetKey(KeyCode.S))
                    {
                        MoveForward(false);
                    }
                    else
                    {

                        _isBack = false;
                    }
                }
                else
                {
                    _isForward = false;
                    _isBack = false;
                }

                if (!(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)))
                {
                    if (Input.GetKey(KeyCode.A))
                    {
                        MoveRight(false);
                    }
                    else
                    {

                    }

                    if (Input.GetKey(KeyCode.D))
                    {
                        MoveRight(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            if (_Moving)
                anim.SetBool("MoveForvard", true);
            else
                anim.SetBool("MoveForvard", false);
                

        }
        catch { }
    }

    

    
    void MoveRight(bool isRight)
    {
        if (isRight)
        {
            rb.velocity = Vector3.ClampMagnitude((rb.velocity + (Vector3.forward + -Vector3.right)) * Speed, Speed);
            if (_isForward)
            {
                rb.transform.LookAt(transform.position - Vector3.right);
            }
            else
            {
                if (_isBack)
                {
                    rb.transform.LookAt(transform.position + Vector3.forward);
                }
                else
                    rb.transform.LookAt(transform.position + (Vector3.forward + -Vector3.right));
            }
        }
        else
        {
            rb.velocity = Vector3.ClampMagnitude((rb.velocity + (-Vector3.forward + Vector3.right)) * Speed, Speed);
            if (_isForward)
            {
                rb.transform.LookAt(transform.position - Vector3.forward);
            }
            else
            {
                if (_isBack)
                {
                    rb.transform.LookAt(transform.position + Vector3.right);
                }
                else
                    rb.transform.LookAt(transform.position + (-Vector3.forward + Vector3.right));
            }
        }

        _Moving = true;
    }

    void MoveForward(bool isForward)
    {

        if (isForward)
        {

            rb.velocity = Vector3.ClampMagnitude((rb.velocity + (-Vector3.forward + -Vector3.right)) * Speed, Speed);
            rb.transform.LookAt(transform.position + (-Vector3.forward + -Vector3.right));
            _isForward = true;
            
        }
        else
        {
            rb.velocity = Vector3.ClampMagnitude((rb.velocity + (Vector3.forward + Vector3.right)) * Speed, Speed);
            rb.transform.LookAt(transform.position + (Vector3.forward + Vector3.right));
            _isBack = true;
            
        }
        _Moving = true;
    }
}

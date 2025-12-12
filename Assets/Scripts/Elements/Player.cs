using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed;
    public bool isAppleCollected=false;
    public Enemy enemy;
    public GameDirector gameDirector;
    public bool canMove = true;
    public bool isCharacterWalk;
    public Animator animator;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            isAppleCollected = true;
            gameDirector.levelManager.ShowDoor();
            
        }
        if (other.CompareTag("Door") && isAppleCollected)
        {
            gameDirector.LevelCompleted();
            canMove = false;
            

        }
        if (isAppleCollected)
        {                    
            print("Go to the door!!!");
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            gameDirector.LevelCompleted();
            print("Mission Failed!");
        }
    }


    void Update()
    {
        if (!canMove)
        {
            _rb.velocity = Vector3.zero;
        }
        if (canMove) { 
        var direction=Vector3.zero;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5;
            RunAnimation(2f);
        }
        else
        {
            speed = 2.5f;
                RunAnimation(1f);
         }
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
            WalkAnimation();
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
            WalkAnimation();
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
            WalkAnimation();
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
            WalkAnimation();
        }
            if (!Input.GetKey(KeyCode.W)
               && !Input.GetKey(KeyCode.S)
               && !Input.GetKey(KeyCode.A)
        && !Input.GetKey(KeyCode.D))
            {
                IdleAnimation();
            }

            transform.LookAt(transform.position + direction);
        _rb.velocity = direction.normalized * speed;
     }
        

    }
    public void WalkAnimation()
    {
        if (!isCharacterWalk)
        {
           
            animator.SetTrigger("Walk");
            isCharacterWalk = true;
        }
    }
    public void IdleAnimation()
    {
        if (isCharacterWalk)
        {
            animator.SetTrigger("Idle");
            isCharacterWalk=false;
        }
    }
    public void RunAnimation(float value)
    {
        animator.SetFloat("Run",value);
    }

}

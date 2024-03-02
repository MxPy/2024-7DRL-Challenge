using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


//TODO: Rename to PlayerController
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 2.5f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject bullet;
    //public Animator animator;
    Vector2 movement;
    
    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.LeftArrow)){
           shoot(0);
        } 
        else if (Input.GetKeyDown(KeyCode.UpArrow)){
           shoot(1);
        } 
        else if (Input.GetKeyDown(KeyCode.RightArrow)){
           shoot(2);
        } 
        else if (Input.GetKeyDown(KeyCode.DownArrow)){
           shoot(3);
        } 
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        
    }

    private void shoot(uint direction){
        Bullet bulletInstance = null;
        switch(direction){
            case 0:
                bulletInstance = Instantiate(bullet,transform.position+Vector3.left, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.left);
                break;
            case 1:
                bulletInstance = Instantiate(bullet,transform.position+Vector3.up, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.up);
                break;
            case 2:
                bulletInstance = Instantiate(bullet,transform.position+Vector3.right, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.right);
                break;
            case 3:
                bulletInstance = Instantiate(bullet,transform.position+Vector3.down, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.down);
                break;
            }
           
    }

}

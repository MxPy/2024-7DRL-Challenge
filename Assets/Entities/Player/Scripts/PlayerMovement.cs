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
    [SerializeField] GameObject attackHitbox;
    [SerializeField] int type = 0;
    [SerializeField] int HP = 12;
    VariableTimer attackTimer;
    //public Animator animator;
    Vector2 movement;

    int dmgModifier = 1;
    int dmgModifierUpgrade  = 2;
    int movmentModifier = 0;
    int movmentModifierUpgrade  = 0;
    int otherModifier = 0;
    int otherModifierUpgrade  = 0;
    private void Start() {
        attackTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
    }

    public void SetDmgModifier(int dmgModifier){
        dmgModifierUpgrade = 0;
        this.dmgModifier = dmgModifier;
    }
    
    void Update()
    {
        switch(movmentModifier) {
        case 0:
            DefaultMovment();
            break;
        case 1:
            // code block
            break;
        case 2:
            // code block
            break;
        case 3:
            // code block
            break;
        case 4:
            // code block
            break;
        case 5:
            // code block
            break;
        default:
            // code block
            break;
        }
        switch(dmgModifier) {
        case 0:
            DefaultDmg();
            break;
        case 1:
            TwoWayDMG();
            break;
        case 2:
            TripleDmg();
            break;
        case 3:
            // code block
            break;
        case 4:
            // code block
            break;
        case 5:
            // code block
            break;
        default:
            // code block
            break;
        }

        

        if(HP<= 0){
            Destroy(gameObject);
        }
    }

    private void DefaultMovment(){
        switch(movmentModifierUpgrade) {
        case 0:
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            break;
        case 1:
            // code block
            break;
        case 2:
            // code block
        
        default:
            // code block
            break;
        }
        
    }

    private void DefaultDmg(){
        switch(dmgModifierUpgrade) {
        case 0:
                //TODO: change attack cooldown time
            if (Input.GetKeyDown(KeyCode.LeftArrow) && attackTimer.started == false){
                attackTimer.StartTimer(1);
                if(type == 0) shoot(0);
                else if(type == 1) attack(0);
            } 
            else if (Input.GetKeyDown(KeyCode.UpArrow) && attackTimer.started == false){
                attackTimer.StartTimer(1);
                if(type == 0) shoot(1);
                else if(type == 1) attack(1);
            } 
            else if (Input.GetKeyDown(KeyCode.RightArrow) && attackTimer.started == false){
                attackTimer.StartTimer(1);
                if(type == 0) shoot(2);
                else if(type == 1) attack(2);
            } 
            else if (Input.GetKeyDown(KeyCode.DownArrow) && attackTimer.started == false){
                attackTimer.StartTimer(1);
                if(type == 0) shoot(3);
                else if(type == 1) attack(3);
            }
            if(attackTimer.finished){
                attackTimer.ResetTimer();
            }
            break;
        case 1:
            // code block
            break;
        case 2:
            // code block
        
        default:
            // code block
            break;
        }
    }

    private void TwoWayDMG(){
        switch(dmgModifierUpgrade) {
        case 0:
                //TODO: change attack cooldown time
            if (attackTimer.started == false  && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))){
                attackTimer.StartTimer(1);
                if(type == 0){
                    shoot(0);
                    shoot(2);
                } 
                else if(type == 1){
                    attack(0);
                    attack(2);
                } 
            } 
            else if (attackTimer.started == false && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) )){
                attackTimer.StartTimer(1);
                if(type == 0){
                    shoot(1);
                    shoot(3);
                } 
                else if(type == 1){
                    attack(1);
                    attack(3);
                } 
            } 
            if(attackTimer.finished){
                attackTimer.ResetTimer();
            }
            break;
        case 1:
                //TODO: change attack cooldown time
            if (attackTimer.started == false  && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) )){
                attackTimer.StartTimer(1);
                if(type == 0){
                    shoot(0);
                    shoot(2);
                    shoot(1);
                    shoot(3);
                } 
                else if(type == 1){
                    attack(0);
                    attack(2);
                    attack(1);
                    attack(3);
                } 
            }  
            if(attackTimer.finished){
                attackTimer.ResetTimer();
            }
            break;
        case 2:
            
                //TODO: change attack cooldown time
            if (attackTimer.started == false  && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) )){
                attackTimer.StartTimer(1);
                if(type == 0){
                    shoot(0);
                    shoot(2);
                    shoot(1);
                    shoot(3);
                    shoot(4);
                    shoot(5);
                    shoot(6);
                    shoot(7);
                } 
                else if(type == 1){
                    attack(0);
                    attack(2);
                    attack(1);
                    attack(3);
                    attack(4);
                    attack(5);
                    attack(6);
                    attack(7);
                } 
            }  
            if(attackTimer.finished){
                attackTimer.ResetTimer();
            }
            break;
        default:
            // code block
            break;
        }
    }
    private void TripleDmg(){
        switch(dmgModifierUpgrade) {
        case 0:
                //TODO: change attack cooldown time
            if (Input.GetKeyDown(KeyCode.LeftArrow) && attackTimer.started == false){
                attackTimer.StartTimer(1);
                if(type == 0){
                    shoot(Vector3.left+(Vector3.up/2));
                    shoot(Vector3.left+(Vector3.down/2));
                } 
                else if(type == 1){
                    attack(Vector3.left+(Vector3.up/2));
                    attack(Vector3.left+(Vector3.down/2));
                } 
            } 
            else if (Input.GetKeyDown(KeyCode.UpArrow) && attackTimer.started == false){
                attackTimer.StartTimer(1);
                if(type == 0){
                    shoot(Vector3.up+(Vector3.left/2));
                    shoot(Vector3.up+(Vector3.right/2));
                } 
                else if(type == 1){
                    attack(Vector3.up+(Vector3.left/2));
                    attack(Vector3.up+(Vector3.right/2));
                }
                
            } 
            else if (Input.GetKeyDown(KeyCode.RightArrow) && attackTimer.started == false){
                attackTimer.StartTimer(1);
                if(type == 0){
                    shoot(Vector3.right+(Vector3.up/2));
                    shoot(Vector3.right+(Vector3.down/2));
                } 
                else if(type == 1){
                    attack(Vector3.right+(Vector3.up/2));
                    attack(Vector3.right+(Vector3.down/2));
                }
            } 
            else if (Input.GetKeyDown(KeyCode.DownArrow) && attackTimer.started == false){
                attackTimer.StartTimer(1);
                if(type == 0){
                    shoot(Vector3.down+(Vector3.left/2));
                    shoot(Vector3.down+(Vector3.right/2));
                } 
                else if(type == 1){
                    attack(Vector3.down+(Vector3.left/2));
                    attack(Vector3.down+(Vector3.right/2));
                }
            }
            if(attackTimer.finished){
                attackTimer.ResetTimer();
            }
            break;
        case 1:
                //TODO: change attack cooldown time
            if (Input.GetKeyDown(KeyCode.LeftArrow) && attackTimer.started == false){
                attackTimer.StartTimer(1);
                if(type == 0){
                    shoot(Vector3.left+(Vector3.up/2));
                    shoot(Vector3.left+(Vector3.down/2));
                    shoot(Vector3.left+(Vector3.up*0.25f));
                    shoot(Vector3.left+(Vector3.down*0.25f));
                } 
                else if(type == 1){
                    attack(Vector3.left+(Vector3.up/2));
                    attack(Vector3.left+(Vector3.down/2));
                    attack(Vector3.left+(Vector3.up*0.25f));
                    attack(Vector3.left+(Vector3.down*0.25f));
                } 
            } 
            else if (Input.GetKeyDown(KeyCode.UpArrow) && attackTimer.started == false){
                attackTimer.StartTimer(1);
                if(type == 0){
                    shoot(Vector3.up+(Vector3.left/2));
                    shoot(Vector3.up+(Vector3.right/2));
                    shoot(Vector3.up+(Vector3.left*0.25f));
                    shoot(Vector3.up+(Vector3.right*0.25f));
                } 
                else if(type == 1){
                    attack(Vector3.up+(Vector3.left/2));
                    attack(Vector3.up+(Vector3.right/2));
                    attack(Vector3.up+(Vector3.left*0.25f));
                    attack(Vector3.up+(Vector3.right*0.25f));
                }
                
            } 
            else if (Input.GetKeyDown(KeyCode.RightArrow) && attackTimer.started == false){
                attackTimer.StartTimer(1);
                if(type == 0){
                    shoot(Vector3.right+(Vector3.up/2));
                    shoot(Vector3.right+(Vector3.down/2));
                    shoot(Vector3.right+(Vector3.up*0.25f));
                    shoot(Vector3.right+(Vector3.down*0.25f));
                } 
                else if(type == 1){
                    attack(Vector3.right+(Vector3.up/2));
                    attack(Vector3.right+(Vector3.down/2));
                    attack(Vector3.right+(Vector3.up*0.25f));
                    attack(Vector3.right+(Vector3.down*0.25f));
                }
            } 
            else if (Input.GetKeyDown(KeyCode.DownArrow) && attackTimer.started == false){
                attackTimer.StartTimer(1);
                if(type == 0){
                    shoot(Vector3.down+(Vector3.left/2));
                    shoot(Vector3.down+(Vector3.right/2));
                    shoot(Vector3.down+(Vector3.left*0.25f));
                    shoot(Vector3.down+(Vector3.right*0.25f));
                } 
                else if(type == 1){
                    attack(Vector3.down+(Vector3.left/2));
                    attack(Vector3.down+(Vector3.right/2));
                    attack(Vector3.down+(Vector3.left*0.25f));
                    attack(Vector3.down+(Vector3.right*0.25f));
                }
            }
            if(attackTimer.finished){
                attackTimer.ResetTimer();
            }
            break;
        case 2:
                //TODO: change attack cooldown time
            if (Input.GetKeyDown(KeyCode.LeftArrow) && attackTimer.started == false){
                attackTimer.StartTimer(1);
                if(type == 0){
                    shoot(Vector3.left+(Vector3.up/2));
                    shoot(Vector3.left+(Vector3.down/2));
                    shoot(Vector3.left+(Vector3.up*0.25f));
                    shoot(Vector3.left+(Vector3.down*0.25f));
                    shoot(Vector3.left+(Vector3.up*0.125f));
                    shoot(Vector3.left+(Vector3.down*0.125f));
                } 
                else if(type == 1){
                    attack(Vector3.left+(Vector3.up/2));
                    attack(Vector3.left+(Vector3.down/2));
                    attack(Vector3.left+(Vector3.up*0.25f));
                    attack(Vector3.left+(Vector3.down*0.25f));
                    attack(Vector3.left+(Vector3.up*0.125f));
                    attack(Vector3.left+(Vector3.down*0.125f));
                } 
            } 
            else if (Input.GetKeyDown(KeyCode.UpArrow) && attackTimer.started == false){
                attackTimer.StartTimer(1);
                if(type == 0){
                    shoot(Vector3.up+(Vector3.left/2));
                    shoot(Vector3.up+(Vector3.right/2));
                    shoot(Vector3.up+(Vector3.left*0.25f));
                    shoot(Vector3.up+(Vector3.right*0.25f));
                    shoot(Vector3.up+(Vector3.left*0.125f));
                    shoot(Vector3.up+(Vector3.right*0.125f));
                } 
                else if(type == 1){
                    attack(Vector3.up+(Vector3.left/2));
                    attack(Vector3.up+(Vector3.right/2));
                    attack(Vector3.up+(Vector3.left*0.25f));
                    attack(Vector3.up+(Vector3.right*0.25f));
                    attack(Vector3.up+(Vector3.left*0.125f));
                    attack(Vector3.up+(Vector3.right*0.125f));
                }
                
            } 
            else if (Input.GetKeyDown(KeyCode.RightArrow) && attackTimer.started == false){
                attackTimer.StartTimer(1);
                if(type == 0){
                    shoot(Vector3.right+(Vector3.up/2));
                    shoot(Vector3.right+(Vector3.down/2));
                    shoot(Vector3.right+(Vector3.up*0.25f));
                    shoot(Vector3.right+(Vector3.down*0.25f));
                    shoot(Vector3.right+(Vector3.up*0.125f));
                    shoot(Vector3.right+(Vector3.down*0.125f));
                } 
                else if(type == 1){
                    attack(Vector3.right+(Vector3.up/2));
                    attack(Vector3.right+(Vector3.down/2));
                    attack(Vector3.right+(Vector3.up*0.25f));
                    attack(Vector3.right+(Vector3.down*0.25f));
                    attack(Vector3.right+(Vector3.up*0.125f));
                    attack(Vector3.right+(Vector3.down*0.125f));
                }
            } 
            else if (Input.GetKeyDown(KeyCode.DownArrow) && attackTimer.started == false){
                attackTimer.StartTimer(1);
                if(type == 0){
                    shoot(Vector3.down+(Vector3.left/2));
                    shoot(Vector3.down+(Vector3.right/2));
                    shoot(Vector3.down+(Vector3.left*0.25f));
                    shoot(Vector3.down+(Vector3.right*0.25f));
                    shoot(Vector3.down+(Vector3.left*0.125f));
                    shoot(Vector3.down+(Vector3.right*0.125f));
                    
                } 
                else if(type == 1){
                    attack(Vector3.down+(Vector3.left/2));
                    attack(Vector3.down+(Vector3.right/2));
                    attack(Vector3.down+(Vector3.left*0.25f));
                    attack(Vector3.down+(Vector3.right*0.25f));
                    attack(Vector3.down+(Vector3.left*0.125f));
                    attack(Vector3.down+(Vector3.right*0.125f));
                }
            }
            if(attackTimer.finished){
                attackTimer.ResetTimer();
            }
            break;
        default:
            // code block
            break;
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
                bulletInstance.Setup(Vector3.left, 2, 0.2f);
                break;
            case 1:
                bulletInstance = Instantiate(bullet,transform.position+Vector3.up, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.up, 2, 0.2f);
                break;
            case 2:
                bulletInstance = Instantiate(bullet,transform.position+Vector3.right, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.right, 2, 0.2f);
                break;
            case 3:
                bulletInstance = Instantiate(bullet,transform.position+Vector3.down, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.down, 2, 0.2f);
                break;
            case 4:
                bulletInstance = Instantiate(bullet,transform.position+Vector3.left+Vector3.up, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.left+Vector3.up, 2, 0.2f);
                break;
            case 5:
                bulletInstance = Instantiate(bullet,transform.position+Vector3.up+Vector3.right, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.up+Vector3.right, 2, 0.2f);
                break;
            case 6:
                bulletInstance = Instantiate(bullet,transform.position+Vector3.right+Vector3.down, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.right+Vector3.down, 2, 0.2f);
                break;
            case 7:
                bulletInstance = Instantiate(bullet,transform.position+Vector3.down+Vector3.left, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.down+Vector3.left, 2, 0.2f);
                break;
            
            }
    }
    //custom shot
    private void shoot(Vector3 direction){
        Bullet bulletInstance = Instantiate(bullet,transform.position+direction, transform.rotation).GetComponent<Bullet>();
        bulletInstance.Setup(direction, 2, 0.2f);
    }
    //custom attack
    private void attack(Vector3 direction){
        Attack attackInstance = Instantiate(bullet,transform.position+direction, transform.rotation).GetComponent<Attack>();
        attackInstance.Setup(direction, 2, 0.2f);
    }
    private void attack(uint direction){
        Attack attackInstance = null;
        switch(direction){
            case 0:
                attackInstance = Instantiate(attackHitbox,transform.position+Vector3.left, transform.rotation).GetComponent<Attack>();
                attackInstance.Setup(Vector3.left, 2, 0.2f);
                break;
            case 1:
                attackInstance = Instantiate(attackHitbox,transform.position+Vector3.up, transform.rotation).GetComponent<Attack>();
                attackInstance.Setup(Vector3.up, 2, 0.2f);
                break;
            case 2:
                attackInstance = Instantiate(attackHitbox,transform.position+Vector3.right, transform.rotation).GetComponent<Attack>();
                attackInstance.Setup(Vector3.right, 2, 0.2f);
                break;
            case 3:
                attackInstance = Instantiate(attackHitbox,transform.position+Vector3.down, transform.rotation).GetComponent<Attack>();
                attackInstance.Setup(Vector3.down, 2, 0.2f);
                break;
            case 4:
                attackInstance = Instantiate(attackHitbox,transform.position+Vector3.left+Vector3.up, transform.rotation).GetComponent<Attack>();
                attackInstance.Setup(Vector3.left+Vector3.up, 2, 0.2f);
                break;
            case 5:
                attackInstance = Instantiate(attackHitbox,transform.position+Vector3.up+Vector3.right, transform.rotation).GetComponent<Attack>();
                attackInstance.Setup(Vector3.up+Vector3.right, 2, 0.2f);
                break;
            case 6:
                attackInstance = Instantiate(attackHitbox,transform.position+Vector3.right+Vector3.down, transform.rotation).GetComponent<Attack>();
                attackInstance.Setup(Vector3.right+Vector3.down, 2, 0.2f);
                break;
            case 7:
                attackInstance = Instantiate(attackHitbox,transform.position+Vector3.down+Vector3.left, transform.rotation).GetComponent<Attack>();
                attackInstance.Setup(Vector3.down+Vector3.left, 2, 0.2f);
                break;
            }
            
    }

    public void Damage(int dmgValue, float stunTime = 0.2f){
        HP -= dmgValue;
        //stunTimer.StartTimer(stunTime);
        
    }
}

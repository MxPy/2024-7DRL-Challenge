using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainBoss : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int HP;
    [SerializeField] int maxHP = 100;
    [SerializeField] GameObject bullet;
    public Transform target;
    public GameObject item;

    //temp public
    public int phase = 0;
    int shootCunter = 0;
    VariableTimer delayTimer;
    VariableTimer phaseShootTimer;
    VariableTimer specialAttackTimer;
    VariableTimer specialAttackTimerChuj;
    VariableTimer specialAttackTimerChujChuj;
    VariableTimer specialAttackTimerChujChujChuj;
    [SerializeField] float specialAttackTime = 5;
    [SerializeField] float specialAttackTimeChuj = 2f;
    [SerializeField] float specialAttackTimeChujChuj = 1.0f;
    [SerializeField] float specialAttackTimeChujChujChuj = 0.2f;
    bool notInvincible = true;
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField]float cooldownTime = 1.5f;
    [SerializeField]float attackTime = 2.0f;
    [SerializeField]float delayTime = 0.2f;
    
    [SerializeField] GameObject hitboxLeftTop, hitboxLeftBottom, hitboxRightTop, hitboxRightBottom, sad, das, kal, all;
    [SerializeField] int specialAttackCounter = 0;
    [SerializeField] SpriteRenderer ren;
    [SerializeField] BoxCollider2D col;
    [SerializeField] Animator animator;
    


    private void Start() {
        HP = maxHP;
        phaseShootTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        delayTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        specialAttackTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        specialAttackTimerChuj = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        specialAttackTimerChujChuj = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        specialAttackTimerChujChujChuj = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        hitboxLeftTop.GetComponent<Attack>().Setup(new Vector3(0,0,0), 5, 0.2f, false, false);
        hitboxLeftBottom.GetComponent<Attack>().Setup(new Vector3(0,0,0), 5, 0.2f, false, false);
        hitboxRightTop.GetComponent<Attack>().Setup(new Vector3(0,0,0), 5, 0.2f, false, false);
        hitboxRightBottom.GetComponent<Attack>().Setup(new Vector3(0,0,0), 5, 0.2f, false, false);
        hitboxLeftTop.SetActive(false);
        hitboxLeftBottom.SetActive(false);
        hitboxRightTop.SetActive(false);
        hitboxRightBottom.SetActive(false);

        sad.GetComponent<Attack>().Setup(new Vector3(0,0,0), 5, 0.2f, false, false);
        das.GetComponent<Attack>().Setup(new Vector3(0,0,0), 5, 0.2f, false, false);
        kal.GetComponent<Attack>().Setup(new Vector3(0,0,0), 5, 0.2f, false, false);
        sad.SetActive(false);
        das.SetActive(false);
        kal.SetActive(false);

        all.GetComponent<Attack>().Setup(new Vector3(0,0,0), 5, 0.2f, false, false);
        all.SetActive(false);


        specialAttackTimerChuj.StartTimer(5);
    }

    private void Update() {
        if(specialAttackTimerChuj.finished == false && specialAttackTimerChuj.started == true){
            switch(phase) {
            case 0:
                PhaseTwo();
                break;
            case 1:
                PhaseTwo();
                //this.maxHP += 3;
                break;
            case 2:
                //this.attackSpeed -= 0.5f;
                break;
        }
            if(HP <= maxHP/2 && phase == 0){
                phase = 1;
                phaseShootTimer.ResetTimer();
                delayTimer.ResetTimer();
                attackTime *= 2;
                shootCunter = 0;
            }
        }
        if(specialAttackTimerChuj.finished == true){
            notInvincible = false;
            SpecialAttack();
        }
        
        if(HP <= 0){
            Death();
        }
    }
    private void SpecialAttack(){
        if(specialAttackTimerChujChuj.started == false && specialAttackTimerChujChuj.finished == false){
            specialAttackTimerChujChuj.StartTimer(specialAttackTimeChujChuj);
            animator.SetBool("attack", true);
        } 
        switch(specialAttackCounter) {
        case 0:
            SpecialAttackDmg(hitboxLeftTop);
            break;
        case 1:
            SpecialAttackDmg(hitboxLeftBottom);
            break;
        case 2:
            SpecialAttackDmg(hitboxRightBottom);
            break;
        case 3:
            SpecialAttackDmg(hitboxRightTop);
            break;
        case 4:
            SpecialAttackDmg(sad);
            break;
        case 5:
            SpecialAttackDmg(das);
            break;
        case 6:
            SpecialAttackDmg(kal);
            break;
        case 7:
            SpecialAttackDmg(all);
            break;
        case 8:
            notInvincible = true;
            specialAttackCounter = 0;
            specialAttackTimerChuj.ResetTimer();
            specialAttackTimerChuj.StartTimer(5);
            animator.SetBool("attack2", false);
            animator.SetBool("attack", false);
            //ren.enabled = true;
            //col.enabled = true;
            break;
        }   
           
    }

    private void SpecialAttackDmg(GameObject hitboxLeftTop){
        
        if(specialAttackTimerChujChuj.finished == true && specialAttackTimerChujChujChuj.started == false && specialAttackTimerChujChujChuj.finished == false){
            animator.SetBool("attack2", true);
            animator.SetBool("attack", false);
            hitboxLeftTop.SetActive(true);
            specialAttackTimerChujChujChuj.StartTimer(specialAttackTimeChujChujChuj);
        }
        if(specialAttackTimerChujChujChuj.finished == true){
            //Debug.Log("chujsa");
            specialAttackTimerChujChuj.ResetTimer();
            specialAttackTimerChujChujChuj.ResetTimer();
            hitboxLeftTop.SetActive(false);
            specialAttackCounter++;
        }
        
    }
    private void PhaseOne(){
        
        if(shootCunter == 0){
            if(delayTimer.started == false){
                delayTimer.StartTimer(delayTime);
                Bullet bulletInstance = Instantiate(bullet,transform.position+Vector3.left, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.left, 2, 0.2f,bulletSpeed, false);
                bulletInstance = Instantiate(bullet,transform.position+Vector3.right, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.right, 2, 0.2f,bulletSpeed, false);
                if(phaseShootTimer.started == false) phaseShootTimer.StartTimer(attackTime);
            }
        }
        
        if(shootCunter == 1){
            if(delayTimer.started == false){
            delayTimer.StartTimer(delayTime);
                Bullet bulletInstance = Instantiate(bullet,transform.position+Vector3.left+Vector3.down, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.left+Vector3.down, 2, 0.2f,bulletSpeed, false);
                bulletInstance = Instantiate(bullet,transform.position+Vector3.right+Vector3.up, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.right+Vector3.up, 2, 0.2f,bulletSpeed, false);
                if(phaseShootTimer.started == false) phaseShootTimer.StartTimer(attackTime);
            }
        }

        if(shootCunter == 2){
            if(delayTimer.started == false){
            delayTimer.StartTimer(delayTime);
                Bullet bulletInstance = Instantiate(bullet,transform.position+Vector3.down, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.down, 2, 0.2f,bulletSpeed, false);
                bulletInstance = Instantiate(bullet,transform.position+Vector3.up, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.up, 2, 0.2f,bulletSpeed, false);
                if(phaseShootTimer.started == false) phaseShootTimer.StartTimer(attackTime);
            }
        }

        if(shootCunter == 3){
            if(delayTimer.started == false){
            delayTimer.StartTimer(delayTime);
                Bullet bulletInstance = Instantiate(bullet,transform.position+Vector3.right+Vector3.down, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.right+Vector3.down, 2, 0.2f,bulletSpeed, false);
                bulletInstance = Instantiate(bullet,transform.position+Vector3.left+Vector3.up, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.left+Vector3.up, 2, 0.2f,bulletSpeed, false);
                if(phaseShootTimer.started == false) phaseShootTimer.StartTimer(attackTime);
            }
        }

        if(phaseShootTimer.finished == true){
            shootCunter++;
            phaseShootTimer.ResetTimer();
            if(shootCunter == 4) shootCunter = 0;
        }
        if(delayTimer.finished == true){
            delayTimer.ResetTimer();
        }
    }

    private void PhaseTwo(){
        //Debug.Log("chujj");
        if(shootCunter == 0){
            if(delayTimer.started == false){
                delayTimer.StartTimer(delayTime);
                Bullet bulletInstance = Instantiate(bullet,transform.position+Vector3.left, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.left, 2, 0.2f,bulletSpeed, false);
                bulletInstance = Instantiate(bullet,transform.position+Vector3.right, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.right, 2, 0.2f,bulletSpeed, false);
                bulletInstance = Instantiate(bullet,transform.position+Vector3.down, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.down, 2, 0.2f,bulletSpeed, false);
                bulletInstance = Instantiate(bullet,transform.position+Vector3.up, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.up, 2, 0.2f,bulletSpeed, false);
                if(phaseShootTimer.started == false) phaseShootTimer.StartTimer(attackTime);
            }
        }
        
        if(shootCunter == 1){
            if(delayTimer.started == false){
            delayTimer.StartTimer(delayTime);
                Bullet bulletInstance = Instantiate(bullet,transform.position+Vector3.left+Vector3.down, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.left+Vector3.down, 2, 0.2f,bulletSpeed, false);
                bulletInstance = Instantiate(bullet,transform.position+Vector3.right+Vector3.up, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.right+Vector3.up, 2, 0.2f,bulletSpeed, false);
                bulletInstance = Instantiate(bullet,transform.position+Vector3.right+Vector3.down, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.right+Vector3.down, 2, 0.2f,bulletSpeed, false);
                bulletInstance = Instantiate(bullet,transform.position+Vector3.left+Vector3.up, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(Vector3.left+Vector3.up, 2, 0.2f,bulletSpeed, false);
                if(phaseShootTimer.started == false) phaseShootTimer.StartTimer(attackTime);
            }
        }

        if(phaseShootTimer.finished == true){
            Bullet bulletInstance = Instantiate(bullet,transform.position-(transform.position - target.position).normalized, transform.rotation).GetComponent<Bullet>();
            bulletInstance.Setup(-(transform.position - target.position).normalized, 2, 0.2f, 10f, false);
            bulletInstance = Instantiate(bullet,transform.position-(transform.position - target.position).normalized, transform.rotation).GetComponent<Bullet>();
            bulletInstance.Setup(-(transform.position - target.position).normalized, 2, 0.2f, 10f, false);
            bulletInstance = Instantiate(bullet,transform.position-(transform.position - target.position).normalized, transform.rotation).GetComponent<Bullet>();
            bulletInstance.Setup(-(transform.position - target.position).normalized, 2, 0.2f, 10f, false);
            shootCunter++;
            phaseShootTimer.ResetTimer();
            if(shootCunter == 2) shootCunter = 0;
        }
        if(delayTimer.finished == true){
            delayTimer.ResetTimer();
        }

        
        
    }
    
    public void Death(){
        LevelManager lvl = GameObject.FindGameObjectsWithTag("LevelManager")[0].GetComponent<LevelManager>();
        
        Generator gen = GameObject.FindGameObjectsWithTag("LevelManager")[0].GetComponent<Generator>();
        gen.isBoss = false;
        Destroy(gameObject);
        item.SetActive(true);
    }

    public void Damage(int dmgValue, float stunTime = 0.2f){
        //Debug.Log("chuj");
        if(notInvincible) HP -= dmgValue;
        //stunTimer.StartTimer(stunTime);
    }
}


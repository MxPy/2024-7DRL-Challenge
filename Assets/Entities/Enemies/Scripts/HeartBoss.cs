using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class HeartBoss : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int HP;
    [SerializeField] int maxHP = 100;
    [SerializeField] GameObject bullet;
    public Transform target;

    //temp public
    public int phase = 0;
    int shootCunter = 0;
    VariableTimer delayTimer;
    VariableTimer phaseShootTimer;
    VariableTimer specialAttackTimer;
    VariableTimer specialAttackTimerChuj;
    VariableTimer specialAttackTimerChujChuj;
    VariableTimer specialAttackTimerChujChujChuj;
    bool notInvincible = true;
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField]float cooldownTime = 1.5f;
    [SerializeField]float attackTime = 2.0f;
    [SerializeField]float delayTime = 0.2f;
    [SerializeField] float specialAttackTime = 5;
    [SerializeField] float specialAttackTimeChuj = 2f;
    [SerializeField] float specialAttackTimeChujChuj = 1.0f;
    [SerializeField] float specialAttackTimeChujChujChuj = 0.2f;
    [SerializeField] GameObject animLeftTop, animLeftBottom, animRightTop, animRightBottom;
    [SerializeField] GameObject hitboxLeftTop, hitboxLeftBottom, hitboxRightTop, hitboxRightBottom;
    [SerializeField] int specialAttackCounter = 0;
    [SerializeField] SpriteRenderer ren;
    [SerializeField] BoxCollider2D col;
    


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

        animLeftTop.SetActive(false);
        animLeftBottom.SetActive(false);
        animRightTop.SetActive(false);
        animRightBottom.SetActive(false);

        specialAttackTimerChuj.StartTimer(5);
    }

    private void Update() {
        if(specialAttackTimerChuj.finished == false && specialAttackTimerChuj.started == true){
            switch(phase) {
            case 0:
                PhaseOne();
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
            ren.enabled = false;
            col.enabled = false;
            notInvincible = false;
            SpecialAttack();
        }
        
        if(HP <= 0){
            Destroy(gameObject);
        }
    }
    private void SpecialAttack(){
        
        switch(specialAttackCounter) {
        case 0:
            SpecialAttackDmg(animLeftTop, hitboxLeftTop);
            break;
        case 1:
            SpecialAttackDmg(animLeftBottom, hitboxLeftBottom);
            break;
        case 2:
            SpecialAttackDmg(animRightBottom, hitboxRightBottom);
            break;
        case 3:
            SpecialAttackDmg(animRightTop, hitboxRightTop);
            break;
        case 4:
            notInvincible = true;
            specialAttackCounter = 0;
            specialAttackTimerChuj.ResetTimer();
            specialAttackTimerChuj.StartTimer(5);
            ren.enabled = true;
            col.enabled = true;
            break;
        }   
           
    }

    private void SpecialAttackDmg(GameObject animLeftTop, GameObject hitboxLeftTop){
        
        if(specialAttackTimerChujChuj.started == false && specialAttackTimerChujChuj.finished == false){
            specialAttackTimerChujChuj.StartTimer(specialAttackTimeChujChuj);
            animLeftTop.SetActive(true);
        } 
        if(specialAttackTimerChujChuj.finished == true && specialAttackTimerChujChujChuj.started == false && specialAttackTimerChujChujChuj.finished == false){
            animLeftTop.SetActive(false);
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
            shootCunter++;
            phaseShootTimer.ResetTimer();
            if(shootCunter == 2) shootCunter = 0;
        }
        if(delayTimer.finished == true){
            delayTimer.ResetTimer();
        }

        
        
    }
    

    public void Damage(int dmgValue, float stunTime = 0.2f){
        //Debug.Log("chuj");
        if(notInvincible) HP -= dmgValue;
        //stunTimer.StartTimer(stunTime);
    }
}

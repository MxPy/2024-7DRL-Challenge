using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PneuBoss : MonoBehaviour
{
    [SerializeField] int HP;
    [SerializeField] int maxHP = 100;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
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
    [SerializeField]float delayTime = 1f;
    [SerializeField] float specialAttackTime = 5;
    [SerializeField] float specialAttackTimeChuj = 2f;
    [SerializeField] float specialAttackTimeChujChuj = 1.0f;
    [SerializeField] float specialAttackTimeChujChujChuj = 0.2f;
    [SerializeField] GameObject animLeft, animBottom, animTop, animRight;
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


        animLeft.GetComponent<Attack>().Setup(new Vector3(0,0,0), 200, 0.2f, false, false);
        animBottom.GetComponent<Attack>().Setup(new Vector3(0,0,0), 200, 0.2f, false, false);
        animTop.GetComponent<Attack>().Setup(new Vector3(0,0,0), 200, 0.2f, false, false);
        animRight.GetComponent<Attack>().Setup(new Vector3(0,0,0), 200, 0.2f, false, false);


        animLeft.SetActive(false);
        animBottom.SetActive(false);
        animTop.SetActive(false);
        animRight.SetActive(false);

        specialAttackTimerChuj.StartTimer(10);
        specialAttackTimer.StartTimer(9);
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
            // if(HP <= maxHP/2 && phase == 0){
            //     phase = 1;
            //     phaseShootTimer.ResetTimer();
            //     delayTimer.ResetTimer();
            //     attackTime *= 2;
            //     shootCunter = 0;
            // }
        }
        if(specialAttackTimerChuj.finished == true){
            SpecialAttack();
        }
        if(specialAttackTimer.finished == true){
            animator.SetBool("attack", true);
        }
        
        if(HP <= 0){
            Destroy(gameObject);
        }
    }
    private void SpecialAttack(){
        
        if(specialAttackTimerChujChuj.started == false) {
            specialAttackTimerChujChuj.StartTimer(2);
            animLeft.SetActive(true);
            animBottom.SetActive(true);
            animTop.SetActive(true);
            animRight.SetActive(true);
        }
        if(specialAttackTimerChujChuj.finished == true && specialAttackTimerChujChuj.started == true){
            animator.SetBool("attack", false);
            animLeft.SetActive(false);
            animBottom.SetActive(false);
            animTop.SetActive(false);
            animRight.SetActive(false);
            specialAttackTimerChuj.ResetTimer();
            specialAttackTimer.ResetTimer();
            specialAttackTimerChuj.StartTimer(10);
            specialAttackTimer.StartTimer(9);
        }  
    }

    private void PhaseOne(){
        
        if(shootCunter == 0 || shootCunter == 1 || shootCunter == 2){
            if(delayTimer.started == false){
                delayTimer.StartTimer(delayTime);
                EnemyCloseExplosive en = Instantiate(enemy).GetComponent<EnemyCloseExplosive>();
                en.target = target;
                if(phaseShootTimer.started == false) phaseShootTimer.StartTimer(attackTime);
            }
        }
       // Debug.Log(shootCunter);
        if(shootCunter == 3){
            if(delayTimer.started == false){
                delayTimer.StartTimer(delayTime);
                EnemyLongRange en = Instantiate(enemy2).GetComponent<EnemyLongRange>();
                en.target = target;
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
        
    }
    

    public void Damage(int dmgValue, float stunTime = 0.2f){
        //Debug.Log("chuj");
        if(notInvincible) HP -= dmgValue;
        //stunTimer.StartTimer(stunTime);
    }
}
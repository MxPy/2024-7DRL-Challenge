using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLongRange : MonoBehaviour
{
    public Transform target;
    [SerializeField] int HP = 6;
    [SerializeField] float speed = 3.5f;
    [SerializeField]  float range = 5;
    [SerializeField]  int multiplier = 1; // or more
    [SerializeField] GameObject bullet;
    VariableTimer stunTimer;
    VariableTimer attackTimer;
    bool getHit = false;


    

    NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        
        
        stunTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        attackTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
    }

    private void Update() {
        Vector3 runTo = transform.position + ((transform.position - target.position) * multiplier);
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < range){
            agent.SetDestination(runTo);
            if(attackTimer.started == false){
                Bullet bulletInstance = Instantiate(bullet,transform.position-(transform.position - target.position).normalized, transform.rotation).GetComponent<Bullet>();
                bulletInstance.Setup(-(transform.position - target.position).normalized, 2, 0.2f, 10f, false);
                attackTimer.StartTimer(1);
            }
            
        } 
        else agent.SetDestination(target.position);
        if(stunTimer.finished == true){
            stunTimer.ResetTimer();
            
        }
        if(attackTimer.finished == true){
            attackTimer.ResetTimer();
        }
        if(HP <= 0){
            Death();
        }
    }

    public void Death(){
        LevelManager lvl = GameObject.FindGameObjectsWithTag("LevelManager")[0].GetComponent<LevelManager>();
        lvl.OpenDoor();
        Generator gen = GameObject.FindGameObjectsWithTag("LevelManager")[0].GetComponent<Generator>();
        gen.isEnemy = false;
        Destroy(gameObject);
    }

    public void Damage(int dmgValue, float stunTime = 0.2f){
        HP -= dmgValue;
        //stunTimer.StartTimer(stunTime);
        agent.velocity = new Vector3(0,0,0);
    }
}


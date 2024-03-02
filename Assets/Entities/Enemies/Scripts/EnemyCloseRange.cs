using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCloseRange : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] int HP = 6;
    [SerializeField] float speed = 3.5f;
    VariableTimer stunTimer;
    bool getHit = false;


    

    NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
        stunTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
    }

    private void Update() {
        agent.SetDestination(target.position);
        if(stunTimer.finished == true){
            stunTimer.ResetTimer();
            agent.speed = speed;
        }
        if(HP <= 0){
            Destroy(gameObject);
        }
    }

    public void Damage(int dmgValue, float stunTime = 0.2f){
        HP -= dmgValue;
        stunTimer.StartTimer(stunTime);
        agent.speed = 0f;
    }
}

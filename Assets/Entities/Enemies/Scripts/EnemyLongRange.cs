using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLongRange : MonoBehaviour
{
     [SerializeField] Transform target;
    [SerializeField] int HP = 6;
    [SerializeField] float speed = 3.5f;
    [SerializeField]  float range = 5;
    [SerializeField]  int multiplier = 1; // or more
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
        Vector3 runTo = transform.position + ((transform.position - target.position) * multiplier);
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < range) agent.SetDestination(runTo);
        if(stunTimer.finished == true){
            stunTimer.ResetTimer();
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


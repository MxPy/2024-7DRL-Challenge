using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCloseRangeFly : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] int HP = 6;
    [SerializeField] float speed = 3.5f;

    int xOry = 0;
    VariableTimer stunTimer;
    VariableTimer attackTimer;

    bool getHit = false;


    

    NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
        xOry = Random.Range(0, 2);
        Debug.Log(xOry);
        stunTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
    }

    private void Update() {
        transform.eulerAngles = new Vector3(0,0, GetAngleFromVectorFloat(target.position));
        agent.SetDestination(CalcTargetsPositions(target));
        //PingPongCollectable(transform, target, 2);
        if(stunTimer.finished == true){
            agent.speed = speed;
        }
        if(HP <= 0){
            Destroy(gameObject);
        }
    }

    public void Damage(int dmgValue, float stunTime = 0.2f){
        HP -= dmgValue;
        stunTimer.StartTimer(stunTime);
        agent.velocity = new Vector3(0,0,0);
    }

    private Vector3 CalcTargetsPositions(Transform target){
        Vector3 newTarget;
        //if((int)(Vector3.Distance(target.position, transform.position)/2) <= 0){
            //print("chuj");
            //return target.position;
       // }
        float length = 1.0f; // Desired length of the ping-pong
        float bottomFloor = 2.5f; // The low position of the ping-pong
        
            newTarget = new Vector3(target.position.x, target.position.y + Random.Range(0f, 2f) + bottomFloor,0);
        
        
        //Debug.Log(newTarget);
        return newTarget;
    }

    public float GetAngleFromVectorFloat(Vector3 dir){
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(n < 0) n += 360;
        return n;
    }
}


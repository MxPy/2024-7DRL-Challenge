using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
public class EnemyDasher : MonoBehaviour
{
    //[SerializeField] Transform target;
    [SerializeField] int HP = 6;
    [SerializeField] float speed = 10f;
    [SerializeField]  float range = 1f;
    [SerializeField] GameObject bullet;
    VariableTimer attackTimer;
    VariableTimer stunTimer;
    int actualTarget = 0, nextTarget = 1;
    [SerializeField]float cooldownTime = 1.5f;
    
    [SerializeField] List<GameObject> targetList = new();
    
    bool getHit = false;

    NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
        gameObject.transform.position = targetList[actualTarget].transform.position;
        stunTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        attackTimer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        bullet.GetComponent<Attack>().Setup(new Vector3(0,0,0), 2, 0.2f, false);
    }

    private void Update() {
        //Debug.Log(Vector3.Distance(targetList[actualTarget].transform.position, gameObject.transform.position));
        if(Vector3.Distance(targetList[actualTarget].transform.position, gameObject.transform.position) <= 0.65  && attackTimer.started == false){
            //Debug.Log("chuyuj");
            actualTarget = nextTarget;
            nextTarget += 1;
            if(nextTarget > targetList.Count-1){
                nextTarget = 0;
            }
            attackTimer.StartTimer(cooldownTime);
        }
        if(attackTimer.finished == true){
            agent.SetDestination(targetList[actualTarget].transform.position);
            attackTimer.ResetTimer();
        }
        
        //transform.eulerAngles = new Vector3(0,0, GetAngleFromVectorFloat(agent.steeringTarget+++));
        
        // if (distance <= range){
        //     agent.velocity = new Vector3(0,0,0);
        //     if(attackTimer.started == false){
        //         Attack bulletInstance = Instantiate(bullet,transform.position-(transform.position - target.position).normalized, transform.rotation).GetComponent<Attack>();
        //         bulletInstance.Setup(-(transform.position - target.position).normalized, 2, 0.2f, false);
        //         attackTimer.StartTimer(1);
        //     }
        // }
        if(stunTimer.finished == true){
            stunTimer.ResetTimer();
            
        }
        
        if(HP <= 0){
            Destroy(gameObject);
        }
    }
    void LateUpdate()
    {
        Vector3 worldDirectionToPointForward = agent.velocity.normalized;
        Vector3 localDirectionToPointForward = Vector3.right;

        Vector3 currentWorldForwardDirection = transform.TransformDirection(
                localDirectionToPointForward);
        float angleDiff = Vector3.SignedAngle(currentWorldForwardDirection, 
                worldDirectionToPointForward, Vector3.forward);

        transform.Rotate(Vector3.forward, angleDiff, Space.World);
    }

    public void Damage(int dmgValue, float stunTime = 0.2f){
        HP -= dmgValue;
        //stunTimer.StartTimer(stunTime);
        agent.velocity = new Vector3(0,0,0);
    }
     public float GetAngleFromVectorFloat(Vector3 dir){
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(n < 0) n += 360;
        return n;
    }
}

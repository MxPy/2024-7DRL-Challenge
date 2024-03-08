using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Vector3 attackDir;
    int dmgValue;
    float stunTime;

    [SerializeField] bool isTimed = true;

    //true player, false enemy
    bool playerOrEnemy;

    public void Setup(Vector3 attackDir, int dmgValue, float stunTime, bool playerOrEnemy = true, bool setAngles = true){
        this.attackDir = attackDir;
        this.dmgValue = dmgValue;
        this.stunTime = stunTime;
        this.playerOrEnemy = playerOrEnemy;
        //Debug.Log("SETUP:" + shootDir);
        if(setAngles == true){
            transform.eulerAngles = new Vector3(0,0, GetAngleFromVectorFloat(attackDir));
        }
        
    }

    private void Update() {
        //Debug.Log("UPDATE:" + transform.position);
        if(isTimed) Destroy(gameObject, 0.2f);
    }

    //move it to other file
    public float GetAngleFromVectorFloat(Vector3 dir){
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(n < 0) n += 360;
        return n;
    }

    private void OnTriggerEnter2D(Collider2D other) {
            //Debug.Log("chuj");
            //Debug.Log(other.name);
            if(playerOrEnemy){
                if(other.GetComponent<EnemyCloseRange>())other.GetComponent<EnemyCloseRange>().Damage(dmgValue, stunTime);
                if(other.GetComponent<EnemyLongRange>())other.GetComponent<EnemyLongRange>().Damage(dmgValue, stunTime);
                if(other.GetComponent<EnemyCloseExplosive>())other.GetComponent<EnemyCloseExplosive>().Damage(dmgValue, stunTime);
                if(other.GetComponent<EnemyDasher>())other.GetComponent<EnemyDasher>().Damage(dmgValue, stunTime);
                if(other.GetComponent<HeartBoss>())other.GetComponent<HeartBoss>().Damage(dmgValue, stunTime);
                if(other.GetComponent<PneuBoss>())other.GetComponent<PneuBoss>().Damage(dmgValue, stunTime);
                if(other.GetComponent<BrainBoss>())other.GetComponent<BrainBoss>().Damage(dmgValue, stunTime);
                if(other.GetComponent<EnemyTargetRange>())other.GetComponent<EnemyTargetRange>().Damage(dmgValue, stunTime);
            }
            else if(!playerOrEnemy && other.tag == "Player"){
                //Debug.Log("huj");
                other.GetComponent<PlayerMovement>().Damage(dmgValue, stunTime);
            }
    }
}

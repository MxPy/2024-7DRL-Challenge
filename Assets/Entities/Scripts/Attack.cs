using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Vector3 attackDir;
    int dmgValue;
    float stunTime;

    public void Setup(Vector3 attackDir, int dmgValue, float stunTime, float moveSpeed = 10f){
        this.attackDir = attackDir;
        this.dmgValue = dmgValue;
        this.stunTime = stunTime;
        //Debug.Log("SETUP:" + shootDir);
        transform.eulerAngles = new Vector3(0,0, GetAngleFromVectorFloat(attackDir));
    }

    private void Update() {
        //Debug.Log("UPDATE:" + transform.position);
        Destroy(gameObject, 0.2f);
    }

    //move it to other file
    public float GetAngleFromVectorFloat(Vector3 dir){
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(n < 0) n += 360;
        return n;
    }

    private void OnTriggerEnter2D(Collider2D other) {
            if(other.tag == "EnemyCloseRange"){
                //other.GetComponent<EnemyCloseRange>().Damage(dmgValue, stunTime);
            }
    }
}

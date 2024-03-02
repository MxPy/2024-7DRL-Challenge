using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 shootDir;
    public float moveSpeed = 10f;

    public void Setup(Vector3 shootDir){
        this.shootDir = shootDir;
        transform.eulerAngles = new Vector3(0,0, GetAngleFromVectorFloat(shootDir) -90);
    }

    private void Update() {
        transform.position += shootDir * moveSpeed * Time.deltaTime;
        Destroy(gameObject, 5f);
    }

    //move it to other file
    public float GetAngleFromVectorFloat(Vector3 dir){
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(n < 0) n += 360;
        return n;
    }

    private void OnTriggerEnter2D(Collider2D other) {
            Destroy(gameObject);
    }
}

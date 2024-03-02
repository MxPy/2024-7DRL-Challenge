using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 shootDir;
    public float moveSpeed = 10f;

    public void Setup(Vector3 shootDir){
        this.shootDir = shootDir;
    }

    private void Update() {
        
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }
}

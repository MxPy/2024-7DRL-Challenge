using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackModifier : MonoBehaviour
{
    public int dmgModifier = 1;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            other.GetComponent<PlayerMovement>().SetDmgModifier(dmgModifier);
            Destroy(gameObject);
        }
    }
}

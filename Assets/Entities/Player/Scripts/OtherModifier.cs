using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherModifier : MonoBehaviour
{
    [SerializeField] int otherModifier = 1;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            other.GetComponent<PlayerMovement>().SetOtherModifier(otherModifier);
            Destroy(gameObject);
        }
    }
}

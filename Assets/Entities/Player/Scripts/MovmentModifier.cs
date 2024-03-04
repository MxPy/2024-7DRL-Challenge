using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentModifier : MonoBehaviour
{
    [SerializeField] int movmentModifier = 1;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            other.GetComponent<PlayerMovement>().SetMovmentModifier(movmentModifier);
            Destroy(gameObject);
        }
    }
}

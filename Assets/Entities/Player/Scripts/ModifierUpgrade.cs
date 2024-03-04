using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierUpgrade : MonoBehaviour
{
    [SerializeField] int modifierType = 1;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            other.GetComponent<PlayerMovement>().UpgradeDmgModifier(modifierType);
            Destroy(gameObject);
        }
    }
}

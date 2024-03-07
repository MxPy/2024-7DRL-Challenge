using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierUpgrade : MonoBehaviour
{
    [SerializeField] int modifierType = 1;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            while(ChoseUpgrade(other.GetComponent<PlayerMovement>()) == 1){}
            Destroy(gameObject);
        }
    }

    private int ChoseUpgrade(PlayerMovement mov){
        
        int rnd = Random.Range(0, 2);
        switch(rnd) {
            case 0:
                if (mov.dmgModifierUpgrade == 2) return 1;
                mov.dmgModifierUpgrade += 1;
                return 0;
            case 1:
                if (mov.otherModifierUpgrade == 6) return 1;
                mov.otherModifierUpgrade += 1;
                mov.SetMovmentModifier(Random.Range(0, 3));
                return 0;
        }
    return 1;
    }
}

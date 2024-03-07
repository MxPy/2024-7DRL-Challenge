using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public LevelManager lvl;
    public int RandomLevel(int min, int max){
        return Random.Range(min, max + 1);
    }

    private void Start() {
        lvl.UpdateLevel(0);
    }
}

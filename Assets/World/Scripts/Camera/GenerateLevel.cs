using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public int RandomLevel(int min, int max){
        return Random.Range(min, max + 1);
    }
}

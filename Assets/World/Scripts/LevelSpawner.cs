using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public LevelManager lvl;
    public Generator gen;
    // Start is called before the first frame update
    void Start()
    {
        lvl = GameObject.FindGameObjectsWithTag("LevelManager")[0].GetComponent<LevelManager>();
        gen = GameObject.FindGameObjectsWithTag("LevelManager")[0].GetComponent<Generator>();
        lvl.UpdateLevel(new Vector3(transform.position.x, transform.position.y, 0),gen.getLevelId(), gen.getEnemyId(), gen.getItemId(), gen.getBossId());
    }

    public void spawn(){

    }
   
}

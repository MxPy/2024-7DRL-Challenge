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
        int bossId = gen.getBossId();
        int enemyId = gen.getEnemyId();
        int item = gen.getItemId();
        int lvlId = gen.getLevelId();
        Debug.Log("level" + " " +lvlId+ " " + enemyId+ " " + item+ " " + bossId);
        
        lvl.UpdateLevel(gen.levelCounter, new Vector3(transform.position.x, transform.position.y, 0),lvlId, enemyId, item, bossId);
    }

    public void spawn(){

    }
   
}

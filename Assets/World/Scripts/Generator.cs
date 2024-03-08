using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public int levelCounter =0;

    int currentLevelId = 0;
    int currentEnemyId = -1;
    int currentItemId = -1;
    int currentBossId = 1;
    // Start is called before the first frame updateew
    public int getLevelId(){
        levelCounter++;
        return currentLevelId;
    }
    public int getEnemyId(){
        return currentEnemyId;
    }
    public int getItemId(){
        return currentItemId;
    }
    public int getBossId(){
        return currentBossId;
    }
}

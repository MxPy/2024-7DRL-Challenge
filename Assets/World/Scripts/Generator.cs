using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public int levelCounter = -1;

    /// <summary>
    /// ids
    /// -1 dont spawn at current lvl
    /// 0 - 7 => Heart lvls -- 2-3 items / 3-5 enemies
    /// 8 => Heart Boss - upgrade
    /// 9 - 14 => Pneu lvls -- 1-2 items / 2-3 enemies
    /// 15 => pneu boss - 2 upgrades
    /// 16 - 19 => brain lvls -- 1-2 items / - upgrade
    /// 20 => brain boss
    /// </summary>
    int enemiesiInFirstLevel = 0;
    int itemsInFirstLevel = 0;
    int enemiesiInSecondLevel = 0;
    int itemsInSecondtLevel = 0;
    int enemiesiInThirdLevel = 0;
    int itemsInThirdLevel = 0;

    int currentLevelId = 0;
    int currentEnemyId = -1;
    int currentItemId = -1;
    int currentBossId = -1;
    // Start is called before the first frame updateew

    public bool isBoss = false, isEnemy = false;

    private void Start() {
        enemiesiInFirstLevel = Random.Range(3, 6);
        itemsInFirstLevel = Random.Range(2, 4);

        enemiesiInSecondLevel = Random.Range(2, 4);
        itemsInSecondtLevel = Random.Range(1, 3);

        enemiesiInThirdLevel = Random.Range(1, 3);
        itemsInThirdLevel = Random.Range(0, 2);
    }
    public int getLevelId(){
        
        //change to acurate bossid
        //if(isBoss && levelCounter == 8) currentLevelId = 0;
        if(isBoss && levelCounter == 8) currentLevelId = 1;
        return currentLevelId;
    }
    public int getEnemyId(){
        if(isBoss) currentItemId = -1;
        return currentEnemyId;
    }
    public int getItemId(){
        if(isBoss) currentItemId = -1;
        return currentItemId;
    }
    public int getBossId(){
        levelCounter++;
        if(levelCounter == 8){
            currentBossId = 1;
            isBoss = true;
        }
        else if(levelCounter == 15){
            currentBossId = 1;
            isBoss = true;
        }else{
            currentBossId = -1;
        }
        return currentBossId;
    }
}

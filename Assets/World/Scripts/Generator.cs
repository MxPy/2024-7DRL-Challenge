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
    public int enemiesiInFirstLevel = 0;
    public int itemsInFirstLevel = 0;
    int enemiesiInSecondLevel = 0;
    int itemsInSecondtLevel = 0;
    int enemiesiInThirdLevel = 0;
    int itemsInThirdLevel = 0;

    public int currentLevelId = 0;
    public int currentEnemyId = -1;
    public int currentItemId = -1;
    public int currentBossId = -1;
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
        if(levelCounter < 1) currentLevelId = 11;
        else if(isBoss && levelCounter == 8) currentLevelId = 0;
        else if(isBoss && levelCounter == 15) currentLevelId = 11;
        else if(isBoss && levelCounter == 20) currentLevelId = 18;
        else if(levelCounter < 8) currentLevelId = Random.Range(0, 8);
        else if(levelCounter > 8 && levelCounter < 15) currentLevelId = Random.Range(11, 18);
        else if(levelCounter > 15) currentLevelId = Random.Range(18, 22);
        
        
        return currentLevelId;
    }
    public int getEnemyId(){
        if(isBoss) currentItemId = -1;
        else if(Random.Range(0, 2) == 1 && itemsInFirstLevel>0) currentEnemyId = -1;
        else{
            if(levelCounter < 8){
            if(enemiesiInFirstLevel > 0){
                enemiesiInFirstLevel--;
                currentEnemyId = Random.Range(0, 3);
                isEnemy = true;
                }
            }else if(levelCounter > 8 && levelCounter < 15){
                if(enemiesiInSecondLevel > 0){
                enemiesiInSecondLevel--;
                currentEnemyId = Random.Range(0, 3);
                isEnemy = true;
                }
            }else if(levelCounter > 15){
                if(enemiesiInThirdLevel > 0){
                enemiesiInThirdLevel--;
                currentEnemyId = Random.Range(0, 3);
                isEnemy = true;
                }
            }
            
            
        }
        //Debug.Log(currentEnemyId);
        return currentEnemyId;
    }
    public int getItemId(){
        if(isBoss) currentItemId = -1;
        else if(isEnemy) currentItemId = -1;
        else{
            if(levelCounter < 8){
            if(enemiesiInFirstLevel > 0){
                if(itemsInFirstLevel > 0){
                    itemsInFirstLevel--;
                    currentItemId = Random.Range(0, 6);
                }
                }
            }else if(levelCounter > 8 && levelCounter < 15){
                if(itemsInSecondtLevel > 0){
                itemsInSecondtLevel--;
                currentItemId = Random.Range(0, 3);
                isEnemy = true;
                }
            }else if(levelCounter > 15){
                if(itemsInThirdLevel > 0){
                itemsInThirdLevel--;
                currentEnemyId = Random.Range(0, 3);
                isEnemy = true;
                }
            }
        }
        return currentItemId;
    }
    public int getBossId(){
        isBoss = false;
        isEnemy = false;
        currentEnemyId = -1;
        currentItemId = -1;
        currentBossId = -1;
        levelCounter++;
        if(levelCounter == 8){
            currentBossId = 1;
            isBoss = true;
        }
        else if(levelCounter == 15){
            currentBossId = 0;
            isBoss = true;
        }
        else if(levelCounter == 20){
            currentBossId = 2;
            isBoss = true;
        }else{
            currentBossId = -1;
        }
        return currentBossId;
    }
}

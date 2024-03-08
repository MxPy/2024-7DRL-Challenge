using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] List<GameObject>  rooms = new();
    [SerializeField] List<GameObject> enemies = new();
    [SerializeField] List<GameObject> items = new();
    [SerializeField] List<GameObject> bosses = new();
    [SerializeField] Sprite red;
    [SerializeField] Sprite white;
    [SerializeField] Sprite blue;
    GameObject[] doors;

    GameObject lastRoom = null;

    int temp;

    


    // Start is called before the first frame update
    public void UpdateLevel(int counter, Vector3 position, int roomId, int enemyId = -1, int itemId = -1, int bossId = -1){
        //Debug.Log("chujj " + position);
        if(lastRoom) Destroy(lastRoom);
        temp = counter;
        lastRoom = new GameObject("Master");
        lastRoom.transform.position = position;

        GameObject room = Instantiate(rooms[roomId], lastRoom.transform);
        
        room.transform.Find("NavMesh").GetComponent<NavMeshPlus.Components.NavMeshSurface>().BuildNavMesh();
        //room.transform.parent = lastRoom.transform;

        

        doors = GameObject.FindGameObjectsWithTag("Door");
        foreach (GameObject door in doors){
            door.GetComponent<BoxCollider2D>().enabled = false;
            if(GameObject.FindGameObjectsWithTag("LevelManager")[0].GetComponent<Generator>().levelCounter <= 8)
            door.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = blue;
            else if(GameObject.FindGameObjectsWithTag("LevelManager")[0].GetComponent<Generator>().levelCounter > 8 && GameObject.FindGameObjectsWithTag("LevelManager")[0].GetComponent<Generator>().levelCounter <= 15)
            door.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = red;
            else{
                door.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = white;
            }

            
            
            door.transform.GetChild(0).gameObject.SetActive(false);
        }
        if(enemyId == -1 && itemId == -1 && bossId == -1){
            OpenDoor();
        }
        // Im so dumb, for not using OOP
        if(enemyId != -1){
            
            GameObject enemy = Instantiate(enemies[enemyId], lastRoom.transform);
            enemy.transform.position += Vector3.up*Random.Range(-1, 2)*2;
            // enemy.transform.parent = lastRoom.transform;
            // enemy.transform.localPosition = new Vector3(0,0,0);
            // enemy.transform.position = -enemy.transform.position;
            // Debug.Log(enemy.transform.localPosition);
            //enemy.transform.localRotation = Quaternion.Euler(0f,0f,0f);
            switch(enemyId) {
            case 0:
                //trombocyt
                if(temp < 8)
                enemy.GetComponent<EnemyLongRange>().target = player;
                else if(temp > 8 && temp <15){
                    enemy.GetComponent<EnemyLongRange>().target = player;
                    enemy.GetComponent<EnemyLongRange>().target = player;
                }else{
                    enemy.GetComponent<EnemyLongRange>().target = player;
                    enemy.GetComponent<EnemyLongRange>().target = player;
                    enemy.GetComponent<EnemyLongRange>().target = player;
                }
                break;
            case 1:
                //explo
                if(temp < 8)
                enemy.GetComponent<EnemyCloseExplosive>().target = player;
                else if(temp > 8 && temp <15){
                    enemy.GetComponent<EnemyCloseExplosive>().target = player;
                    enemy.GetComponent<EnemyCloseExplosive>().target = player;
                }else{
                    enemy.GetComponent<EnemyCloseExplosive>().target = player;
                    enemy.GetComponent<EnemyCloseExplosive>().target = player;
                    enemy.GetComponent<EnemyCloseExplosive>().target = player;
                }
                
                break;
            case 2:
                //
                break;
            case 3:
                if(temp < 8)
                enemy.GetComponent<EnemyCloseRange>().target = player;
                else if(temp > 8 && temp <15){
                    enemy.GetComponent<EnemyCloseRange>().target = player;
                    enemy.GetComponent<EnemyCloseRange>().target = player;
                }else{
                    enemy.GetComponent<EnemyCloseRange>().target = player;
                    enemy.GetComponent<EnemyCloseRange>().target = player;
                    enemy.GetComponent<EnemyCloseRange>().target = player;
                }
                break;
            case 4:
                if(temp < 8)
                enemy.GetComponent<EnemyCloseRange>().target = player;
                else if(temp > 8 && temp <15){
                    enemy.GetComponent<EnemyCloseRange>().target = player;
                    enemy.GetComponent<EnemyCloseRange>().target = player;
                }else{
                    enemy.GetComponent<EnemyCloseRange>().target = player;
                    enemy.GetComponent<EnemyCloseRange>().target = player;
                    enemy.GetComponent<EnemyCloseRange>().target = player;
                }
                break;
            }
        }
        
        // may change to spawn postfight or during fight
        if(itemId != -1){
            //Debug.Log("kuuuutas "+itemId);
            
            GameObject item = Instantiate(items[itemId], lastRoom.transform);
            Debug.Log(items[itemId].name);
            item.transform.position += Vector3.up*Random.Range(-1, 2)*2;
            //item.transform.parent = lastRoom.transform;
            OpenDoor();
        }

        if(bossId != -1){
            GameObject boss = Instantiate(bosses[bossId], lastRoom.transform);
            //boss.transform.parent = lastRoom.transform;
            switch(bossId) {
            case 0:
                //heart
                boss.transform.Find("Boss").GetComponent<HeartBoss>().target = player;
                
                break;
            case 1:
                boss.transform.Find("Boss").GetComponent<PneuBoss>().target = player;
                boss.transform.Find("Boss").GetComponent<PneuBoss>().posTran = lastRoom.transform;
                break;
            case 2:
                boss.transform.Find("Boss").GetComponent<BrainBoss>().target = player;
                break;
            }
        }
        
    }

    public void OpenDoor(){
        doors = GameObject.FindGameObjectsWithTag("Door");
         foreach (GameObject door in doors){
            door.GetComponent<BoxCollider2D>().enabled = true;
            door.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}

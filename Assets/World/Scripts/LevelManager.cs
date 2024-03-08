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
    GameObject[] doors;

    GameObject lastRoom = null;


    // Start is called before the first frame update
    public void UpdateLevel(Vector3 position, int roomId, int enemyId = -1, int itemId = -1, int bossId = -1){
        //Debug.Log("chujj " + position);
        if(lastRoom) Destroy(lastRoom);
        lastRoom = new GameObject("Master");
        lastRoom.transform.position = position;

        GameObject room = Instantiate(rooms[roomId], lastRoom.transform);
        
        room.transform.Find("NavMesh").GetComponent<NavMeshPlus.Components.NavMeshSurface>().BuildNavMesh();
        //room.transform.parent = lastRoom.transform;

        

        doors = GameObject.FindGameObjectsWithTag("Door");
        foreach (GameObject door in doors){
            door.GetComponent<BoxCollider2D>().enabled = false;
            door.transform.GetChild(0).gameObject.SetActive(false);
        }
        if(enemyId == -1 && itemId == -1 && bossId == -1){
            OpenDoor();
        }
        // Im so dumb, for not using OOP
        if(enemyId != -1){
            
            GameObject enemy = Instantiate(enemies[enemyId], lastRoom.transform);
            enemy.transform.position += Vector3.up*4;
            // enemy.transform.parent = lastRoom.transform;
            // enemy.transform.localPosition = new Vector3(0,0,0);
            // enemy.transform.position = -enemy.transform.position;
            // Debug.Log(enemy.transform.localPosition);
            //enemy.transform.localRotation = Quaternion.Euler(0f,0f,0f);
            switch(enemyId) {
            case 0:
                //trombocyt
                enemy.GetComponent<EnemyLongRange>().target = player;
                break;
            case 1:
                //explo
                enemy.GetComponent<EnemyCloseExplosive>().target = player;
                break;
            case 2:
                //
                break;
            case 3:
                // code block
                break;
            case 4:
                // code block
                break;
            }
        }
        
        // may change to spawn postfight or during fight
        if(itemId != -1){
            Debug.Log("kuuuutas "+itemId);
            
            GameObject item = Instantiate(items[itemId], lastRoom.transform);
            Debug.Log(items[itemId].name);
            item.transform.position += Vector3.up*4;
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
                //
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

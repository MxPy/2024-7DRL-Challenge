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

        GameObject room = Instantiate(rooms[roomId]);
        room.transform.Find("NavMesh").GetComponent<NavMeshPlus.Components.NavMeshSurface>().BuildNavMesh();
        room.transform.parent = lastRoom.transform;

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
            OpenDoor();
            GameObject enemy = Instantiate(enemies[enemyId]);
            enemy.transform.parent = lastRoom.transform;
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
            enemy.transform.localEulerAngles = new Vector3(0,0,0);
        }
        
        // may change to spawn postfight or during fight
        if(itemId != -1){
            GameObject item = Instantiate(items[itemId]);
            item.transform.parent = lastRoom.transform;
            OpenDoor();
        }

        if(bossId != -1){
            GameObject boss = Instantiate(bosses[bossId]);
            boss.transform.parent = lastRoom.transform;
            switch(bossId) {
            case 0:
                //heart
                boss.transform.Find("Boss").GetComponent<HeartBoss>().target = player;
                break;
            case 1:
                boss.transform.Find("Boss").GetComponent<PneuBoss>().target = player;
                break;
            case 2:
                //
                break;
            }
        }
        lastRoom.transform.position = position;
    }

    public void OpenDoor(){
         foreach (GameObject door in doors){
            door.GetComponent<BoxCollider2D>().enabled = true;
            door.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}

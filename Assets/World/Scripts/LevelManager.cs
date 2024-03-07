using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] List<GameObject> rooms = new();
    [SerializeField] List<GameObject> enemies = new();
    [SerializeField] List<GameObject> items = new();
    [SerializeField] List<GameObject> bosses = new();

    GameObject lastRoom;


    // Start is called before the first frame update
    public void UpdateLevel(int roomId, int enemyId = -1, int itemId = -1, int bossId = -1){
        Destroy(lastRoom);
        lastRoom = new GameObject("Master");

        GameObject room = Instantiate(rooms[roomId]);
        room.transform.Find("NavMesh").GetComponent<NavMeshPlus.Components.NavMeshSurface>().BuildNavMesh();
        room.transform.parent = lastRoom.transform;

        // Im so dumb, for not using OOP
        if(enemyId != -1){
            GameObject enemy = Instantiate(enemies[enemyId]);
            switch(enemyId) {
            case 0:
                //trombocyt
                enemy.GetComponent<EnemyLongRange>().target = player;
                break;
            case 1:
                //
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
        
    }
}

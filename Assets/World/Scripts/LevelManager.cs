using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<GameObject> rooms = new();
    [SerializeField] List<GameObject> enemies = new();
    [SerializeField] List<GameObject> items = new();
    [SerializeField] List<GameObject> bosses = new();


    // Start is called before the first frame update
    public void UpdateLevel(int roomId, int enemyId = -1, int itemId = -1, int bossId = -1){
        GameObject room = Instantiate(rooms[roomId]);
        room.transform.Find("NavMesh").GetComponent<NavMeshPlus.Components.NavMeshSurface>().BuildNavMesh();
    }
}

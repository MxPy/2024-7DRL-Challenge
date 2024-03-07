using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    public Transform newPlacement;
    //public LevelManager lvl;
    public Transform[] placementsList;
    //public GenerateLevel generator;
    void Start(){
        //lvl = GameObject.FindGameObjectsWithTag("LevelManager")[9].GetComponent<LevelManager>();
        //move2()
        int num = RandomLevel(0,1);
        if(placementsList[num] == null){
            Debug.LogError("No transform");
            return;
        }
        Debug.Log("transform");
        transform.position = placementsList[num].position;
        transform.rotation = placementsList[num].rotation;
        transform.localScale = placementsList[num].localScale;
        //lvl.UpdateLevel(transform.position, transform.rotation, transform.localScale,0, -1, -1, -1);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player == null){
            Debug.LogError("No player");
        return;
        }
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, 0);
        player.transform.position = newPosition;
    }

    void Update()
    {
        
    }

    //temporary fun
    public int RandomLevel(int min, int max){
        return Random.Range(min, max + 1);
    }
    public void CameraMove(){
        if(newPlacement == null){
            Debug.LogError("No transform");
            return;
        }
        Debug.Log("transform");
        transform.position = newPlacement.position;
        transform.rotation = newPlacement.rotation;
        transform.localScale = newPlacement.localScale;
        //lvl.UpdateLevel(transform.position, transform.rotation, transform.localScale,0, -1, -1, -1);
        
    }

    public void CameraMove2(){
        // positions are assign statically for every camera prefab
        // waits until the final tilemap
        int num = RandomLevel(0,3);
        if(placementsList[num] == null){
            Debug.LogError("No transform");
            return;
        }
        Debug.Log("transform");
        transform.position = placementsList[num].position;
        transform.rotation = placementsList[num].rotation;
        transform.localScale = placementsList[num].localScale;
        //lvl.UpdateLevel(transform.position, transform.rotation, transform.localScale,0, -1, -1, -1);
    }
    
}

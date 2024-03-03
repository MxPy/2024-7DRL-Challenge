using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    public Transform newPlacement;
    public Transform[] placementsList;
    void Start()
    {
 
    }

    void Update()
    {
        
    }

    int RandomLevel(int min, int max){
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
    }

    public void CameraMove2(int toTheLevel){
        /*
        if(toTheLevel == 1){
            // transform[] that is specified for this type of prefab (eg. 2LD Doors)
        }
        */
        int num = RandomLevel(0,3);
        if(placementsList[num] == null){
            Debug.LogError("No transform");
            return;
        }
        Debug.Log("transform");
        transform.position = placementsList[num].position;
        transform.rotation = placementsList[num].rotation;
        transform.localScale = placementsList[num].localScale;
    }
    
}

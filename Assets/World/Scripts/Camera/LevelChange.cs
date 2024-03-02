using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    public Transform newPlacement;
    void Start()
    {
        
    }

    void Update()
    {
        
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
}

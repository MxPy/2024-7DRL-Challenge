using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public GameObject cameraPrefab;

    private void OnTriggerEnter2D(Collider2D other){
        GameObject currentCamera = Camera.main.gameObject;

        if (currentCamera.CompareTag("MainCamera"))
        {
            Destroy(currentCamera);
            GameObject newCamera = Instantiate(cameraPrefab, transform.position, transform.rotation);
            newCamera.tag = "MainCamera";
        }
        /*
        LevelChange level = cameraPrefab.GetComponent<LevelChange>();
        if (other.CompareTag("Player")){
            Debug.Log("bef function");
            level.CameraMove2();
            Debug.Log("af function");
        }
        else{
            Debug.LogError("No script");
        }
        */
    }

}

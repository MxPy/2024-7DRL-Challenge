using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public GameObject cameraPrefab;

    private void OnTriggerEnter2D(Collider2D other){
        GameObject currentCamera = Camera.main.gameObject;
        LevelChange level = cameraPrefab.GetComponent<LevelChange>();

        if (currentCamera.CompareTag("MainCamera") && other.CompareTag("Player"))
        {
            // changes the position (level)
            Debug.Log("bef function");
            level.CameraMove2();
            Debug.Log("af function");

            //change current camera prefab (doors placement)
            Destroy(currentCamera);
            GameObject newCamera = Instantiate(cameraPrefab, transform.position, transform.rotation);
            newCamera.tag = "MainCamera";
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public GameObject[] cameraPrefab;
    int nextLevel = 0;

    //same fun as in levelchange(), to be removed
    int RandomLevel(int min, int max){
        return Random.Range(min, max + 1);
    }

    private void OnTriggerEnter2D(Collider2D other){
        GameObject currentCamera = Camera.main.gameObject;
        nextLevel = RandomLevel(0,1);
        LevelChange level = cameraPrefab[nextLevel].GetComponent<LevelChange>();

        if (currentCamera.CompareTag("MainCamera") && other.CompareTag("Player"))
        {
            // changes the position (level)
            Debug.Log("bef function");
            level.CameraMove2(nextLevel);
            Debug.Log("af function");

            //change current camera prefab (doors placement)
            Destroy(currentCamera);
            GameObject newCamera = Instantiate(cameraPrefab[nextLevel], transform.position, transform.rotation);
            newCamera.tag = "MainCamera";
        }
    }

}
